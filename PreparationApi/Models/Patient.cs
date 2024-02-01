using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Patient
{
    public int Patientid { get; set; }

    public int Useridpatient { get; set; }

    public DateTime Dataissuemc { get; set; }

    public DateTime Dataexpirationinsurancepolisy { get; set; }

    public string Numberpolis { get; set; } = null!;

    public DateTime Policyvalidity { get; set; }

    public int Placeofworkid { get; set; }

    public int Insurancecompanyid { get; set; }

    public virtual Insurancecompany Insurancecompany { get; set; } = null!;

    public virtual ICollection<Medialcard> Medialcards { get; set; } = new List<Medialcard>();

    public virtual Placeofwork Placeofwork { get; set; } = null!;

    public virtual User UseridpatientNavigation { get; set; } = null!;
}
