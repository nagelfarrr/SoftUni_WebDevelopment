using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Data.Models
{
	public class Task
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskMaxTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TaskMaxDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }
        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        public IdentityUser Owner { get; set; } = null!;
    }
}
