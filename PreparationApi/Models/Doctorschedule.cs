using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Doctorschedule
{
    public int Id { get; set; }

    public string Namrdoctor { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
