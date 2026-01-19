using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawConnect.Api.API.Admin.RequestObject;
using PawConnect.Api.API.Admin.ResponseObject;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Api.API.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        // GET: api/admin/users
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return Ok(_mapper.Map<IEnumerable<AdminUserResponse>>(users));
        }

        // PATCH: api/admin/verify/{id}
        [HttpPatch("verify/{id}")]
        public async Task<IActionResult> Verify(Guid id)
        {
            var ok = await _adminService.VerifyUserAsync(id);
            if (!ok) return NotFound();

            return Ok("User verified");
        }

        // PATCH: api/admin/block/{id}
        [HttpPatch("block/{id}")]
        public async Task<IActionResult> Block(Guid id)
        {
            var ok = await _adminService.BlockUserAsync(id);
            if (!ok) return NotFound();

            return Ok("User blocked");
        }

        // PATCH: api/admin/unblock/{id}
        [HttpPatch("unblock/{id}")]
        public async Task<IActionResult> Unblock(Guid id)
        {
            var ok = await _adminService.UnblockUserAsync(id);
            if (!ok) return NotFound();

            return Ok("User unblocked");
        }
    }
}
