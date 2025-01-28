using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    /// <summary>
    /// API Controller for managing users.
    /// Provides endpoints to retrieve and create users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userDb;

        /// <summary>
        /// Constructor for UserController
        /// Initializes the database context
        /// </summary>
        /// <param name="context">UserContext instance for database access.</param>
        public UserController(UserContext context) => _userDb = context;

        /// <summary>
        /// Retrives all users from database.
        /// </summary>
        /// <returns>A list of users</returns>
        /// <response code="200">Returns the list of users</response>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers() => _userDb.Users.ToList();

        /// <summary>
        /// Create a new user in the database
        /// </summary>
        /// <param name="user">User object to be created</param>
        /// <returns>The created user</returns>
        /// <response code="201">Returns the newly created user</response>
        /// <responnse code="400">If the userdata is invalid</responnse>
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            _userDb.Users.Add(user);
            _userDb.SaveChanges();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
