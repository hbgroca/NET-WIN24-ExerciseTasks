using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;
public interface IToDoServices
{
    Task<ToDoModel> Create(ToDoRegistrationForm toDo);
    Task Delete(int id);
    Task<IEnumerable<ToDoModel>> GetAll();
    Task<ToDoModel> Update(int id);
}