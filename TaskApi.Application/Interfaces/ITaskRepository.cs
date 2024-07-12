using TaskApi.Domain.Entities;
using TaskApi.Domain.Enums;

namespace TaskApi.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetTaskAsync(Guid id);
    Task<Guid> CreateTaskAsync();
    Task UpdateTaskStatusAsync(Guid id, TaskStatusEnum status);
}