using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;


namespace TodoAPI.Controllers
{
    /// <summary>
    /// Controller for managing todo tasks.
    /// Provides endpoints to create, retrieve, update and delete tasks.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // localhost:7197/api/Todo

        private readonly TodoContext _taskDb;
        /// <summary>
        /// Constructor for TaskController
        /// Initializes the database context.
        /// </summary>
        /// <param name="context">TasksContext instance for database access.</param>
        public TodoController(TodoContext context) => _taskDb = context;
      

        /// <summary>
        /// Retrieves all tasks from the database.
        /// </summary>
        /// <returns>A list of all tasks</returns>
        /// <response code="200">Returns the list of tasks</response>
        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks() => Ok(_taskDb.Tasks.ToList());

        /// <summary>
        /// Retrieves a single Task by it's id.
        /// </summary>
        /// <param name="id">The id of the task to retrieve</param>
        /// <returns>The requested task</returns>
        /// <response code="200">Resturns the requested task</response>
        /// <response code="404">If the task is not found</response>
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTask(int id)
        {
            TaskItem taskfromDb = _taskDb.Tasks.SingleOrDefault(taskfromDb => taskfromDb.Id == id);

            return taskfromDb == null ? NotFound() : Ok(taskfromDb);
        }

        /// <summary>
        /// Creates a new task and saves it to the database.
        /// </summary>
        /// <param name="task">The task to be created</param>
        /// <returns>The created task</returns>
        /// <response code="201">Returns the newly created task</response>
        /// <response code="400">If the task data is invalid</response>
        [HttpPost]
        public ActionResult<TaskItem> CreateTask(TaskItem task)
        {
            _taskDb.Tasks.Add(task);
            _taskDb.SaveChanges();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        /// <summary>
        /// Updates an existing task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to update.</param>
        /// <param name="updatedTask">The updated task data.</param>
        /// <returns>Status code indicating the result.</returns>
        /// <response code="200">If the task was successfully updated.</response>
        /// <response code="404">If the task was not found.</response>
        [HttpPut("{id}")]
        public ActionResult<TaskItem> UpdateTask(int id, TaskItem updatedTask)
        {
            TaskItem taskFromDb = _taskDb.Tasks.SingleOrDefault(taskFromDb => taskFromDb.Id == id);
            
            // Return 404 when id not found
            if (taskFromDb == null) return NotFound();

            // update properties
            taskFromDb.Title = updatedTask.Title;
            taskFromDb.Description = updatedTask.Description;
            taskFromDb.DueTime = updatedTask.DueTime;
            taskFromDb.Priority = updatedTask.Priority; 
            taskFromDb.State = updatedTask.State;

            // save changes to Database
            _taskDb.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Deletes a task from the database.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>Status code indicating the result.</returns>
        /// <response code="200">If the task was successfully deleted.</response>
        /// <response code="404">If the task was not found.</response>
        // Delete TaskItem
        [HttpDelete]
        public ActionResult<TaskItem> DeleteTask(int id)
        {
            TaskItem taskToDelete = _taskDb.Tasks.SingleOrDefault(taskToDelete => taskToDelete.Id == id);
            if (taskToDelete == null) return NotFound();

            _taskDb.Tasks.Remove(taskToDelete);
            _taskDb.SaveChanges();

            return Ok();
        }
    }
}
