using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simex_api.Models;

namespace simex_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertasController : Controller
    {
        private readonly Simex02Context _context;

        public OfertasController(Simex02Context context)
        {
            _context = context;
        }

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<IEnumerable<Oferte>>> GetOfertesByClient(int clientId)
        {
            ActionResult result;

            var ofertes = await _context.Ofertes
            .Where(o => o.Solicitud.ClientId == clientId)
            .Select(o => new
            {
                IdOferta = o.Id,
                DataCreacio = o.DataCreacio,
                Estat = o.EstatOferta.Estat,
                TipoTransporte = o.Solicitud.TipusTransport.Tipus,
                TipoGrupCarga = o.TipusGrupCarrega.Nom,

                SolicitudInfo = new
                {
                    o.Solicitud.Id,
                    o.Solicitud.MercanciaNombre,
                    o.Solicitud.PesBrut,
                    o.Solicitud.Volum,
                    Origen = o.Solicitud.Origen.Nom,
                    Destino = o.Solicitud.Destino.Nom,
                    Incoterm = o.Solicitud.Incoterm.TipusInconterm.Nom,
                    TipusFluxe = o.Solicitud.TipusFluxe.Tipus
                }
            })
            .OrderByDescending(o => o.DataCreacio)
            .ToListAsync();

            if (ofertes == null || !ofertes.Any())
            {
                result =  NotFound(new { missatge = "No s'han trobat ofertes per aquest client" });
            }
            else
            {
                result = Ok(ofertes);
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOfertaDetalle(int id)
        {
            ActionResult result;

            var oferta = await _context.Ofertes
                .Where(o => o.Id == id)
                    .Select(o => new
                    {
                        Id = o.Id,
                        Referencia = o.Id,
                        Comentaris = o.Comentaris,
                        DataCreacio = o.DataCreacio,
                        Etd = o.Etd,
                        Eta = o.Eta,
                        Estado = o.EstatOferta.Estat,

                    Mercancia = new
                    {
                        Nombre = o.Solicitud.MercanciaNombre,
                        Tipo = o.Solicitud.TipusContenidor.Tipus,
                        TipoEtiqueta = o.TipusGrupCarrega.Nom,
                        TipoCarga = o.Solicitud.TipusCarrega,
                                    Peso = o.Solicitud.PesBrut,
                        Volumen = o.Solicitud.Volum,
                        IncotermCodi = o.Solicitud.Incoterm.TipusInconterm.Codi,
                        IncotermNom = o.Solicitud.Incoterm.TipusInconterm.Nom,
                    },

                    Transporte = new
                    {
                        Origen = o.Solicitud.Origen.Nom,
                        Destino = o.Solicitud.Destino.Nom,
                        TransportistaOrigen = o.TransportistaOrigen.Nom,
                        TransportistaDestino = o.TransportistaDestino.Nom,
                        Naviera = o.LiniaTransportMaritim.Nom,
                        PuertoOrigen = o.PortOrigen.Nom,
                        PuertoDestino = o.PortDesti.Nom,
                        TipoTransporte = o.Solicitud.TipusTransport.Tipus
                    },

                    Personal = new
                    {
                        Cliente = new
                        {
                            o.Solicitud.Client.Nom,
                            o.Solicitud.Client.Cognoms,
                            o.Solicitud.Client.Empresa
                        },
                        Operador = new
                        {
                            o.Solicitud.Operador.Nom,
                            o.Solicitud.Operador.Cognoms
                        },
                        Agente = _context.Usuaris
                            .Where(u => u.Id == o.AgentComercialId)
                            .Select(u => new { u.Nom, u.Cognoms })
                            .FirstOrDefault()
                    }
                })
                .FirstOrDefaultAsync();

            if (oferta == null)
            {
                result = NotFound();
            }
            else
            {
                result = Ok(oferta);
            }

            return result;
        }

        [HttpGet("client/{clientId}/tipus-fluxe/{tipusFluxeId}")]
        public async Task<ActionResult> GetOfertesByClientAndTipusFluxe(int clientId, int tipusFluxeId)
        {
            ActionResult result;

            var ofertes = await _context.Ofertes
                .Where(o => o.Solicitud.ClientId == clientId && o.Solicitud.TipusFluxeId == tipusFluxeId)
                .Select(o => new
                {
                    IdOferta = o.Id,
                    DataCreacio = o.DataCreacio,
                    DataCaducitat = o.Eta,
                    Estat = o.EstatOferta.Estat,
                    TipoTransporte = o.Solicitud.TipusTransport.Tipus,
                    TipoGrupCarga = o.TipusGrupCarrega.Nom,

                    SolicitudInfo = new
                    {
                        o.Solicitud.Id,
                        o.Solicitud.MercanciaNombre,
                        o.Solicitud.PesBrut,
                        o.Solicitud.Volum,
                        OrigenId = o.Solicitud.Origen.Id,
                        DestinoId = o.Solicitud.Destino.Id,
                        Incoterm = o.Solicitud.Incoterm.TipusInconterm.Nom,
                        TipusFluxe = o.Solicitud.TipusFluxe.Tipus
                    }
                })
                .OrderByDescending(o => o.DataCreacio)
                .ToListAsync();

            if (ofertes == null || !ofertes.Any())
            {
                result = NotFound(new { missatge = "No s'han trobat ofertes per aquest client" });
            }
            else
            {
                result = Ok(ofertes);
            }

            return result;
        }
    }
}