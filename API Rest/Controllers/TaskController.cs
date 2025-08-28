using _tarea_1b.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Xml.Linq;

namespace _tarea_1b.Controllers
{
  [ApiController]
  [Route("api/tasks")]
  public class TaskController : ControllerBase
  {
    private readonly ILogger<TaskController> _logger;
    private Dictionary<int, TaskModel> _tasksDict;

    public TaskController(ILogger<TaskController> logger)
    {
      this._logger = logger;

      this._tasksDict = new Dictionary<int, TaskModel>();
      this._tasksDict[1] = new TaskModel(1, "Task 1", "Description 1", 3, "Alice", new DateOnly(2025, 10, 31));
      this._tasksDict[2] = new TaskModel(2, "Task 2", "Description 2", 1, "Bob", new DateOnly(2025, 11, 15));
      this._tasksDict[3] = new TaskModel(3, "Task 3", "Description 3", 4, "Charlie", new DateOnly(2025, 12, 1));
    }

    [HttpGet] // GET: api/tasks
    public ActionResult<IEnumerable<TaskModel>> GetAllTasks()
    {
      return Ok(_tasksDict);
    }

    [HttpGet("{id}")] // GET: api/tasks/{id}
    public ActionResult<TaskModel> GetTaskById(int id)
    {
      if (_tasksDict.ContainsKey(id))
      {
        _logger.LogInformation($"Get task with id {id}");
        var task = _tasksDict[id];
        return Ok(task);
      }

      _logger.LogInformation($"Task with id {id} not found");
      return NotFound();
    }

    [HttpPost] // POST: api/tasks
    public ActionResult New([FromBody] TaskModel task)
    {
      if (_tasksDict.ContainsKey(task.Id))
      {
        _logger.LogInformation($"Task with id {task.Id} already exists");
        return Conflict($"Task with id {task.Id} already exists");
      }

      _logger.LogInformation($"New task received: {task.Name}");
      this._tasksDict.Add(task.Id, task);
      return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")] // PUT: api/tasks/{id}
    public ActionResult Update(int id, [FromBody] TaskModel updatedTask)
    {
      var task = _tasksDict.GetValueOrDefault(id);
      if (task == null)
      {
        _logger.LogInformation($"Task with id {id} not found");
        return NotFound();
      }

      _logger.LogInformation($"Update task with id {id}");
      task.Name = updatedTask.Name;
      task.Description = updatedTask.Description;
      task.Duration = updatedTask.Duration;
      task.Responsible = updatedTask.Responsible;
      task.DueDate = updatedTask.DueDate;

      return Ok(task);
    }

    [HttpDelete("{id}")] // DELETE: api/tasks/{id}
    public ActionResult Delete(int id)
    {
      var task = _tasksDict.GetValueOrDefault(id);
      if (task == null)
      {
        _logger.LogInformation($"Task with id {id} not found");
        return NotFound();
      }

      _logger.LogInformation($"Delete task with id {id}");
      this._tasksDict.Remove(id);
      return Ok();
    }
  }
}