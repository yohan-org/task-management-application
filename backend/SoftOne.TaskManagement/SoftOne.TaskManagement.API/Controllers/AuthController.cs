using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftOne.TaskManagement.Application.DTOs.AuthDTOs;
using SoftOne.TaskManagement.Application.Interfaces;

namespace SoftOne.TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var isValid = await _auth.ValidateAsync(request.Username, request.Password);
            return isValid ? Ok() : Unauthorized();
        }
    }
}
