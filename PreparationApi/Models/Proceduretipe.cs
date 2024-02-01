using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Proceduretipe
{
    public int Procedureid { get; set; }

    public string Procedurename { get; set; } = null!;

    public virtual ICollection<Prescribedmedication> Prescribedmedications { get; set; } = new List<Prescribedmedication>();
}
