using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class UserService : IUserService
{
    // Create and new empty UsersBase list.
    public List<UserBase> Users = new();

    //public UserService()
    //{
    //    Users = GetAllUsers();
    //}

    // Add user
    public void AddUser(UserBase user)
    {
        // Adds incoming user to Users list
        Users.Add(user);
    }

    // Get user by ID
    public UserBase GetUserById(int id)
    {
        try
        {
            // Return the user with index as UserBase
            return Users[id];
        }
        catch (Exception ex) {
            Console.WriteLine($"Error while getting user: {ex.Message}");
            // Returns null value if something goes wrong.
            return null! ;
        }
    }

    // Get all users
    public List<UserBase> GetAllUsers()
    {
        // Return all users from Users list as an UserBase list
        return Users ;
    }

    // Get current user count
    public int GetUserCount()
    {
        // if Users is empty we return 0 as int
        if (Users == null) { 
            return 0 ;
        }
        // return user count as int
        return Users.Count;
    }
}
