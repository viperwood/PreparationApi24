using System;
using System.Collections.Generic;

namespace PreparationApi.Models;

public partial class Roletable
{
    public int Roleid { get; set; }

    public string Rolename { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
