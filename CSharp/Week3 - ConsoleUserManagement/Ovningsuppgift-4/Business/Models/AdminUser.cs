namespace Business.Models;

// Admin user model that herits the methods and variables from UserBase model
public class AdminUser : UserBase
{
    string roll = "Admin";

    public override string GetRole()
    {
        return roll;
    }
}
