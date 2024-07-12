using System.ComponentModel.DataAnnotations;

namespace TaskApi.Domain.Enums;

public enum TaskStatusEnum : byte
{
    [Display(Name = "created")]
    Created = 1,
    [Display(Name = "running")]
    Running = 2,
    [Display(Name = "finished")]
    Finished = 3
}