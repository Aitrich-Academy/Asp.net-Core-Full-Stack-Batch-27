using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PawConnect.Api.API.Pets.RequestObject;
using PawConnect.Api.API.Pets.ResponseObject;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Api.API.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // all pet endpoints require login
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetsController(IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
        }

        private Guid GetCurrentUserId()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("User id claim missing.");
            return Guid.Parse(id);
        }

        // POST: api/Pets  (Add new pet)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePetRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ownerId = GetCurrentUserId();

            var pet = _mapper.Map<Pet>(request);
            pet.OwnerId = ownerId;
            pet.Status = PetStatus.Available;

            pet = await _petService.AddPetAsync(pet);

            var response = _mapper.Map<PetResponse>(pet);
            return Ok(response);
        }

        // GET: api/Pets  (Get all pets with optional filters)
        [HttpGet]
        [AllowAnonymous] // allow browsing without login if you want
        public async Task<IActionResult> GetAll(
            [FromQuery] string? type,
            [FromQuery] string? breed,
            [FromQuery] PetStatus? status)
        {
            var pets = await _petService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(type))
                pets = pets.Where(p => p.Type.ToLower() == type.ToLower());

            if (!string.IsNullOrWhiteSpace(breed))
                pets = pets.Where(p => p.Breed != null && p.Breed.ToLower() == breed.ToLower());

            if (status.HasValue)
                pets = pets.Where(p => p.Status == status.Value);

            var response = _mapper.Map<IEnumerable<PetResponse>>(pets);
            return Ok(response);
        }

        // GET: api/Pets/{id}
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petService.GetByIdAsync(id);
            if (pet == null)
                return NotFound();

            var response = _mapper.Map<PetResponse>(pet);
            return Ok(response);
        }

        // GET: api/Pets/my  (pets of current logged in user)
        [HttpGet("my")]
        public async Task<IActionResult> GetMyPets()
        {
            var ownerId = GetCurrentUserId();

            var pets = await _petService.GetByOwnerIdAsync(ownerId);
            var response = _mapper.Map<IEnumerable<PetResponse>>(pets);

            return Ok(response);
        }

        // PUT: api/Pets/{id}  (update pet – only owner)
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePetRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pet = await _petService.GetByIdAsync(id);
            if (pet == null)
                return NotFound("Pet not found.");

            var currentUserId = GetCurrentUserId();
            if (pet.OwnerId != currentUserId)
                return Forbid("You are not the owner of this pet.");

            // map updated fields
            _mapper.Map(request, pet);

            await _petService.UpdatePetAsync(pet);

            var response = _mapper.Map<PetResponse>(pet);
            return Ok(response);
        }

        // DELETE: api/Pets/{id}  (delete pet – only owner or later admin)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _petService.GetByIdAsync(id);
            if (pet == null)
                return NotFound("Pet not found.");

            var currentUserId = GetCurrentUserId();
            if (pet.OwnerId != currentUserId)
                return Forbid("You are not the owner of this pet.");

            await _petService.DeletePetAsync(id);

            return NoContent();
        }

        // PUT: api/Pets/{id}/status  (change status – owner or admin)
        [HttpPut("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] PetStatus status)
        {
            var pet = await _petService.GetByIdAsync(id);
            if (pet == null)
                return NotFound("Pet not found.");

            var currentUserId = GetCurrentUserId();
            if (pet.OwnerId != currentUserId)
                return Forbid("You are not the owner of this pet.");

            await _petService.UpdateStatusAsync(id, status);

            return Ok("Status updated.");
        }
    }
}
