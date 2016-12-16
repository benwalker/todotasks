//-----------------------------------------------------------------------
// <copyright file="Todo.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace TodoTasks.Storage.Models
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Todo item.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public class Todo
    {
        /// <summary>
        /// The task respository
        /// </summary>
        private IRepository<Task> taskRespository = new InMemoryTaskRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="Todo"/> class.
        /// </summary>
        /// <param name="taskRespository">The task respository.</param>
        public Todo(IRepository<Task> taskRespository)
        {
            this.taskRespository = taskRespository;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public IRepository<Task> Tasks
        {
            get { return this.taskRespository; }
        }
    }
}
