using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Insurancecompany
{
    public int Insurancecompanyid { get; set; }

    public string Insurancecompanyname { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
