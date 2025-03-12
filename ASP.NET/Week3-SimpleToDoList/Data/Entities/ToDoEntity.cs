namespace Data.Entities
{
    public class ToDoEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}
