using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Tipeevent
{
    public int Eventid { get; set; }

    public string Eventname { get; set; } = null!;

    public int Costevent { get; set; }

    public virtual ICollection<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();
}
