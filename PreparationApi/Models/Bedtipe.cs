using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Bedtipe
{
    public int Idbed { get; set; }

    public string Bedname { get; set; } = null!;

    public virtual ICollection<Bedoccupancy> Bedoccupancies { get; set; } = new List<Bedoccupancy>();
}
