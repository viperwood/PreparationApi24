using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Patient1
{
    public int Idpatients { get; set; }

    public string Patientsname { get; set; } = null!;

    public virtual ICollection<Bedoccupancy> Bedoccupancies { get; set; } = new List<Bedoccupancy>();
}
