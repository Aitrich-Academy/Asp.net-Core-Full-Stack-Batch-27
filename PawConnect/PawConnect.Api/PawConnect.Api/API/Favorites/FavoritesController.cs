using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawConnect.Api.API.Favorites.RequestObject;
using PawConnect.Api.API.Favorites.ResponseObject;
using PawConnect.Domain.Services.Interfaces;
using System.Security.Claims;

namespace PawConnect.Api.API.Favorites
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritePetService _service;
        private readonly IMapper _mapper;

        public FavoritesController(IFavoritePetService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        private Guid UserId =>
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        [HttpPost]
        public async Task<IActionResult> Add(AddFavoriteRequest req)
        {
            var ok = await _service.AddAsync(UserId, req.PetId);
            return ok ? Ok("Added to favorites") : BadRequest();
        }

        [HttpDelete("{petId}")]
        public async Task<IActionResult> Remove(int petId)
        {
            var ok = await _service.RemoveAsync(UserId, petId);
            return ok ? Ok("Removed from favorites") : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> MyFavorites()
        {
            var list = await _service.GetMyFavoritesAsync(UserId);
            return Ok(_mapper.Map<IEnumerable<FavoriteResponse>>(list));
        }
    }
}
