using SoftOne.TaskManagement.Application.Interfaces;
using SoftOne.TaskManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ValidateAsync(string username, string password)
        {
            return await _userRepository.ValidateCredentialsAsync(username, password);
        }
    }

}
