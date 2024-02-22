using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Directionschedule
{
    public int Id { get; set; }

    public string Namedirection { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
