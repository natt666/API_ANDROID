using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class Usuari
{
    public int Id { get; set; }

    public string Correu { get; set; } = null!;

    public string Contrasenya { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Cognoms { get; set; } = null!;

    public int RolId { get; set; }

    public int? PaisId { get; set; }

    public string? Empresa { get; set; }

    public string Dni { get; set; } = null!;

    public string? FotoUser { get; set; }

    public string? FotoDniFront { get; set; }

    public string? FotoDniBack { get; set; }

    public int? UsuariId { get; set; }

    public string? ClauAes { get; set; }

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Oferte> OferteAgentComercials { get; set; } = new List<Oferte>();

    public virtual ICollection<Oferte> OferteOperadors { get; set; } = new List<Oferte>();

    public virtual Paisso? Pais { get; set; }

    public virtual Rol Rol { get; set; } = null!;

    public virtual ICollection<Solicitud> SolicitudClients { get; set; } = new List<Solicitud>();

    public virtual ICollection<Solicitud> SolicitudOperadors { get; set; } = new List<Solicitud>();
}
