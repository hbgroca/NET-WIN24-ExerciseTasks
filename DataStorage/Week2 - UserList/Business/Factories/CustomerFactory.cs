using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerRegistrationForm Create()
    {
        return new CustomerRegistrationForm();
    }

    public static CustomersEntity Create(CustomerRegistrationForm form)
    {
        var entity = new CustomersEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
        };
        return entity;
    }

    public static Customer Create(CustomersEntity entity)
    {
        var model = new Customer
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
        };
        return model;
    }

    public static CustomersEntity Create(Customer customer)
    {
        var entity = new CustomersEntity
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
        };
        return entity;
    }
}
