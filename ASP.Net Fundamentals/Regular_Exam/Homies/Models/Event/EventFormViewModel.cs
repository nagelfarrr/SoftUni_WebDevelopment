using System.ComponentModel.DataAnnotations;

using static Homies.Data.DataValidationConstants.Event;

namespace Homies.Models.Event
{
	public class EventFormViewModel
	{
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

		[Required]
		[DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
		public DateTime Start { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
		public DateTime End { get; set; }

		[Required]
        public int TypeId { get; set; }

		public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
