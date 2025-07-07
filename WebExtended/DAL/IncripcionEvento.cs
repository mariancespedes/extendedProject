using System;
using System.Collections.Generic;

namespace WebExtended.DAL;

public partial class IncripcionEvento
{
    public int? IdUsuario { get; set; }

    public int? IdEvento { get; set; }

    public virtual Evento? _evento { get; set; }

    public virtual Usuario? _usuario { get; set; }
}
