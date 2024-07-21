using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly InvoiceContext _context;
        public AuthController(InvoiceContext context, ITokenService tokenService)
        {           
            _context = context;
            _tokenService = tokenService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginModel)
        {
            try
            {
                var userList = _context.Users;
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == loginModel.Username);

                if (user == null || !VerifyPassword(loginModel.Password, user.Password))
                {
                    return Unauthorized(); // Return 401 Unauthorized if credentials are incorrect
                }

                string role = user.RoleName;
                var token = _tokenService.GenerateJwtToken(user.Username, role);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }

}

