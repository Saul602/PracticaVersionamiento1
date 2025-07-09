using System;
using System.Collections.Generic;

namespace PracticaVersionamiento1.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Email { get; set; }

    public int? Edad { get; set; }

    public virtual ICollection<Registra> Registras { get; set; } = new List<Registra>();
}
