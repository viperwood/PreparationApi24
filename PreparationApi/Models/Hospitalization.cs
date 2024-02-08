using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Hospitalization
{
    public int Hospitalizationid { get; set; }

    public int? Patientid { get; set; }

    public int? Purposeid { get; set; }

    public int? Departmentid { get; set; }

    public int? Conditionsid { get; set; }

    public DateTime? Starthospital { get; set; }

    public int? Lengthhospitalization { get; set; }

    public int Code { get; set; }

    public bool Refusal { get; set; }

    public string? Cancellation { get; set; }

    public virtual Condition? Conditions { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Purpose? Purpose { get; set; }
}
