using System;
using System.Collections.Generic;

namespace WebExtended.DAL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Tipo { get; set; }

    public string? Email { get; set; }

    public DateOnly? FechaNacimiento { get; set; }
}
