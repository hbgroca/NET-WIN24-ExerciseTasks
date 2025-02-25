using Business.Interfaces;
using Business.Models;
using Business.Services;

namespace OvningsUppgift4Csharp;

public class Program
{
    static void Main(string[] args)
    {
        IUserService userService = new UserService();
        do
        {
            Console.Clear();

            Console.WriteLine("--------- MENU ----------");
            Console.WriteLine("");
            Console.WriteLine("[1] Add new user");
            Console.WriteLine("[2] Find user by id");
            Console.WriteLine("[3] View all users");
            Console.WriteLine("");
            Console.WriteLine("---------- END ----------");

            switch (Console.ReadKey().KeyChar.ToString())
            {
                case "1":
                    {
                        // Instanciate new empty user.
                        UserBase user;

                        Console.Clear();
                        Console.WriteLine("--------- ADD ----------");
                        Console.WriteLine("");
                        Console.WriteLine("[1] Admin");
                        Console.WriteLine("[2] Regular");
                        Console.WriteLine("");
                        Console.Write("Select: ");
                        switch (Console.ReadKey().KeyChar.ToString())
                        {
                            case "1":
                                {
                                    user = new AdminUser();
                                    break;
                                }
                            default:
                                {
                                    user = new RegularUser();
                                    break;
                                }
                        }
                        Console.Write("\n");
                        Console.Write("Name: ");
                        // Set name
                        user.Name = Console.ReadLine()!;
                        // set id
                        user.Id = userService.GetUserCount();
                        // add user to user list
                        userService.AddUser(user);

                        Console.WriteLine($"Added an {user.GetRole()} with name {user.Name} and id {user.Id}");
                        Thread.Sleep(1500);

                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        Console.WriteLine("------- GET USER -------");
                        Console.WriteLine("");
                        Console.Write("Find id: ");

                        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int index))
                        {
                            Console.Write("\n");
                            // Get users by id
                            var user = userService.GetUserById(index);

                            if(user == null) {
                                Console.WriteLine($"User not found, returning to main menu");
                                Thread.Sleep(1500);
                                break;
                            }

                            Console.WriteLine("");
                            Console.WriteLine($"ID: {user.Id}");
                            Console.WriteLine($" Roll: {user.GetRole()}");
                            Console.WriteLine($" Name: {user.Name}");

                            Console.WriteLine("");
                            Console.ReadKey();
                        }
                        break;
                    }
                case "3":
                    {
                        // Get users
                        var users = userService.GetAllUsers();
                        // If null or 0 then return to main menu
                        if(users == null || users.Count == 0)
                        {
                            Console.WriteLine($"No users in list, returning");
                            Thread.Sleep(1500);
                            break;
                        }

                        // Render all users
                        Console.Clear();
                        Console.WriteLine("------- ALL USERS -------");
                        foreach (var user in users)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"ID: {user.Id}");
                            Console.WriteLine($" Roll: {user.GetRole()}");
                            Console.WriteLine($" Name: {user.Name}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    }
            }

        }while (true);

    }
}
