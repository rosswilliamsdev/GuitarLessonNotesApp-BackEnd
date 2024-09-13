using Microsoft.AspNetCore.Mvc;
using GuitarLessonNotesApp.Data;
using GuitarLessonNotesApp.DTOs;
using GuitarLessonNotesApp.Models;
using GuitarLessonNotesApp.Helpers;
using System.Linq;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;
using System;

namespace GuitarLessonNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtTokenHelper _jwtTokenHelper;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ApplicationDbContext context, JwtTokenHelper jwtTokenHelper, ILogger<LoginController> logger)
        {
            _context = context;
            _jwtTokenHelper = jwtTokenHelper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

                if (user == null)
                {
                    _logger.LogWarning("Login attempt with invalid email: {Email}", request.Email);
                    return Unauthorized("Invalid email or password.");
                }

                try
                {
                    // Check password using BCrypt
                    if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                    {
                        _logger.LogWarning("Failed login attempt for user: {Email}", request.Email);
                        return Unauthorized("Invalid email or password.");
                    }
                }
                catch (BCrypt.Net.SaltParseException saltEx)
                {
                    _logger.LogError(saltEx, "Salt parsing error for user: {Email}. Error: {Message}", request.Email, saltEx.Message);
                    return StatusCode(500, "Password verification failed due to a salt parsing error.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error during password verification for user: {Email}. Error: {Message}", request.Email, ex.Message);
                    return StatusCode(500, "An unexpected error occurred during password verification.");
                }

                var token = _jwtTokenHelper.GenerateToken(user.Id.ToString(), user.Role);
                _logger.LogInformation("User logged in successfully: {Email}", user.Email);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during the login process: {Message}", ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
