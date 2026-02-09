using Todo.Domain.DTO;
using Todo.Domain.Models;

namespace Todo.Domain.Repository;

public interface ITaskRepository
{
    Task<List<TaskEntity>> GetAllAsync();
    Task<TaskEntity?> GetByIdAsync(int id);
    Task<TaskEntity> CreateAsync(CreateTaskDto todo);
    Task<bool> UpdateAsync(int id, CreateTaskDto todo);
    Task<bool> DeleteAsync(int id);
}