using Data.Enteties;
using Data.Interfaces;
using Data.Repositories;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository();

            UserEntity entity = new UserEntity();

            Console.Write("First name:");
            entity.FirstName = Console.ReadLine()!;

            Console.Write("Last name:");
            entity.LastName = Console.ReadLine()!;

            Console.Write("Email:");
            entity.Email = Console.ReadLine()!;

            Console.Write("Phone number:");
            entity.PhoneNumber = Console.ReadLine()!;

            var result = userRepository.Create(entity);
            if (result)
            {
                Console.WriteLine("User was added successfully");
            }
            else
                Console.WriteLine("Something went sideways!");

            Console.ReadKey();


            var userlist = userRepository.GetAll();

            foreach (var user in userlist)
            {
                Console.WriteLine($" #{user.Id} {user.FirstName} {user.LastName} <{user.Email}><{user.PhoneNumber}>");
            }
            Console.ReadKey();
        }
    }
}
