using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.Domain.Interfaces;
using SoftOne.TaskManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            return await _db.Users
                .AnyAsync(u => u.Username == username && u.Password == password);
        }
    }

}
