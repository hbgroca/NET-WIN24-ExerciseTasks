using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Service
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
