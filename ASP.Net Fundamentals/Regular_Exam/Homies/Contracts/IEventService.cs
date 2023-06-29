using Homies.Data.Models;
using Homies.Models.Event;

namespace Homies.Contracts
{
	public interface IEventService
	{
		Task<IEnumerable<TypeViewModel>> GetAllTypesAsync();

		Task<ICollection<AllEventsViewModel>> GetAllEventsAsync();

		Task AddNewEventAsync(EventFormViewModel model, string userId);

		Task<Event?> GetEventAsync(int eventId);
	}
}
