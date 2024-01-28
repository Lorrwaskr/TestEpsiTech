using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TestEpsiTech.Models.DTOs;
using TestEpsiTech.Services.Interfaces.Services;

namespace TestEpsiTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITasksService tasksService, ILogger<TasksController> logger)
        {
            _tasksService = tasksService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDto model)
        {
            _logger.LogInformation("Received request to create a new task");

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Task created successfully");
                return CreatedAtAction(nameof(Create), await _tasksService.CreateTaskAsync(model));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the task");
                return StatusCode(500, "An error occurred while creating the task");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Received request to get task with id: {id}", id);

            try
            {
                var task = await _tasksService.GetTaskByIdAsync(id);

                if (task == null)
                {
                    _logger.LogWarning("Task with id {taskId} not found", id);
                    return NotFound(); 
                }

                _logger.LogInformation("Task with id {taskId} found", id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the task with id {taskId}", id);
                return StatusCode(500, "An error occurred while getting the task");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Received request to get all tasks");

            try
            {
                var tasks = await _tasksService.GetTasksAsync();

                if (tasks == null || !tasks.Any())
                {
                    _logger.LogWarning("No tasks found");
                    return NotFound();
                }

                _logger.LogInformation("Retrieved {taskCount} tasks", tasks.Count);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all tasks");
                return StatusCode(500, "An error occurred while getting all tasks");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TaskDto model)
        {
            _logger.LogInformation("Received request to update task with id: {id}", model.Id);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state");
                return BadRequest(ModelState);
            }

            try
            {
                var task = await _tasksService.UpdateTaskAsync(model);
                if (task == null)
                {
                    _logger.LogWarning("Task with id {id} not found", model.Id);
                    return NotFound();
                }

                _logger.LogInformation("Task with id {id} has been updated", model.Id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the task with id {taskId}", model.Id);
                return StatusCode(500, "An error occurred while updating the task");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Received request to delete task with id: {id}", id);

            try
            {
                var deletedTask = await _tasksService.DeleteTaskAsync(id);
                if (deletedTask == null)
                {
                    _logger.LogWarning("Task with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Task with id {id} has been deleted", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the task with id {taskId}", id);
                return StatusCode(500, "An error occurred while deleting the task");
            }
        }
    }
}
