using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Application.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<bool> ValidateAsync(string username, string password);
    }
}
