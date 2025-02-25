namespace Business.Models;

// Regular user model that herits the methods and variables from UserBase model
public class RegularUser : UserBase
{
    string roll = "Regular";

    public override string GetRole()
    {
        return roll;
    }
}
