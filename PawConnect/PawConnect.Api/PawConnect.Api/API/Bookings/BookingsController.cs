using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawConnect.Api.API.Bookings.RequestObject;
using PawConnect.Api.API.Bookings.ResponseObject;
using PawConnect.Domain.Services.Interfaces;
using System.Security.Claims;

namespace PawConnect.Api.API.Bookings
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        private Guid GetUserId() =>
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        private bool IsAdmin() =>
            User.FindFirst(ClaimTypes.Role)?.Value == "Admin";


        // CREATE BOOKING
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingRequest request)
        {
            var booking = await _bookingService.CreateBookingAsync(
                GetUserId(),
                request.ServiceId,
                request.BookingDate
            );

            if (booking == null)
                return BadRequest("Service not found.");

            var response = _mapper.Map<BookingResponse>(booking);
            return Ok(response);
        }


        // GET MY BOOKINGS
        [HttpGet("user")]
        public async Task<IActionResult> GetMyBookings()
        {
            var data = await _bookingService.GetUserBookingsAsync(GetUserId());
            var response = _mapper.Map<IEnumerable<BookingResponse>>(data);
            return Ok(response);
        }


        // GET BOOKINGS FOR PROVIDER
        [HttpGet("provider/{providerId}")]
        public async Task<IActionResult> GetProviderBookings(Guid providerId)
        {
            var data = await _bookingService.GetProviderBookingsAsync(providerId);
            var response = _mapper.Map<IEnumerable<BookingResponse>>(data);
            return Ok(response);
        }


        // CANCEL BOOKING
        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var ok = await _bookingService.CancelBookingAsync(id, GetUserId(), IsAdmin());
            if (!ok)
                return BadRequest("Unable to cancel booking.");

            return Ok("Booking cancelled.");
        }
    }
}
