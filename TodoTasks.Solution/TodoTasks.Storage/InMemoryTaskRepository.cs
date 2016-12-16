//-----------------------------------------------------------------------
// <copyright file="InMemoryTaskRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace TodoTasks.Storage
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using TodoTasks.Storage.Models;

    /// <summary>
    /// The InMemoryTaskRepository.
    /// </summary>
    /// <seealso cref="TodoTasks.Storage.IRepository{TodoTasks.Storage.Models.Task}" />
    public class InMemoryTaskRepository : IRepository<Task>
    {
        /// <summary>
        /// The concurrent dictionary of tasks.
        /// </summary>
        private ConcurrentDictionary<int, Models.Task> tasks = new ConcurrentDictionary<int, Task>();

        /// <summary>
        /// Adds the specified task.
        /// </summary>
        /// <param name="t">The task.</param>
        /// <returns>The id if the task added.</returns>
        public int Add(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            this.tasks.TryAdd(task.Id, task);
            return task.Id;
        }

        /// <summary>
        /// Returns all tasks.
        /// </summary>
        /// <returns>All tasks.</returns>
        public IList<Task> All()
        {
            return this.tasks.Values.ToList();
        }

        /// <summary>
        /// Finds the specified task.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task.</returns>
        public Task Find(int id)
        {
            return this.tasks.SingleOrDefault(t => t.Key == id).Value;
        }
    }
}
