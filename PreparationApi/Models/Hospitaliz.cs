using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Hospitaliz
{
    public DateTime? Starthospital { get; set; }

    public string? Diagnosisname { get; set; }

    public int? Lengthhospitalization { get; set; }

    public int? Code { get; set; }

    public string? Conditionsname { get; set; }

    public string? Departmentname { get; set; }

    public string? Purposename { get; set; }

    public string? Fio { get; set; }
}
