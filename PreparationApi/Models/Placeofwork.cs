using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Placeofwork
{
    public int Placeofworkid { get; set; }

    public string Placeofworkname { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
