using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Result
{
    public int Resultsid { get; set; }

    public string Description { get; set; } = null!;

    public int Diagnosis { get; set; }

    public virtual Diagnostic DiagnosisNavigation { get; set; } = null!;

    public virtual ICollection<Prescribedmedication> Prescribedmedications { get; set; } = new List<Prescribedmedication>();
}
