using System;
using System.Collections.Generic;

namespace WebExtended.DAL;

public partial class Evento
{
    public int IdEvento { get; set; }

    public string? NombreEvento { get; set; }

    public DateOnly? Fechaevento { get; set; }

    public int? Cupo { get; set; }

    public decimal? Precio { get; set; }

    public string? Detalle { get; set; }
}
