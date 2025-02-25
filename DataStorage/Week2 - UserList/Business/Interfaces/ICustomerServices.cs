using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICustomerServices
    {
        Task<Customer> CreateCustomerAsync(CustomerRegistrationForm form);
        bool DeleteCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int Id);
        Task<Customer> GetCustomerByNameAsync(string firstname);
        bool UpdateCustomer(Customer customer);
    }
}