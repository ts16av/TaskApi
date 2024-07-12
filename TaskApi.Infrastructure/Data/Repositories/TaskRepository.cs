using TaskApi.Application.Interfaces;
using TaskApi.Domain.Entities;
using TaskApi.Domain.Enums;

namespace TaskApi.Infrastructure.Data.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskApiDbContext _context;

    public TaskRepository(TaskApiDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem?> GetTaskAsync(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Guid> CreateTaskAsync()
    {
        var task = new TaskItem
        {
            CreatedAt = DateTime.UtcNow,
            Status = TaskStatusEnum.Created
        };
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }

    public async Task UpdateTaskStatusAsync(Guid id, TaskStatusEnum status)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task != null)
        {
            task.Status = status;
            task.CreatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}