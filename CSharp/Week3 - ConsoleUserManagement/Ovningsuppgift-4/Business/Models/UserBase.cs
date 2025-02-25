namespace Business.Models;

// Base user model
abstract public class UserBase
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public abstract string GetRole();
}
