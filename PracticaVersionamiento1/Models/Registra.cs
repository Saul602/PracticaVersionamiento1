using System;
using System.Collections.Generic;

namespace PracticaVersionamiento1.Models;

public partial class Registra
{
    public int IdRegistro { get; set; }

    public DateTime? FechaHoraRegistro { get; set; }

    public string? Lugar { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdCliente { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
