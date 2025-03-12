
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ToDoFactory
{
    public static ToDoEntity Create(ToDoRegistrationForm toDo)
    {
        return new ToDoEntity
        {
            Title = toDo.Title,
        };
    }

    public static ToDoModel Create(ToDoEntity toDo)
    {
        return new ToDoModel
        {
            Id = toDo.Id,
            Title = toDo.Title,
            IsCompleted = toDo.IsCompleted,
        };
    }

    public static ToDoEntity Create(ToDoModel model)
    {
        return new ToDoEntity
        {
            Id = model.Id,
            Title = model.Title,
            IsCompleted = model.IsCompleted,
        };
    }
}
