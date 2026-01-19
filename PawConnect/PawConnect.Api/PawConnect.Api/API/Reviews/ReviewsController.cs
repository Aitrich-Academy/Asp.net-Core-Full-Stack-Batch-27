using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PawConnect.Api.API.Reviews.RequestObject;
using PawConnect.Api.API.Reviews.ResponseObject;
using PawConnect.Domain.Entities;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Api.API.Reviews
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        private Guid GetCurrentUserId()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(id)) throw new Exception("User id claim missing.");
            return Guid.Parse(id);
        }

        private bool IsAdmin() =>
            string.Equals(User.FindFirst(ClaimTypes.Role)?.Value, "Admin", StringComparison.OrdinalIgnoreCase);

        // POST: api/Reviews
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = GetCurrentUserId();

            var created = await _reviewService.AddReviewAsync(userId, request.TargetId, request.TargetType, request.Rating, request.Comment);

            var response = _mapper.Map<ReviewResponse>(created);
            return Ok(response);
        }

        // GET: api/Reviews/target/{targetId}?type=Shelter
        [AllowAnonymous]
        [HttpGet("target/{targetId:guid}")]
        public async Task<IActionResult> GetByTarget(Guid targetId, [FromQuery] TargetType type)
        {
            var list = await _reviewService.GetByTargetAsync(targetId, type);
            var response = _mapper.Map<IEnumerable<ReviewResponse>>(list);
            return Ok(response);
        }

        // GET: api/Reviews/target/{targetId}/average?type=Shelter
        [AllowAnonymous]
        [HttpGet("target/{targetId:guid}/average")]
        public async Task<IActionResult> GetAverage(Guid targetId, [FromQuery] TargetType type)
        {
            var avg = await _reviewService.GetAverageRatingAsync(targetId, type);
            return Ok(new { targetId, type = type.ToString(), averageRating = avg });
        }

        // GET: api/Reviews/user
        [HttpGet("user")]
        public async Task<IActionResult> GetMyReviews()
        {
            var userId = GetCurrentUserId();
            var list = await _reviewService.GetByUserAsync(userId);
            var response = _mapper.Map<IEnumerable<ReviewResponse>>(list);
            return Ok(response);
        }

        // DELETE: api/Reviews/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null) return NotFound();

            var currentUserId = GetCurrentUserId();
            var isAdmin = IsAdmin();

            var ok = await _reviewService.DeleteAsync(id, currentUserId, isAdmin);
            if (!ok) return StatusCode(500, "Failed to delete review.");
            return NoContent();
        }
    }
}
