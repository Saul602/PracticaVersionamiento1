using System;
using System.Collections.Generic;

namespace PracticaVersionamiento1.Models;

public partial class Entregan
{
    public int IdEntregan { get; set; }

    public int? IdCliente { get; set; }

    public int? IdAutomovil { get; set; }

    public virtual ICollection<Automovil> Automovils { get; set; } = new List<Automovil>();

    public virtual Automovil? IdAutomovilNavigation { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
