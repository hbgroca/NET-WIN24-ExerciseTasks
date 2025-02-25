using Business.Dtos;
using Business.Interfaces;
using Business.Models;

namespace Presentation
{
    public class Dialogs(ICustomerServices customerServices) : IDialogs
    {
        private readonly ICustomerServices _customerServices = customerServices;


        public void ShowMainDialog()
        {
            Console.Clear();
            Console.WriteLine("--- MAIN MENU ---");
            Console.WriteLine("");
            Console.WriteLine("<1> - Add customer");
            Console.WriteLine("<2> - View customers");
            Console.WriteLine("<3> - Edit customer");
            Console.WriteLine("<4> - Delete customer");
            Console.Write("Select: ");
            var selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    {
                        CreateDialog();
                        break;
                    }
                case "2":
                    {
                        ViewCustomersDialog();
                        break;
                    }
                case "3":
                    {
                        EditCustomersDialog();
                        break;
                    }
                case "4":
                    {
                        DeleteCustomersDialog();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void CreateDialog()
        {
            var newCustomer = new CustomerRegistrationForm();

            Console.Clear();
            Console.WriteLine("--- ADD NEW CUSTOMER ---");
            Console.Write("First name: ");
            newCustomer.FirstName = Console.ReadLine()!;
            Console.Write("Last name: ");
            newCustomer.LastName = Console.ReadLine()!;
            Console.Write("Email adress: ");
            newCustomer.Email = Console.ReadLine()!;
            Console.Write("Phone number: ");
            newCustomer.PhoneNumber = Console.ReadLine()!;

            var result = _customerServices.CreateCustomerAsync(newCustomer);
            if (result != null)
            {
                Console.WriteLine("Customer was added successfully");
            }else
                Console.WriteLine("Something went wrong");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void ViewCustomersDialog()
        {
            var customers = _customerServices.GetAllCustomers();

            Console.Clear();
            Console.WriteLine("--- All CUSTOMERS ---");
            Console.WriteLine("");

            foreach (var customer in customers)
            {
                Console.WriteLine($"<{customer.Id}> {customer.FirstName} {customer.LastName} [{customer.Email}] [{customer.PhoneNumber}]");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void EditCustomersDialog()
        {
            var customers = _customerServices.GetAllCustomers();

            Console.Clear();
            Console.WriteLine("--- All CUSTOMERS ---");
            Console.WriteLine("");

            foreach (var customer in customers)
            {
                Console.WriteLine($"<{customer.Id}> {customer.FirstName} {customer.LastName} [{customer.Email}] [{customer.PhoneNumber}]");
            }

            Console.WriteLine("");
            Console.WriteLine("Select customer to edit (exit to go back): ");
            var selected = Console.ReadLine();

            switch (selected)
            {
                case "exit":
                    {
                        break;
                    }
                default:
                    {
                        int.TryParse(selected, out int parsed);
                        if (selected != null)
                        {
                            Customer selectedCustomer = customers.FirstOrDefault(x => x.Id == parsed)!;
                            if(selectedCustomer != null)
                            {
                                EditCustomer(selectedCustomer);
                            }
                        }
                        break;
                    }
            }
        }

        public void EditCustomer(Customer customer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- EDIT CUSTOMER ---");
                Console.WriteLine($"<1> First name: {customer.FirstName}");
                Console.WriteLine($"<2> Last name: {customer.LastName}");
                Console.WriteLine($"<3> Email adress: {customer.Email}");
                Console.WriteLine($"<4> Phone number: {customer.PhoneNumber}");

                Console.WriteLine("");
                Console.WriteLine("What part would you like to edit? (exit to leave)");

                var selected = Console.ReadLine();

                switch (selected)
                {
                    case "1":
                        {
                            Console.Write("New first name: ");
                            customer.FirstName = Console.ReadLine()!;
                            _customerServices.UpdateCustomer(customer);
                            break;
                        }
                    case "2":
                        {
                            Console.Write("New last name: ");
                            customer.LastName = Console.ReadLine()!;
                            _customerServices.UpdateCustomer(customer);
                            break;
                        }
                    case "3":
                        {
                            Console.Write("New email: ");
                            customer.Email = Console.ReadLine()!;
                            _customerServices.UpdateCustomer(customer);
                            break;
                        }
                    case "4":
                        {
                            Console.Write("New phonenumber: ");
                            customer.PhoneNumber = Console.ReadLine()!;
                            _customerServices.UpdateCustomer(customer);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                if (selected == "exit")
                {
                    break;
                }
            }
        }

        public void DeleteCustomersDialog()
        {
            var customers = _customerServices.GetAllCustomers();

            Console.Clear();
            Console.WriteLine("--- DELETE CUSTOMERS ---");
            Console.WriteLine("");

            foreach (var customer in customers)
            {
                Console.WriteLine($"<{customer.Id}> {customer.FirstName} {customer.LastName} [{customer.Email}] [{customer.PhoneNumber}]");
            }

            Console.WriteLine("");
            Console.WriteLine("Select customer to delete (exit to go back): ");
            var selected = Console.ReadLine();

            switch (selected)
            {
                case "exit":
                    {
                        break;
                    }
                default:
                    {
                        int.TryParse(selected, out int parsed);
                        if (selected != null)
                        {
                            Customer selectedCustomer = customers.FirstOrDefault(x => x.Id == parsed)!;
                            if (selectedCustomer != null)
                            {
                                _customerServices.DeleteCustomer(selectedCustomer);
                            }
                        }
                        Console.ReadKey();
                        break;
                    }
            }
        }
    }
}
