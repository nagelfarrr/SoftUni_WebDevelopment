using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Data.DataValidationConstants.Event;

namespace Homies.Data.Models
{
	[Comment("Event to announce")]
	public class Event
	{
		[Comment("Primary Key")]
		[Key]
		public int Id { get; set; }

		[Comment("Name of the event")]
		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Comment("Description of the event")]
		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Comment("Organiser Id")]
		[Required]
		public string OrganiserId { get; set; } = null!;

		[Required]
		public IdentityUser Organiser { get; set; } = null!;

		[Comment("Event created date")]
		[Required]
		[DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
		public DateTime CreatedOn { get; set; }

		[Comment("Event start date")]
		[Required]
		[DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
		public DateTime Start { get; set; }

		[Comment("Event end date")]
		[Required]
		[DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
		public DateTime End { get; set; }

		[Required]
		[ForeignKey(nameof(Type))]
		public int TypeId { get; set; }

		public Type Type { get; set; } = null!;

		public ICollection<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();
	}
}
