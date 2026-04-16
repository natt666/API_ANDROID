using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simex_api.Models;

namespace simex_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly Simex02Context _context;

        public UserController(Simex02Context context)
        {
            _context = context;
        }

        [HttpGet("login")]
        public async Task<ActionResult<Usuari>> GetUserLogin([FromQuery] string email, [FromQuery] string pass)
        {
            ActionResult<Usuari> result;
            string emailLimpio = email.Trim().ToLower();
            string passLimpio = pass.Trim();

            var usuario = await _context.Usuaris.FirstOrDefaultAsync(u =>
                u.Correu == emailLimpio);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(passLimpio, usuario.Contrasenya))
            {
                result = NotFound(new { missatge = "Usuario no encontrado en la BD" });
            }
            else
            {
                result = usuario;
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuari>> GetPerfil(int id)
        {
            ActionResult<Usuari> result;

            var usuario = await _context.Usuaris
                            .Include(u => u.Pais).
                                FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                result = NotFound(new { missatge = "Registre no trobat" });
            }
            else
            {
                result = usuario;
            }

            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerfil(int id, Usuari user)
        {
            ActionResult result;
            var usuario = await _context.Usuaris.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                result = NotFound(new { missatge = "Registre no trobat" });
            }
            else
            {
                usuario.Nom = user.Nom;
                usuario.Cognoms = user.Cognoms;
                usuario.PaisId = user.PaisId;
                usuario.Empresa = user.Empresa;
                usuario.Dni = user.Dni;
                usuario.FotoUser = user.FotoUser;

                if (!string.IsNullOrEmpty(user.Contrasenya) && !user.Contrasenya.StartsWith("$2"))
                {
                    usuario.Contrasenya = BCrypt.Net.BCrypt.HashPassword(user.Contrasenya);
                }

                try
                {
                    await _context.SaveChangesAsync();
                    result = Ok(new { missatge = "Actualización realizada correctamente" });
                }
                catch (DbUpdateException ex)
                {
                    result = StatusCode(500, new { missatge = "Error al guardar en la base de dades", detall = ex.Message });
                }
            }
            return result;
        }

        [HttpGet("{id}/verificarContrasena")]
        public async Task<ActionResult> VerificarContrasena(int id, [FromQuery] string? contrasena)
        {
            Console.Error.WriteLine($"verificarContrasena llamado con id: {id}, contrasena: {contrasena}");

            ActionResult result;

            var usuario = await _context.Usuaris.FirstOrDefaultAsync(u => u.Id == id);
            Console.Error.WriteLine($"verificarContrasena llamado con id: {id}, contrasena: {contrasena}");


            if (usuario == null){
                
                result =  NotFound();

            } else if (BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasenya.Replace("$2a$11", "$2y12$")))
            {
                result = Ok();
            }
            else{
                result = BadRequest(new { missatge = "Contraseña incorrecta" });
            }

            return result;
        }

        [HttpPut("{id}/dni")]
        public async Task<ActionResult> UpdateDni(int id, [FromBody] UpdateDniDto dto)
        {
            ActionResult result;

            var usuario = await _context.Usuaris.FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                result = NotFound(new { missatge = "Usuari no trobat" });
            }
            else
            {
                usuario.FotoDniFront = dto.FotoDniFront;
                usuario.FotoDniBack = dto.FotoDniBack;
                usuario.ClauAes = dto.ClauAes;

                try
                {
                    await _context.SaveChangesAsync();
                    result = Ok(new { missatge = "DNI actualitzat correctament" });
                }
                catch (DbUpdateException ex)
                {
                    result = StatusCode(500, new { missatge = "Error al guardar", detall = ex.Message });
                }
            }

            return result;
        }

    }
}

