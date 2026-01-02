using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<User> Users => Set<User>();
    }
}
