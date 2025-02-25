using Business.Models;

namespace Business.Interfaces
{
    // Interface of UserService. Limits the user to see and use specific methods and variables.
    // Also acts as an contract that forces the class to have specific methods and variables as those specified below.
    public interface IUserService
    {
        public void AddUser(UserBase user);
        public List<UserBase> GetAllUsers();
        public UserBase GetUserById(int id);
        public int GetUserCount();
    }
}