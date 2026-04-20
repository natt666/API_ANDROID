using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simex_api.Models;


namespace TrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipusTrackingsController : ControllerBase
    {
        private readonly Simex02Context _context;

        public TipusTrackingsController(Simex02Context context)
        {
            _context = context;
        }

        // GET: api/TipusTrackings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipusTracking>>> GetTipusTrackings()
        {
            return await _context.TipusTrackings.ToListAsync();
        }

        // GET: api/TipusTrackings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipusTracking>> GetTipusTracking(int id)
        {
            var tipusTracking = await _context.TipusTrackings.FindAsync(id);

            if (tipusTracking == null)
            {
                return NotFound();
            }

            return tipusTracking;
        }

        // PUT: api/TipusTrackings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipusTracking(int id, TipusTracking tipusTracking)
        {
            if (id != tipusTracking.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipusTracking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipusTrackingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // 

        private bool TipusTrackingExists(int id)
        {
            return _context.TipusTrackings.Any(e => e.Id == id);
        }
    }
}
