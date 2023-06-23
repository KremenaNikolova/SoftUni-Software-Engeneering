using Homies.Models.EventModels;
using Homies.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var getTypes = await eventService.GetTypesAsync();

            var newEvent = new AddEventViewModel()
            {
                Types = getTypes,
            };

            return View(newEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel newEvent)
        {
            ModelState.Remove("OrganiserId");
            var userId = GetUserId();

            newEvent.OrganiserId = userId;

            if (!ModelState.IsValid)
            {
                return View(newEvent);
            }
            try
            {
                await eventService.AddNewEventAsync(newEvent);
            }
            catch
            {
                return View(newEvent);
            }

            return RedirectToAction("All", "Event");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currEvent = await eventService.GetEventByIdAsync(id);

            if (currEvent == null)
            {
                return RedirectToAction("All", "Event");
            }

            return View(currEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", "Event");
            }

            try
            {
                await eventService.EditEventAsync(id, editModel);
            }
            catch
            {
                return RedirectToAction("Edit", "Event");
            }

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Join(int id)
        {
            string userId = GetUserId();

            try
            {
                await eventService.AddToJoinedEventsAsync(userId, id);
            }
            catch
            {
                return RedirectToAction("All", "Event");
            }

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Leave(int id)
        {
            string userId = GetUserId();

            try
            {
                await eventService.RemoveFromJoinedEventsAsync(userId, id);
            }
            catch
            {
                return RedirectToAction("Joined", "Event");
            }

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Details(int id)
        {
            var currEvent = await eventService.GetDetailsEventByIdAsync(id);
            if(currEvent != null)
            {
                return View(currEvent);
            }

            return RedirectToAction("All", "Event");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
