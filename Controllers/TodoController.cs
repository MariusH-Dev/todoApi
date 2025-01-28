using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // localhost:7197/api/Todo

        private readonly TodoContext _db;

        public TodoController(TodoContext context)
        {
            _db = context;
        }

        // Show all Tasks from DB in a List
        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks() => Ok(_db.Tasks.ToList());

        // Read Task vom DB
        [HttpGet("id")]
        public IActionResult GetTask(int id)
        {
            TaskItem taskfromDb = _db.Tasks.SingleOrDefault(taskfromDb => taskfromDb.Id == id);

            if (taskfromDb == null)
            {
                return NotFound();
            }

            return Ok(taskfromDb);
        }

        // Create a new Task
        [HttpPost]
        public IActionResult CreateTask(TaskItem task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        
    }
}
