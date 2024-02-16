using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Room
{
    public int Idroom { get; set; }

    public string Roomname { get; set; } = null!;

    public int? Countbed { get; set; }

    public virtual ICollection<Bedoccupancy> Bedoccupancies { get; set; } = new List<Bedoccupancy>();
}
