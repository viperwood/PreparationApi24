using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Diagnostic
{
    public int Diagnosticid { get; set; }

    public int Tipeeventid { get; set; }

    public string Diagnosticname { get; set; } = null!;

    public int Medialcardid { get; set; }

    public int Doctor { get; set; }

    public DateTime Datadiagnostic { get; set; }

    public virtual User DoctorNavigation { get; set; } = null!;

    public virtual Medialcard Medialcard { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual TypeEvent Tipeevent { get; set; } = null!;
}
