using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ToDo.Web.Controllers;
using ToDo.Web.Data;
using ToDo.Web.Models;
using ToDo.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ToDo.Web.Test
{
    public class HomeControllerTest
    {
        // Source: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing
        [Fact]
        public async Task IndexViewSuccessTest()
        {
            var mockRepo = new Mock<ITasksRepository>();
            mockRepo.Setup(repo => repo.ListAsync()).Returns(Task.FromResult(GetTestTasks()));
            var controller = new HomeController(mockRepo.Object);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.AllTasks.Count());
        }

        private List<TaskItem> GetTestTasks()
        {
            var tasks = new List<TaskItem>();

            tasks.Add(new TaskItem
            {
                TaskId = 1,
                Description = "Some Test Task",
                DateCreated = DateTime.Now,
                IsCompleted = false
            });

            tasks.Add(new TaskItem
            {
                TaskId = 2,
                Description = "Some Other Test Task",
                DateCreated = DateTime.Now,
                IsCompleted = false
            });

            return tasks;
        }
    }
}
