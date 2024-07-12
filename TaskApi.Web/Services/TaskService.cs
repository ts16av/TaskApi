using TaskApi.Application.Interfaces;
using TaskApi.Domain.Entities;
using TaskApi.Domain.Enums;
using TaskApi.Domain.Interfaces;

namespace TaskApi.Web.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public async Task<Guid> CreateTaskAsync()
    {
        var taskId = await _taskRepository.CreateTaskAsync();
        _ = UpdateTaskStatusAsync(taskId);
        return taskId;
    }

    public async Task<TaskItem?> GetTaskAsync(Guid id)
    {
        return await _taskRepository.GetTaskAsync(id);
    }
    
    private async Task UpdateTaskStatusAsync(Guid taskId)
    {
        await _taskRepository.UpdateTaskStatusAsync(taskId, TaskStatusEnum.Running);
        await Task.Delay(TimeSpan.FromMinutes(2));
        await _taskRepository.UpdateTaskStatusAsync(taskId, TaskStatusEnum.Finished);
    }
}