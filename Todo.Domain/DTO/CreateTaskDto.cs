using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.DTO;

public class CreateTaskDto
{
    [Required(ErrorMessage = "عنوان نباید خالی باشد")]
    public string Title { get; set; }
}