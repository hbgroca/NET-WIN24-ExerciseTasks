using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ToDoRepository(DataContext context) : IToDoRepository
{
    private readonly DataContext _context = context;

    // Create
    public async Task<ToDoEntity> Create(ToDoEntity entity)
    {
        _context.Todos.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    // Read
    public async Task<IEnumerable<ToDoEntity>> GetAll()
    {
        var result = await _context.Todos.ToListAsync();
        return result ?? [];
    }

    public async Task<ToDoEntity> GetOne(int id)
    {
        var result = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        if(result != null)
        {
            return result;
        }
        return null!;
    }

    // Update
    public async Task<int> Update(ToDoEntity entity)
    {
        _context.Todos.Update(entity);
        return await _context.SaveChangesAsync();
    }


    // Delete
    public async Task Delete(int id)
    {
        var entity = await _context.Todos.FindAsync(id);
        _context.Todos.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
