using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ToDoServices(IToDoRepository toDoRepository) : IToDoServices
{
    private readonly IToDoRepository _toDoRepository = toDoRepository;

    // Create
    public async Task<ToDoModel> Create(ToDoRegistrationForm toDo)
    {
        var entity = ToDoFactory.Create(toDo);
        var result = await _toDoRepository.Create(entity);
        var model = ToDoFactory.Create(result);

        return model;
    }

    // Read
    public async Task<IEnumerable<ToDoModel>> GetAll()
    {
        var entity = await _toDoRepository.GetAll();
        var modelList = entity.Select(ToDoFactory.Create);
        return modelList;
    }

    // Update
    public async Task<ToDoModel> Update(int id)
    {
        var entity = await _toDoRepository.GetOne(id);

        if (entity == null)
            return null!;

        entity.IsCompleted = !entity.IsCompleted;
        var result = await _toDoRepository.Update(entity);
        if (result == 0)
            return null!;

        return ToDoFactory.Create(entity);
    }

    // Delete
    public async Task Delete(int id)
    {
        await _toDoRepository.Delete(id);
    }
}
