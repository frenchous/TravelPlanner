using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TravelPlanner;
using TravelPlannerTests;

namespace TravelPlannerTests
{
    [TestClass]
    public class TripTaskTests
    {
        [TestMethod]
        public void TripTask_Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var dueDate = DateTime.Now.AddDays(5);

            // Act
            var task = new TripTask("Купить билеты", "Авиабилеты в Париж", dueDate, 3);

            // Assert
            Assert.AreEqual("Купить билеты", task.Title);
            Assert.AreEqual("Авиабилеты в Париж", task.Description);
            Assert.AreEqual(dueDate, task.DueDate);
            Assert.IsFalse(task.IsCompleted);
            Assert.AreEqual(3, task.ReminderDaysBefore);
        }

        [TestMethod]
        public void IsOverdue_DueDateInPast_ShouldReturnTrue()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(-1));

            // Act & Assert
            Assert.IsTrue(task.IsOverdue());
        }

        [TestMethod]
        public void IsOverdue_DueDateInFuture_ShouldReturnFalse()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(5));

            // Act & Assert
            Assert.IsFalse(task.IsOverdue());
        }

        [TestMethod]
        public void IsOverdue_CompletedTask_ShouldReturnFalse()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(-1));
            task.IsCompleted = true;

            // Act & Assert
            Assert.IsFalse(task.IsOverdue());
        }

        [TestMethod]
        public void ShouldNotify_DueInReminderWindow_ShouldReturnTrue()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(2), 3);

            // Act & Assert
            Assert.IsTrue(task.ShouldNotify());
        }

        [TestMethod]
        public void ShouldNotify_DueAfterReminderWindow_ShouldReturnFalse()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(5), 3);

            // Act & Assert
            Assert.IsFalse(task.ShouldNotify());
        }

        [TestMethod]
        public void ShouldNotify_CompletedTask_ShouldReturnFalse()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(1), 3);
            task.IsCompleted = true;

            // Act & Assert
            Assert.IsFalse(task.ShouldNotify());
        }

        [TestMethod]
        public void GetStatusString_OverdueTask_ShouldReturnOverdueMessage()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(-1));

            // Act
            var status = task.GetStatusString();

            // Assert
            StringAssert.Contains(status, "Просрочена");
        }

        [TestMethod]
        public void GetStatusString_CompletedTask_ShouldReturnCompletedMessage()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(5));
            task.IsCompleted = true;

            // Act
            var status = task.GetStatusString();

            // Assert
            StringAssert.Contains(status, "Выполнена");
        }

        [TestMethod]
        public void GetStatusString_UpcomingTask_ShouldReturnReminderMessage()
        {
            // Arrange
            var task = new TripTask("Задача", "Описание", DateTime.Now.AddDays(1), 3);

            // Act
            var status = task.GetStatusString();

            // Assert
            StringAssert.Contains(status, "Скоро");
        }

        [TestMethod]
        public void ToString_ShouldReturnFormattedString()
        {
            // Arrange
            var task = new TripTask("Купить билеты", "Париж", new DateTime(2026, 12, 25));

            // Act
            var result = task.ToString();

            // Assert
            StringAssert.Contains(result, "Купить билеты");
            StringAssert.Contains(result, "Париж");
            StringAssert.Contains(result, "25.12.2026");
        }
    }
}