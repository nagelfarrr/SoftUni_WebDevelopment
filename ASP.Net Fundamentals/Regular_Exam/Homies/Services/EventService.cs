using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;

namespace Homies.Services
{
	public class EventService : IEventService
	{
		private readonly HomiesDbContext _context;

		public EventService(HomiesDbContext context)
		{
			_context = context;
		}

		public async Task AddNewEventAsync(EventFormViewModel model, string userId)
		{
			var newEvent = new Event()
			{
				Name = model.Name,
				Description = model.Description,
				Start = model.Start,
				End = model.End,
				CreatedOn = DateTime.Now,
				OrganiserId = userId,
				TypeId = model.TypeId,
			};

			_context.Events.Add(newEvent);
			await _context.SaveChangesAsync();
		}

		

		public async Task<ICollection<AllEventsViewModel>> GetAllEventsAsync()
		{
			return await _context
				.Events
				.Select(e => new AllEventsViewModel()
				{
					Id = e.Id,
					Name = e.Name,
					Type = e.Type.Name,
					Start = e.Start.ToString("yyyy-MM-dd H:mm"),
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<TypeViewModel>> GetAllTypesAsync()
		{
			var types = await _context
				.Types
				.ToListAsync();

			return types.
				Select(t => new TypeViewModel
				{
					Id = t.Id,
					Name = t.Name,
				});
		}

		public async Task<Event?> GetEventAsync(int eventId)
		{
			return  await _context.Events.FindAsync(eventId);
		}
	}
}
