using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.DTO;

public class UpdateTaskDto
{
    [Required(ErrorMessage = "عنوان نباید خالی باشد")]
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}