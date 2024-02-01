using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Gender
{
    public int Genderid { get; set; }

    public string Gendername { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
