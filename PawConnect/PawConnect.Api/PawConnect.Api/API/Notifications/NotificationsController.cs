using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawConnect.Api.API.Notifications.RequestObject;
using PawConnect.Api.API.Notifications.ResponseObject;
using PawConnect.Domain.Services.Interfaces;
using System.Security.Claims;

namespace PawConnect.Api.API.Notifications
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        private Guid UserId =>
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        // GET: /api/notifications
        [HttpGet]
        public async Task<IActionResult> GetMyNotifications()
        {
            var list = await _service.GetForUserAsync(UserId);
            return Ok(_mapper.Map<IEnumerable<NotificationResponse>>(list));
        }

        // POST: /api/notifications
        [HttpPost]
        public async Task<IActionResult> Send(CreateNotificationRequest req)
        {
            var notification = await _service.SendAsync(UserId, req.Message);
            return Ok(_mapper.Map<NotificationResponse>(notification));
        }

        // PATCH: /api/notifications/{id}/read
        [HttpPatch("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var success = await _service.MarkAsReadAsync(id, UserId);

            if (!success)
                return BadRequest("Could not mark notification as read");

            return Ok("Notification marked as read");
        }
    }
}
