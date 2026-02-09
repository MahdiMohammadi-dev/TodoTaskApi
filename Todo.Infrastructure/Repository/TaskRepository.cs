using Microsoft.EntityFrameworkCore;
using Todo.Domain.DTO;
using Todo.Domain.Models;
using Todo.Domain.Repository;

namespace Todo.Infrastructure.Repository;

public class TaskRepository(AppDbContext context):ITaskRepository
{
    public async Task<List<TaskEntity>> GetAllAsync()
    {
        return await context.Tasks.ToListAsync();
    }

    public async Task<TaskEntity?> GetByIdAsync(int id)
    {
        return await context.Tasks.FindAsync(id);
    }

    public async Task<TaskEntity> CreateAsync(CreateTaskDto todo)
    {
        if (string.IsNullOrWhiteSpace(todo.Title))
            throw new NullReferenceException("عنوان نمیتواند خالی باشد");
        var entity = new TaskEntity()
        {
            Title = todo.Title,
            IsCompleted = false
        };

        context.Tasks.Add(entity);
        await context.SaveChangesAsync();
    }

    public Task<bool> UpdateAsync(int id, CreateTaskDto todo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}