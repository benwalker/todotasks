using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLibrary
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestInMemoryRepositoryAddNullGuard()
        {
            var repository = new TodoTasks.Storage.InMemoryTaskRepository();
            TodoTasks.Storage.Models.Task task = null;
            repository.Add(task);
        }

        [TestMethod]
        public void TestInMemoryRepositoryFind()
        {
            var repository = new TodoTasks.Storage.InMemoryTaskRepository();
            TodoTasks.Storage.Models.Task task = new TodoTasks.Storage.Models.Task();
            task.Id = 1;
            task.Name = "Task1";
            repository.Add(task);

            var expectedTask = repository.Find(1);

            Assert.AreEqual(expectedTask.Name, task.Name);
        }
    }
}
