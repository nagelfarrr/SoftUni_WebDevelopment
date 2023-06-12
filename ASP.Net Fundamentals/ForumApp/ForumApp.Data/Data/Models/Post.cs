namespace ForumApp.Data.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static ValidationConstants.DataConstants;

	public class Post
	{
		[Key]
		public int Id { get; init; }

		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(ContentMaxLength)]
		public string Content { get; set; } = null!;
	}
}
