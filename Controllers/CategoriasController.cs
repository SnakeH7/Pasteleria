using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Data;
using Pasteleria.Models;
namespace Pasteleria.Controllers
{
    [Route("api/[controller]")] //La ruta de mi sitio 
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly PasteleriaContext _context; //Readonly se asegura de que una vez que haya recibido un valor _context
        //ya no puede cambiar la variable, ni siquiera de manera accidental 

        public CategoriasController(PasteleriaContext context) //Inyección de dependencias/clean architecture
        {
            _context = context;
        }
        //Endpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetCategorias() //Asyn Task quiere decir que la tarea es asíncrona permitiendo liberar el hilo para más tareas
        {
            //IEnumerable es una colección en forma de lista de tipo "Categorias"
            var categorias = await _context.Categorias.ToListAsync(); //_context categorías es la tabla de la base de datos y ToListAsync se encarga de crear una Query SQL
            return Ok(categorias); //OK devuelve 200. Await pausa el método hasta que regrese la lista transformada sin bloquear el server
        }

        [HttpPost]
        public async Task<ActionResult<Categorias>> PostCategorias(Categorias nuevaCategoria)
        {
            _context.Categorias.Add(nuevaCategoria); //utilizamos _context para viajar hasta la db
            await _context.SaveChangesAsync(); //await espera a que se realicen los cambios (SaveChangesAsync()) para enviarlos a SQL Server
            return Ok(nuevaCategoria); //Se devuelve la categoría recien agregada 
        }
        
    }
}
