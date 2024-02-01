using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Medication
{
    public int Medicationsid { get; set; }

    public string Medicationsname { get; set; } = null!;

    public virtual ICollection<Prescribedmedication> Prescribedmedications { get; set; } = new List<Prescribedmedication>();
}
