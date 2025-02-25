using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class StatusType
{
    public int Id { get; set; }

    public string StatusDescription { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
