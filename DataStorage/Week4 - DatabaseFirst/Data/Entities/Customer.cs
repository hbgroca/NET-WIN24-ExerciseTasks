using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string? CompanyNr { get; set; }

    public string? CompanyName { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
