using TaskApi.Application.Interfaces;
using TaskApi.Domain.Enums;

namespace TaskApi.Web.Services;

public class TaskProcessingService(IServiceProvider serviceProvider) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public async Task UpdateTaskStatusAsync(Guid taskId)
    {
        using var scope = serviceProvider.CreateScope();
        var taskRepository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
        await taskRepository.UpdateTaskStatusAsync(taskId, TaskStatusEnum.Running);
        await Task.Delay(TimeSpan.FromMinutes(2));
        await taskRepository.UpdateTaskStatusAsync(taskId, TaskStatusEnum.Finished);
    }
}