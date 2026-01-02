using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ValidateCredentialsAsync(string username, string password);
    }
}
