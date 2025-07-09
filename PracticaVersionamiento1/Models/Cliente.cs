using System;
using System.Collections.Generic;

namespace PracticaVersionamiento1.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public int? Edad { get; set; }

    public string? Email { get; set; }

    public int? IdRegistro { get; set; }

    public virtual ICollection<Entregan> Entregans { get; set; } = new List<Entregan>();

    public virtual Registra? IdRegistroNavigation { get; set; }

    public virtual ICollection<Registra> Registras { get; set; } = new List<Registra>();
}
