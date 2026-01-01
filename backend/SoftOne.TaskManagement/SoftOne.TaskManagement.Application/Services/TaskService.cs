using SoftOne.TaskManagement.Application.DTOs;
using SoftOne.TaskManagement.Domain.Entities;
using SoftOne.TaskManagement.Domain.Interfaces;

namespace SoftOne.TaskManagement.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TaskItem>> GetTasksAsync()
            => _repository.GetAllAsync();

        public Task<TaskItem?> GetTaskAsync(int id)
            => _repository.GetByIdAsync(id);

        public async Task AddTaskAsync(TaskItem task)
        {
            task.CreatedAt = DateTime.UtcNow;
            await _repository.AddAsync(task);
        }

        public Task UpdateTaskAsync(TaskItem task)
            => _repository.UpdateAsync(task);

        public Task DeleteTaskAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<IEnumerable<TaskItem>> GetTasksAsync(TaskQueryDto query)
        {
            return _repository.GetAsync(
                query.IsCompleted,
                query.SortBy,
                query.Desc);
        }

    }
}