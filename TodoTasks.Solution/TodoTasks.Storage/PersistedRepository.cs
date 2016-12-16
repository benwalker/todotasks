namespace TodoTasks.Storage
{
    using System;
    using System.Collections.Generic;
    using TodoTasks.Storage.Models;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TodoTasks.Storage.IRepository{TodoTasks.Storage.Models.Todo}" />
    public class PersistedRepository : IRepository<Todo>
    {
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int Add(Todo t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<Todo> All()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Todo Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
