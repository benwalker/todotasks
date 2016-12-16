//-----------------------------------------------------------------------
// <copyright file="InMemoryTodoRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace TodoTasks.Storage
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using TodoTasks.Storage.Models;

    /// <summary>
    ///  The InMemoryTodoRespository.
    /// </summary>
    /// <seealso cref="TodoTasks.Storage.IRepository{TodoTasks.Storage.Models.Todo}" />
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public class InMemoryTodoRepository : IRepository<Todo>
    {
        /// <summary>
        /// The concurrent dictionary of todos.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        private ConcurrentDictionary<int, Todo> todos = new ConcurrentDictionary<int, Todo>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryTodoRepository"/> class.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        public InMemoryTodoRepository(IRepository<Task> taskRepository)
        {
            this.Seed(taskRepository);
        }

        /// <summary>
        /// Adds the specified todo item.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>The id of the added todo.</returns>
        public int Add(Todo t)
        {
            this.todos.TryAdd(t.Id, t);
            return t.Id;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>All todo items.</returns>
        public IList<Todo> All()
        {
            return this.todos.Values.ToList();
        }

        /// <summary>
        /// Finds the specified todo item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A todo item.</returns>
        public Todo Find(int id)
        {
            var x = this.todos.SingleOrDefault(t => t.Key == id);
            return x.Value;
        }

        /// <summary>
        /// Seeds the specified task repository with todo items and tasks.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        private void Seed(IRepository<Task> taskRepository)
        {
            var todo1 = new Todo(taskRepository)
            {
                Id = 1,
                Name = "Todo1",
            };

            todo1.Tasks.Add(new Models.Task
            {
                Id = 1,
                Name = "Todo1Task1",
                TodoId = todo1.Id
            });

            todo1.Tasks.Add(new Models.Task
            {
                Id = 2,
                Name = "Todo1Task2",
                TodoId = todo1.Id
            });

            this.todos.TryAdd(todo1.Id, todo1);

            var todo2 = new Todo(taskRepository)
            {
                Id = 2,
                Name = "Todo2",
            };

            todo2.Tasks.Add(new Models.Task
            {
                Id = 3,
                Name = "Todo2Task3",
                TodoId = todo2.Id
            });

            todo2.Tasks.Add(new Models.Task
            {
                Id = 4,
                Name = "Todo2Task4",
                TodoId = todo2.Id
            });

            this.todos.TryAdd(todo2.Id, todo2);
        }
    }
}
