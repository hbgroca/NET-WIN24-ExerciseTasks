using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

// Force Email to be unique
[Index(nameof(Email), IsUnique = true)]
public class CustomersEntity
{
    [Key] public int Id { get; set; }
    [Required][Column(TypeName = "nvarchar(50)")] public string FirstName { get; set; } = null!;
    [Required][Column(TypeName = "nvarchar(50)")] public string LastName { get;set; } = null!;
    [Required][Column(TypeName = "nvarchar(200)")] public string Email { get; set; } = null!;
    [Required][Column(TypeName = "nvarchar(20)")] public string? PhoneNumber { get;set; }
}
