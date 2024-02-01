using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Medialcard
{
    public int Mcid { get; set; }

    public int Patientid { get; set; }

    public int Diagnosisid { get; set; }

    public DateTime Datanextvisit { get; set; }

    public DateTime Datalastvisit { get; set; }

    public virtual Diagnosis Diagnosis { get; set; } = null!;

    public virtual ICollection<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();

    public virtual Patient Patient { get; set; } = null!;
}
