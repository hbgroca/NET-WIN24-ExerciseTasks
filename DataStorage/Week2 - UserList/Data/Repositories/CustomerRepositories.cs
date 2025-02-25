using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerRepositories(DataContext context) : ICustomerRepositories
{
    private readonly DataContext _context = context;

    // Create
    public async Task<CustomersEntity> CreateAsync(CustomersEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            // Add to stage
            await _context.Customers.AddAsync(entity);
            // Save to DB
            await _context.SaveChangesAsync();
            // Return updated entity (If using auto incriment for id)
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR: There was an error while creating customer. " + ex.Message);
            return null!;
        }
    }


    // Read
    public async Task<IEnumerable<CustomersEntity>> GetAllAsync()
    {
        // return all customers in a list
        return await _context.Customers.ToListAsync();
    }

    public IEnumerable<CustomersEntity> GetAll()
    {
        // return all customers in a list
        return _context.Customers.ToList();
    }

    public async Task<CustomersEntity> GetAsync(Expression<Func<CustomersEntity, bool>> expression)
    {
        if (expression == null)
            return null!;
        // Return first result or null if not found.
        return await _context.Customers.FirstOrDefaultAsync(expression) ?? null!;
    }


    // Update
    public async Task<CustomersEntity> UpdateAsync(CustomersEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;
        try
        {
            // Find customer in db
            var existingProductEntity = await GetAsync(x => x.Id == updatedEntity.Id);
            if (existingProductEntity == null)
                return null!;

            // Update with new values and save to db
            _context.Entry(existingProductEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();

            return updatedEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR: There was an error while updating customer. " + ex.Message);
            return null!;
        }
    }


    // Delete
    public async Task<bool> DeleteAsync(CustomersEntity entity)
    {
        if (entity == null)
            return false;

        try
        {
            // Find customer in db
            var existingProductEntity = await GetAsync(x => x.Id == entity.Id);
            if (existingProductEntity == null)
                return false;

            // Remove customer and save to db
            _context.Customers.Remove(existingProductEntity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR: There was an error while deleting customer. " + ex.Message);
            return false;
        }
    }
}
