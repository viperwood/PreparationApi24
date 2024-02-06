using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Condition
{
    public int Conditionsid { get; set; }

    public string Conditionsname { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();
}
