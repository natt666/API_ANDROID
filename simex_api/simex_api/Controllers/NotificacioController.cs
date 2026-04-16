using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simex_api.Models;

namespace simex_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacioController : Controller
    {
        private readonly Simex02Context _context;

        public NotificacioController(Simex02Context context)
        {
            _context = context;
        }

        [HttpGet("usuari/{id}")]
        public async Task<ActionResult<IEnumerable<Notificacione>>> GetNotificacionesByUsuari(int id)
        {
            ActionResult<IEnumerable<Notificacione>> result;

            var notificaciones = await _context.Notificaciones
                            .Where(n => n.UsuariId == id)
                            .OrderBy(n => n.Visto)
                            .ThenByDescending(n => n.Id)
                            .ToListAsync();

            if (notificaciones == null || notificaciones.Count == 0)
            {
                result = NotFound(new { missatge = "No hi ha notificacions per aquest usuari" });
            }
            else
            {
                result = notificaciones;
            }

            return result;
        }

        [HttpPut("marcarVisto/{id}")]
        public async Task<ActionResult> MarcarVisto(int id)
        {
            ActionResult result;

            var notificacion = await _context.Notificaciones.FirstOrDefaultAsync(n => n.Id == id);

            if (notificacion == null)
            {
                result = NotFound(new { missatge = "Notificació no trobada" });
            }
            else
            {
                notificacion.Visto = true;
                try
                {
                    await _context.SaveChangesAsync();
                    result = Ok(new { missatge = "Notificació marcada com a vista" });
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
