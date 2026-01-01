using SoftOne.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);

        Task<IEnumerable<TaskItem>> GetAsync(
    bool? isCompleted,
    string? sortBy,
    bool desc);
    }
}
