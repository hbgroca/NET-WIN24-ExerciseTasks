using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? EmployeeId { get; set; }

    public int? CustomerId { get; set; }

    public int StatusId { get; set; }

    public int? ServiceId { get; set; }

    public decimal ServiceCost { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Service? Service { get; set; }

    public virtual StatusType Status { get; set; } = null!;
}
