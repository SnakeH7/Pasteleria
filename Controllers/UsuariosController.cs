using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Data;
using Pasteleria.Models;
using BCrypt.Net;

namespace Pasteleria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly PasteleriaContext _context;

        public UsuariosController(PasteleriaContext context) //Colocamos el contexto y la conexión en nuestro controller
        {
            _context = context;
        }

        [HttpPost("registrar")] //ENDPOINT DEL REGISTRO
        public async Task<ActionResult> Registrar(UsuarioDTO peticion)
        {
            //Validacion sencilla para evitar duplicar correos y por seguridad
            bool usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Correo == peticion.Correo); //Busca en la base un correo igual

            if (usuarioExiste)
            {
                return BadRequest("El Correo ya está en uso");
            }

            string hashGenerado = BCrypt.Net.BCrypt.HashPassword(peticion.Contrasena); //BCrypt Hashea la contraseña para mayor seguridad

            var nuevoUsuario = new Usuarios //Objeto para la DB
            {
                Correo = peticion.Correo,
                ContrasenaHash = hashGenerado
            }; //Dentro se guarda la contraseña hasheada solamente

            _context.Usuarios.Add(nuevoUsuario); 
            await _context.SaveChangesAsync(); //Await espera a que el método termine
            return Ok("¡Usuario registrado con éxito!");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Iniciar(UsuarioDTO peticion)
        {
            var usuarioEnBD = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == peticion.Correo);

            if(usuarioEnBD == null)
            {
                return BadRequest("Correo o contraseña incorrectos");
            }

            bool contrasenaCorrecta = BCrypt.Net.BCrypt.Verify(peticion.Contrasena, usuarioEnBD.ContrasenaHash);

            if(!contrasenaCorrecta)
            {
                return BadRequest("¡EL correo o la contraseña es incorrectos!");
            }

            return Ok("¡Bienvenido!");
        }
    }
}
