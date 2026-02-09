using Microsoft.EntityFrameworkCore;
using Todo.Domain.DTO;
using Todo.Domain.Models;
using Todo.Domain.Repository;

namespace Todo.Infrastructure.Repository;

public class TaskRepository(AppDbContext context):ITaskRepository
{
    public async Task<List<TaskEntity>> GetAllAsync()
    {
        return await context.Tasks.Where(x=>x.IsCompleted!=true).ToListAsync();
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
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, CreateTaskDto todo)
    {
        var entity = await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return false;
        if (string.IsNullOrWhiteSpace(todo.Title))
            throw new NullReferenceException("عنوان نمیتواند خالی باشد");
        entity.Title = todo.Title;
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return false;
        entity.IsCompleted = true;
       await context.SaveChangesAsync();
       return true;
    }
}