using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp;

namespace TestProject1
{
    public class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new WebApp.Task("Test Task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }
        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new WebApp.Task(" Task to delete ");
            _taskManager.AddTask(task);
            int initialTaskCount = _taskManager.GetTasks().Count;

            // Act
            _taskManager.RemoveTask(task.Id);

            // Assert
            Assert.AreEqual(initialTaskCount - 1, _taskManager.GetTasks().Count);
            Assert.AreEqual(false, _taskManager.GetTasks().Contains(task));
        }

        [Test]
        public void GetTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var task1 = new WebApp.Task("Task to get1");
            var task2 = new WebApp.Task("Task to get2");
            _taskManager.AddTask(task1);
            _taskManager.AddTask(task2);

            // Act
            List<WebApp.Task> tasks = _taskManager.GetTasks();

            // Assert
            Assert.Contains(task1, tasks);
            Assert.Contains(task2, tasks);
            Assert.AreEqual(2, tasks.Count);
        }
    }
}
