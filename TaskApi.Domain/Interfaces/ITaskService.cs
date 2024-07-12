using TaskApi.Domain.Entities;

namespace TaskApi.Domain.Interfaces;

public interface ITaskService
{
    Task<Guid> CreateTaskAsync();
    Task<TaskItem?> GetTaskAsync(Guid id);
}