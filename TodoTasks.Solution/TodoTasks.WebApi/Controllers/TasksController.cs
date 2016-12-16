//-----------------------------------------------------------------------
// <copyright file="TasksController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace TodoTasks.WebApi.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using TodoTasks.Storage;
    using TodoTasks.Storage.Models;
   
    /// <summary>
    /// The TasksController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class TasksController : Controller
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepository<Todo> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TasksController(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the specified todo item's tasks.
        /// </summary>
        /// <param name="todoId">The todo id.</param>
        /// <returns>The Tasks.</returns>
        [HttpGet("api/todos/{todoId:int}/[controller]")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        public IActionResult Get(int todoId)
        {
            var tasks = this.repository.Find(todoId).Tasks.All().Where(task => task.TodoId == todoId);
            return this.Ok(tasks);
        }

        /// <summary>
        /// Gets the specified todo item's task.
        /// </summary>
        /// <param name="todoId">The todoId.</param>
        /// <param name="taskId">The taskId.</param>
        /// <returns>A task and HTTP 200 or 400 if not found.</returns>
        [HttpGet("api/todos/{todoId:int}/[controller]/{taskId:int}", Name = "GetTask")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        public IActionResult Get(int todoId, int taskId)
        {
            var task = this.repository.Find(todoId).Tasks.All().Where(t => t.Id == taskId && t.TodoId == todoId);

            if (task == null)
            { 
                return this.NotFound();
            }
            else
            {
                return this.Ok(task);
            }
        }

        /// <summary>
        /// Creates a task.
        /// </summary>
        /// <param name="todoId">The todo identifier.</param>
        /// <param name="task">The task.</param>
        /// <returns>The url of the resource created and HTTP 201</returns>
        [HttpPost("api/todos/{todoId:int}/[controller]")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        public IActionResult Post(int todoId, [FromBody]Storage.Models.Task task)
        {
            this.repository.Find(todoId).Tasks.Add(task);
            return this.CreatedAtRoute("GetTask", new { controller = "Tasks", id = task.Id }, task);
        }
    }
}
