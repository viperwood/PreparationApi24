using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public int? Doctor { get; set; }

    public DateTime Timeschedule { get; set; }

    public int? Direction { get; set; }

    public virtual Directionschedule? DirectionNavigation { get; set; }

    public virtual Doctorschedule? DoctorNavigation { get; set; }
}
