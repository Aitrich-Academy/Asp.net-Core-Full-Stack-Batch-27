using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PawConnect.Api.API.Users.RequestObject;
using PawConnect.Api.API.Users.ResponseObject;
using PawConnect.Api.Services;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Api.API.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userService,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        // POST: api/Users/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _userService.GetByEmailAsync(request.Email);
            if (existing != null)
                return BadRequest("Email already exists.");

            var user = _mapper.Map<User>(request);

            // UserService handles hashing & saving
            user = await _userService.RegisterAsync(user, request.Password);

            return Ok("Registration successful.");
        }

        // POST: api/Users/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.ValidateUserAsync(request.Email, request.Password);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            var token = _tokenService.GenerateToken(user, out var expiresAt);

            var response = _mapper.Map<LoginResponse>(user);
            response.Token = token;
            response.ExpiresAt = expiresAt;

            return Ok(response);
        }

        // GET: api/Users/me
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim);
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
                return NotFound();

            var response = _mapper.Map<UserResponse>(user);

            return Ok(response);
        }

        // (Later we can add: GET all users [Admin], Update, Delete, etc.)
    }
}
