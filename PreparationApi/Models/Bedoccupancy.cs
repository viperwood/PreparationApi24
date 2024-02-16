using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Bedoccupancy
{
    public int Id { get; set; }

    public int Idroom { get; set; }

    public int Bedid { get; set; }

    public int Patientsid { get; set; }

    public virtual Bedtipe Bed { get; set; } = null!;

    public virtual Room IdroomNavigation { get; set; } = null!;

    public virtual Patient1 Patients { get; set; } = null!;
}
