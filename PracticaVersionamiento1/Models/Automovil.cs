using System;
using System.Collections.Generic;

namespace PracticaVersionamiento1.Models;

public partial class Automovil
{
    public int IdAutomovil { get; set; }

    public string? Modelo { get; set; }

    public string? Defecto { get; set; }

    public string? Placas { get; set; }

    public int? IdEntregan { get; set; }

    public virtual ICollection<Entregan> Entregans { get; set; } = new List<Entregan>();

    public virtual Entregan? IdEntreganNavigation { get; set; }
}
