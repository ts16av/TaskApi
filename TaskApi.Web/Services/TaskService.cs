using TaskApi.Application.Interfaces;
using TaskApi.Domain.Entities;
using TaskApi.Domain.Enums;
using TaskApi.Domain.Interfaces;

namespace TaskApi.Web.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly TaskProcessingService _taskProcessingService;

    public TaskService(ITaskRepository taskRepository, TaskProcessingService taskProcessingService)
    {
        _taskRepository = taskRepository;
        _taskProcessingService = taskProcessingService;
    }
    
    public async Task<Guid> CreateTaskAsync()
    {
        var taskId = await _taskRepository.CreateTaskAsync();
        _ = _taskProcessingService.UpdateTaskStatusAsync(taskId);
        return taskId;
    }

    public async Task<TaskItem?> GetTaskAsync(Guid id)
    {
        return await _taskRepository.GetTaskAsync(id);
    }
}