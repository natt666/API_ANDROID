using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simex_api.Models;

namespace simex_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaissosController : Controller
    {

        private readonly Simex02Context _context;

        public PaissosController(Simex02Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paisso>>> GetPaissos()
        {
            ActionResult<IEnumerable<Paisso>> result;

            var llistaPaissos = await _context.Paissos
                                       .OrderBy(p => p.Nom)
                                       .ToListAsync();

            if (llistaPaissos == null || llistaPaissos.Count == 0)
            {
                result = NotFound(new { missatge = "No se han encontrado países en la BD" });
            }
            else
            {
                result = llistaPaissos;
            }

            return result;
        }
    }
}
