using Business.Dtos;
using Business.Models;

namespace WebApp.Models;

public class ToDoViewModel
{
    public IEnumerable<ToDoModel> toDoModels { get; set; } = new List<ToDoModel>();
    public ToDoRegistrationForm toDoRegistrationForm { get; set; } = new ToDoRegistrationForm();
}
