using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Diagnosis
{
    public int Diagnosisid { get; set; }

    public string Diagnosisname { get; set; } = null!;

    public virtual ICollection<Medialcard> Medialcards { get; set; } = new List<Medialcard>();
}
