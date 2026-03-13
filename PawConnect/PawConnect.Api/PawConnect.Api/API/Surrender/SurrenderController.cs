using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawConnect.Api.API.Surrender.RequestObject;
using PawConnect.Api.API.Surrender.ResponseObject;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Services.Interfaces;
using System.Security.Claims;

namespace PawConnect.Api.API.Surrender
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SurrenderController : ControllerBase
    {
        private readonly ISurrenderService _surrenderService;
        private readonly IMapper _mapper;

        public SurrenderController(ISurrenderService surrenderService, IMapper mapper)
        {
            _surrenderService = surrenderService;
            _mapper = mapper;
        }

        private Guid GetUserId() =>
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        private bool IsAdmin() =>
            User.FindFirst(ClaimTypes.Role)?.Value == "Admin";


        // Create surrender request
        [HttpPost]
        public async Task<IActionResult> Create(CreateSurrenderRequest req)
        {
            var request = await _surrenderService.CreateRequestAsync(
                GetUserId(),
                req.PetName,
                req.Breed,
                req.Age,
                req.Reason,
                req.ImageUrl
            );

            return Ok(_mapper.Map<SurrenderResponse>(request));
        }


        // Get user requests
        [HttpGet("mine")]
        public async Task<IActionResult> MyRequests()
        {
            var list = await _surrenderService.GetRequestsForUserAsync(GetUserId());
            return Ok(_mapper.Map<IEnumerable<SurrenderResponse>>(list));
        }


        // Admin only: Get pending requests
        [HttpGet("pending")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Pending()
        {
            var list = await _surrenderService.GetPendingRequestsAsync();
            return Ok(_mapper.Map<IEnumerable<SurrenderResponse>>(list));
        }


        // Admin approve/reject
        [HttpPatch("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] SurrenderStatus status)
        {
            var updated = await _surrenderService.UpdateStatusAsync(id, status);
            if (updated == null)
                return NotFound("Request not found");

            return Ok(_mapper.Map<SurrenderResponse>(updated));
        }
    }
}
