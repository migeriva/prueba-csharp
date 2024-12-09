using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PruebaTecnicaInicial.Controllers;
using PruebaTecnicaInicial.Data;
using PruebaTecnicaInicial.Models;

namespace TestProject
{
    public class MarcaTesting
    {

        [Fact]
        public async void Get_Ok()
        {
            // Crear nuevas opciones para que se pueda generar una nueva base de datos en memoria para tests
            var opts = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(databaseName: "dbtest").Options;

            using (var ctx = new ApplicationContext(opts))
            {
                var ctrl = new MarcasAutosController(ctx);
                var result = await ctrl.Get();

                Assert.IsType<OkObjectResult>(result);

            }

        }

        [Fact]
        public async void Get_Empty()
        {

            // Crear nuevas opciones para que se pueda generar una nueva base de datos en memoria para tests
            var opts = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(databaseName: "dbtest").Options;

            using (var ctx = new ApplicationContext(opts))
            {
                var ctrl = new MarcasAutosController(ctx);
                var result = (OkObjectResult)await ctrl.Get();

                var parsed = Assert.IsType<Response>(result.Value);

                Assert.Empty(parsed.Data);

            }

        }


        [Fact]
        public async void Get_Not_Empty()
        {

            // Crear nuevas opciones para que se pueda generar una nueva base de datos en memoria para tests
            // Cambio de nombre en la base para no arruinar el test anterior
            var opts = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(databaseName: "dbtest2").Options;

            using (var ctx = new ApplicationContext(opts))
            {
                ctx.MarcaAutos.Add(new MarcaAuto { Name = "Audi", Id = 1 });
                ctx.MarcaAutos.Add(new MarcaAuto { Name = "Kia", Id = 2 });
                ctx.MarcaAutos.Add(new MarcaAuto { Name = "Toyota", Id = 3 });

                ctx.SaveChanges();
            }

            using (var ctx = new ApplicationContext(opts))
            {
                var ctrl = new MarcasAutosController(ctx);
                var result = (OkObjectResult)await ctrl.Get();

                var parsed = Assert.IsType<Response>(result.Value);

                Console.WriteLine("item", parsed);
                Assert.True(parsed.Data.Count > 0);

            }

        }

    }
}
