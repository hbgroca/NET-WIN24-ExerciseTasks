using Data.Entities;

namespace Data.Interfaces;
public interface IToDoRepository
{
    Task<ToDoEntity> Create(ToDoEntity entity);
    Task Delete(int id);
    Task<IEnumerable<ToDoEntity>> GetAll();
    Task<ToDoEntity> GetOne(int id);
    Task<int> Update(ToDoEntity entity);
}