using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using TaskApi.Domain.Interfaces;

namespace TaskApi.Web.Controllers;

[Route("api/task")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask()
    {
        var guid = await _taskService.CreateTaskAsync();
        return Accepted(guid);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask([FromRoute] string id)
    {
        if (!Guid.TryParse(id, out var guid))
        {
            return BadRequest();
        }

        var task = await _taskService.GetTaskAsync(guid);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task.Status.GetDisplayName());
    }
}