using Microsoft.EntityFrameworkCore;
using PruebaTecnicaInicial.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// agregar la conexion a base de datos postgres usando el campos DefaultConnection creado en el archivo appsettings.json
builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    // Verificando que la base de datos haya ha sido creada al iniciar el proyecto y ejecutar la migracion
    var ctx = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

    try
    {
        ctx.Database.EnsureCreated();
        ctx.Database.Migrate();

    } catch(Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
