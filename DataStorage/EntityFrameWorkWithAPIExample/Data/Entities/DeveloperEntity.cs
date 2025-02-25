namespace Data.Entities;

public class DeveloperEntity
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly? StartedDate { get; set; }
    public DateOnly? EndedDate { get; set; }
}
