using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class User
{
    public int Userid { get; set; }

    public string? Foto { get; set; }

    public string Fio { get; set; } = null!;

    public int Numberp { get; set; }

    public int Seriesp { get; set; }

    public DateTime Birthday { get; set; }

    public int Gender { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Roleuser { get; set; }

    public virtual ICollection<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual Roletable RoleuserNavigation { get; set; } = null!;
}
