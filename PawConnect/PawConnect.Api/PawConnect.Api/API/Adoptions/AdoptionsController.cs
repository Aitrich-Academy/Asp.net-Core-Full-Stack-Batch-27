using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PawConnect.Api.API.Adoptions.RequestObject;
using PawConnect.Api.API.Adoptions.ResponseObject;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Api.API.Adoptions
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdoptionsController : ControllerBase
    {
        private readonly IAdoptionService _adoptionService;
        private readonly IPetService _petService;
        private readonly IMapper _mapper;
        private readonly INotificationService? _notificationService; // optional

        public AdoptionsController(
            IAdoptionService adoptionService,
            IPetService petService,
            IMapper mapper,
            INotificationService? notificationService = null) // optional - DI will provide if registered
        {
            _adoptionService = adoptionService;
            _petService = petService;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        private Guid GetCurrentUserId()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("User id claim missing.");
            return Guid.Parse(id);
        }

        private bool IsAdmin() =>
            string.Equals(User.FindFirst(ClaimTypes.Role)?.Value, "Admin", StringComparison.OrdinalIgnoreCase);

        // POST: api/Adoptions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAdoptionRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = GetCurrentUserId();

            var pet = await _petService.GetByIdAsync(request.PetId);
            if (pet == null) return NotFound("Pet not found.");
            if (pet.OwnerId == userId) return BadRequest("You cannot adopt your own pet.");
            if (pet.Status != PetStatus.Available) return BadRequest("Pet is not available for adoption.");

            var created = await _adoptionService.CreateRequestAsync(userId, request.PetId, request.Message);

            // Ensure navigation props are loaded if your repo returns them; otherwise map manually
            var response = _mapper.Map<AdoptionResponse>(created);
            return Ok(response);
        }

        // GET: api/Adoptions/user
        [HttpGet("user")]
        public async Task<IActionResult> GetMyRequests()
        {
            var userId = GetCurrentUserId();
            var list = await _adoptionService.GetRequestsForUserAsync(userId);
            var response = _mapper.Map<IEnumerable<AdoptionResponse>>(list);
            return Ok(response);
        }

        // GET: api/Adoptions/pet/{petId}
        [HttpGet("pet/{petId:int}")]
        public async Task<IActionResult> GetRequestsForPet(int petId)
        {
            var pet = await _petService.GetByIdAsync(petId);
            if (pet == null) return NotFound("Pet not found.");

            var currentUserId = GetCurrentUserId();
            if (pet.OwnerId != currentUserId && !IsAdmin())
                return Forbid("Only pet owner or admin can view requests for this pet.");

            var list = await _adoptionService.GetRequestsForPetAsync(petId);
            var response = _mapper.Map<IEnumerable<AdoptionResponse>>(list);
            return Ok(response);
        }

        // PUT: api/Adoptions/{id}/status
        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateAdoptionStatusRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // 1) fetch the adoption request
            var adoptionRequest = await _adoptionService.GetByIdAsync(id);
            if (adoptionRequest == null)
                return NotFound("Adoption request not found.");

            // 2) fetch pet to verify owner
            var pet = await _petService.GetByIdAsync(adoptionRequest.PetId);
            if (pet == null)
                return NotFound("Pet not found.");

            var currentUserId = GetCurrentUserId();
            if (pet.OwnerId != currentUserId && !IsAdmin())
                return Forbid("Only the pet owner or an admin can change the status.");

            // 3) perform the update
            var updated = await _adoptionService.UpdateStatusAsync(id, request.Status);
            if (updated == null)
                return NotFound("Unable to update adoption request.");

            // 4) optional: send a notification to the requester
            if (_notificationService != null)
            {
                try
                {
                    var msg = $"Your adoption request for pet '{pet.Name}' is now '{updated.Status}'.";
                    await _notificationService.SendAsync(updated.UserId, msg);
                }
                catch
                {
                    // notification failures should not break the main flow
                }
            }

            var response = _mapper.Map<AdoptionResponse>(updated);
            return Ok(response);
        }
    }
}
