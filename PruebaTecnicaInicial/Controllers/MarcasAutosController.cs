using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaInicial.Data;
using PruebaTecnicaInicial.Models;

namespace PruebaTecnicaInicial.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class MarcasAutosController : ControllerBase
    {

        private readonly ApplicationContext _context;
        public MarcasAutosController(ApplicationContext ctx)
        {
            _context = ctx;
        }

        // Definir ruta para obtener todas las marcas de autos
        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {
            // crear el objeto de response para almacenar la data dentro
            Response r = new Response();
            r.Data = await _context.MarcaAutos.ToListAsync<Object>();
            
            return Ok(r);
        }
    }


}
