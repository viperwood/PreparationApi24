using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Prescribedmedication
{
    public int Pmid { get; set; }

    public int Madicationsid { get; set; }

    public int Resultpmid { get; set; }

    public int Procedureid { get; set; }

    public virtual Medication Madications { get; set; } = null!;

    public virtual Proceduretipe Procedure { get; set; } = null!;

    public virtual Result Resultpm { get; set; } = null!;
}
