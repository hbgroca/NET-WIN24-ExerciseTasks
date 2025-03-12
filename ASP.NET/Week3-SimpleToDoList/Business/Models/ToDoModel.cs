namespace Business.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}
