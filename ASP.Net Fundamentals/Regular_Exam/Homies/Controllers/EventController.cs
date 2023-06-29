using Microsoft.AspNetCore.Mvc;

using Homies.Contracts;
using Microsoft.AspNetCore.Authorization;
using Homies.Models.Event;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Homies.Data;

namespace Homies.Controllers
{
	[Authorize]
	public class EventController : Controller
	{
		private readonly IEventService _eventService;
		private readonly HomiesDbContext _context;

		public EventController(IEventService eventService, HomiesDbContext context)
		{
			_eventService = eventService;
			_context = context;
		}

		public async Task<IActionResult> All()
		{
			var events = await _eventService.GetAllEventsAsync();

			return View(events);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var types = await _eventService.GetAllTypesAsync();

			var model = new EventFormViewModel()
			{
				Types = types
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(EventFormViewModel model)
		{
			var validTypes = await _eventService.GetAllTypesAsync();

			if (!validTypes.Any(t => t.Id == model.TypeId))
			{
				ModelState.AddModelError(nameof(model.TypeId), "Invalid type Id");
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			await _eventService.AddNewEventAsync(model, userId);
			return RedirectToAction("All", "Event");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var currEvent = await _eventService.GetEventAsync(id);

			if (currEvent == null)
			{
				return BadRequest();
			}

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId != currEvent.OrganiserId)
			{
				Unauthorized();
			}

			var model = new EventFormViewModel
			{
				Name = currEvent.Name,
				Description = currEvent.Description,
				Start = currEvent.Start,
				End = currEvent.End,
				TypeId = currEvent.TypeId,
			};

			var types = await _eventService.GetAllTypesAsync();
			model.Types = types;
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EventFormViewModel model)
		{
			var currEvent = await _eventService.GetEventAsync(id);

			if (currEvent == null)
			{
				return BadRequest();
			}

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId != currEvent.OrganiserId)
			{
				Unauthorized();
			}

			var newModel = new EventFormViewModel
			{
				Name = currEvent.Name,
				Description = currEvent.Description,
				Start = currEvent.Start,
				End = currEvent.End,
				TypeId = currEvent.TypeId,
			};

			await _context.SaveChangesAsync();

			return View(newModel);

		}

		public async Task<IActionResult> Joined()
		{
			var events = await _eventService.GetAllEventsAsync();

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			
			var models = events.Where(e=> e.Organiser == userId);


			return View(models);
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
			var currEvent = await _eventService.GetEventAsync(id);

			return RedirectToAction("Joined", "Event");
		}
	}
}

