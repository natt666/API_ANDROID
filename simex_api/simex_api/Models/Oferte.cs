using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class Oferte
{
    public int Id { get; set; }

    public int TipusTransportId { get; set; }

    public string? Comentaris { get; set; }

    public int AgentComercialId { get; set; }

    public int TransportistaOrigenId { get; set; }

    public int TipusValidacioId { get; set; }

    public int? PortOrigenId { get; set; }

    public int? PortDestiId { get; set; }

    public int? LiniaTransportMaritimId { get; set; }

    public int EstatOfertaId { get; set; }

    public DateOnly DataCreacio { get; set; }

    public DateOnly DataValidessaInicial { get; set; }

    public DateOnly? DataValidessaFina { get; set; }

    public string? RaoRebuig { get; set; }

    public int SolicitudId { get; set; }

    public int? DocumentsId { get; set; }

    public DateTime? Etd { get; set; }

    public DateTime? Eta { get; set; }

    public int? TransportistaDestinoId { get; set; }

    public int? OperadorId { get; set; }

    public bool? Acceptat { get; set; }

    public bool? Vist { get; set; }

    public bool? Acabat { get; set; }

    public bool? Cancelat { get; set; }

    public int? TipusGrupCarregaId { get; set; }

    public virtual Usuari AgentComercial { get; set; } = null!;

    public virtual Document? Documents { get; set; }

    public virtual EstatsOferte EstatOferta { get; set; } = null!;

    public virtual LiniesTransportMaritim? LiniaTransportMaritim { get; set; }

    public virtual Usuari? Operador { get; set; }

    public virtual Port? PortDesti { get; set; }

    public virtual Port? PortOrigen { get; set; }

    public virtual Solicitud Solicitud { get; set; } = null!;

    public virtual TipusGrupCarrega? TipusGrupCarrega { get; set; }

    public virtual TipusTransport TipusTransport { get; set; } = null!;

    public virtual TipusValidacion TipusValidacio { get; set; } = null!;

    public virtual Transportiste? TransportistaDestino { get; set; }

    public virtual Transportiste TransportistaOrigen { get; set; } = null!;
}
