using System;
using System.Collections.Generic;

namespace APICRUDDBfirst.Models;

public partial class Barco
{
    public long IdBarco { get; set; }

    public string? Nombre { get; set; }

    public long? Cuota { get; set; }

    public DateOnly? FechaSalida { get; set; }

    public DateOnly? FechaLlegada { get; set; }

    public long IdSocio { get; set; }

    public virtual Socio IdSocioNavigation { get; set; } = null;
}
