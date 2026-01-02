using FluentAssertions;
using Moq;
using SoftOne.TaskManagement.Application.Services;
using SoftOne.TaskManagement.Domain.Entities;
using SoftOne.TaskManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Tests.Services
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _repoMock;
        private readonly TaskService _service;

        public TaskServiceTests()
        {
            _repoMock = new Mock<ITaskRepository>();
            _service = new TaskService(_repoMock.Object);
        }

        [Fact]
        public async Task AddTaskAsync_ShouldCallRepositoryAdd()
        {
            var task = new TaskItem { Title = "Test Task" };

            await _service.AddTaskAsync(task);

            _repoMock.Verify(x => x.AddAsync(task), Times.Once);
        }

        [Fact]
        public async Task GetTasksAsync_ShouldReturnTasks()
        {
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "Task 1" },
                new TaskItem { Id = 2, Title = "Task 2" }
            };

            _repoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(tasks);

            var result = await _service.GetTasksAsync();

            result.Should().HaveCount(2);
            result.Should().ContainSingle(t => t.Id == 1);
        }

        [Fact]
        public async Task GetTaskAsync_ShouldReturnTask_WhenExists()
        {
            var task = new TaskItem { Id = 1, Title = "Task 1" };
            _repoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(task);

            var result = await _service.GetTaskAsync(1);

            result.Should().NotBeNull();
            result!.Id.Should().Be(1);
        }

        [Fact]
        public async Task DeleteTaskAsync_ShouldCallRepositoryDelete()
        {
            await _service.DeleteTaskAsync(1);

            _repoMock.Verify(x => x.DeleteAsync(1), Times.Once);
        }
    }
}
