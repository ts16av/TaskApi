using TaskApi.Domain.Enums;

namespace TaskApi.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public TaskStatusEnum Status { get; set; }
}