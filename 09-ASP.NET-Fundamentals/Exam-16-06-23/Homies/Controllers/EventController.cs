using Homies.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public async Task<IActionResult> All()
        {
            var allBooks = await eventService.GetAllEventsAsync();

            return View(allBooks);
        }

        public async Task<IActionResult> Joined()
        {
            var userId = GetUserId();

            var joinedBooks = await eventService.GetAllJoinedEventsAsync(userId);

            return View(joinedBooks);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
