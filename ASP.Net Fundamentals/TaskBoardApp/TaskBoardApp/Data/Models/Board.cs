using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Data.DataConstants.Board;

namespace TaskBoardApp.Data.Models
{
	public class Board
	{       
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(BoardMaxName)]
		public string Name { get; set; } = null!;

		public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
	}
}