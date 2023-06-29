using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
	[Comment("Joining Table")]
	public class EventParticipant
	{
		[Required]
		[ForeignKey(nameof(Helper))]
		public string HelperId { get; set; } = null!;
		[Required]
		public IdentityUser Helper { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Event))]
        public int EventId { get; set; }
		[Required]
		public Event Event { get; set; } = null!;
    }
}
