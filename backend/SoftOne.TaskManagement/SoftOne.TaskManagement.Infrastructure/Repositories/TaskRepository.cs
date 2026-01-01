using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.Domain.Entities;
using SoftOne.TaskManagement.Domain.Interfaces;
using SoftOne.TaskManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _db;

        public TaskRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
            => await _db.Tasks.AsNoTracking().ToListAsync();

        public async Task<TaskItem?> GetByIdAsync(int id)
            => await _db.Tasks.FindAsync(id);

        public async Task AddAsync(TaskItem task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null) return;

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
        }


        public async Task<IEnumerable<TaskItem>> GetAsync(
        bool? isCompleted,
        string? sortBy,
        bool desc)
        {
            IQueryable<TaskItem> query = _db.Tasks;

            if (isCompleted.HasValue)
                query = query.Where(t => t.IsCompleted == isCompleted);

            query = sortBy?.ToLower() switch
            {
                "title" => desc ? query.OrderByDescending(t => t.Title)
                                : query.OrderBy(t => t.Title),

                _ => desc ? query.OrderByDescending(t => t.CreatedAt)
                          : query.OrderBy(t => t.CreatedAt)
            };

            return await query.AsNoTracking().ToListAsync();
        }

    }
}