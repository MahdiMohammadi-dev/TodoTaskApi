namespace Todo.Domain.Models;

public class TaskEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsCompleted { get; set; }

    public TaskEntity()
    {
        CreationDate = DateTime.Now;
    }
}