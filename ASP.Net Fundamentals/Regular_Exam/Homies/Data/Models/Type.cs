using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Homies.Data.DataValidationConstants.Type;

namespace Homies.Data.Models
{
    [Comment("Type of the event")]
	public class Type
	{
        [Comment("Primary Key")]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
