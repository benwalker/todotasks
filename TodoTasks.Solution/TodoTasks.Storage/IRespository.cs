//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace TodoTasks.Storage
{
    using System.Collections.Generic;

    /// <summary>
    /// The IRepository interface.
    /// </summary>
    /// <typeparam name="T">The generic Type.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// All items of this instance.
        /// </summary>
        /// <returns>All items of type T.</returns>
        IList<T> All();

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An item of Type T.</returns>
        T Find(int id);

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>The id of the added item.</returns>
        int Add(T t);
    }
}
