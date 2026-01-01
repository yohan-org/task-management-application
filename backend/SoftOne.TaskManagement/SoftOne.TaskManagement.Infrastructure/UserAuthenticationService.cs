using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.Application.Interfaces;
using SoftOne.TaskManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Infrastructure
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly AppDbContext _db;

        public UserAuthenticationService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> ValidateAsync(string username, string password)
        {
            return await _db.Users
                .AsNoTracking()
                .AnyAsync(u => u.Username == username && u.Password == password);
        }
    }
}
