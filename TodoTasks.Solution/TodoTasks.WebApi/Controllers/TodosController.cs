//-----------------------------------------------------------------------
// <copyright file="TodosController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace TodoTasks.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Mvc;
    using TodoTasks.Storage;
    using TodoTasks.Storage.Models;
    
    /// <summary>
    /// The TodosController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public class TodosController : Controller
    {
        /// <summary>
        /// The todo repository.
        /// </summary>
        private IRepository<Todo> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodosController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TodosController(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets all todo items.
        /// </summary>
        /// <returns>A list of Todo items.</returns>
        [HttpGet]
        public IEnumerable<Todo> Get() => this.repository.All();

        /// <summary>
        /// Gets a todo item.
        /// </summary>
        /// <param name="id">The id of the todo item to get.</param>
        /// <returns>A todo item.</returns>
        [HttpGet("{id:int}", Name = "GetTodo")]
        public IActionResult Get(int id)
        {
            Todo todo = this.repository.Find(id);

            if (todo == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(todo);
            }
        }

        /// <summary>
        /// Creates a todo item.
        /// </summary>
        /// <param name="todo">The todo item.</param>
        /// <returns>The url of the resource created and HTTP 201.</returns>
        [HttpPost]
        public IActionResult Create([FromBody]Todo todo)
        {
            this.repository.Add(todo);
            return this.CreatedAtRoute("GetTodo", new { controller = "Todos", id = todo.Id }, todo);
        }
    }
}
