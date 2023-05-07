using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.OrderBy(g => g.Nombre).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpGet("primer")]
        public async Task<ActionResult<Genero>> Primer()
        {
            //De esta forma se trae el primer valor que encuentre en la tabla
            //return await context.Generos.FirstAsync();

            //Forma para traer el primer valor que empiece con la letra "C"
            //return await context.Generos.FirstAsync(g => g.Nombre.StartsWith("C"));

            // FirstOrDefault hace que traiga el primero que especifiquemos y si no lo encuentra retorna nulo
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Nombre.StartsWith("C"));

            if (genero is null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpGet("filtrar")]
        public async Task<IEnumerable<Genero>> Filtrar(string nombre)
        {
            //Forma 1 sin necesidad de parametro

            //return await context.Generos.Where(
            //    g => g.Nombre.StartsWith("C") || g.Nombre.StartsWith("A")
            //    ).ToListAsync();

            // Filtrar segun el parametro
            return await context.Generos
                .Where( g => g.Nombre.Contains(nombre))
                .ToListAsync();
                //.OrderByDescending(g => g.Nombre).ToListAsync();
        }

        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion(int pagina = 1)
        {
            var cantidadRegistrosPorPagina = 2;
            var generos = await context.Generos
                .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                .Take(cantidadRegistrosPorPagina)
                .ToListAsync();

            return generos;
        }
    }
}
