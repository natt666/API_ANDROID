using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class Notificacione
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public bool? Visto { get; set; }

    public int? UsuariId { get; set; }

    public virtual Usuari? Usuari { get; set; }
}
