using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerServices(ICustomerRepositories customerRepository) : ICustomerServices
{
    private readonly ICustomerRepositories _customerRepository = customerRepository;

    // Create new customer
    public async Task<Customer> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        // Check if product already exist
        var entity = await _customerRepository.GetAsync(x => x.Email == form.Email);
        // If already exist
        if (entity != null)
            return CustomerFactory.Create(entity);

        // If not exist then we create and map over using factory
        entity = await _customerRepository.CreateAsync(CustomerFactory.Create(form));
        // return customer as model
        if (entity != null)
            return CustomerFactory.Create(entity);

        return null!;
    }


    // Get list of all cusomers
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync();
        if (entities != null)
        {
            // return a list with customer models
            var customers = entities.Select(CustomerFactory.Create);
            return customers;
        }
        else
            return [];
    }
    public IEnumerable<Customer> GetAllCustomers()
    {
        var entities = _customerRepository.GetAll();
        if (entities != null)
        {
            // return a list with customer models
            var customers = entities.Select(CustomerFactory.Create);
            return customers;
        }
        else
            return [];
    }


    // Get customer by id
    public async Task<Customer> GetCustomerByIdAsync(int Id)
    {
        var entity = await _customerRepository.GetAsync(x => x.Id == Id);
        if (entity != null)
        {
            // return customer as model
            return CustomerFactory.Create(entity);
        }
        else
            return null!;
    }

    public async Task<Customer> GetCustomerByNameAsync(string firstname)
    {
        var entity = await _customerRepository.GetAsync(x => x.FirstName == firstname);
        if (entity != null)
        {
            // return customer as model
            return CustomerFactory.Create(entity);
        }
        else
            return null!;
    }

    public bool UpdateCustomer(Customer customer)
    {
        var updatedCustomerEntity = CustomerFactory.Create(customer);

        var result = _customerRepository.UpdateAsync(updatedCustomerEntity);
        if (result != null)
        {
            return true;
        }
        else
            return false;
    }

    public bool DeleteCustomer(Customer customer)
    {
        var CustomerEntity = CustomerFactory.Create(customer);
        var result = _customerRepository.DeleteAsync(CustomerEntity);
        if (result != null)
        {
            return true;
        }else
            return false;
    }
}
