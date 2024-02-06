using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Purpose
{
    public int Purposeid { get; set; }

    public string Purposename { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();
}
