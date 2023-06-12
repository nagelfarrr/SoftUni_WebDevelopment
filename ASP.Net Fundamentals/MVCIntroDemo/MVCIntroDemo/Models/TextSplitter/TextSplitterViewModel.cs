using System.ComponentModel.DataAnnotations;

namespace MVCIntroDemo.Models.TextSplitter
{
	public class TextSplitterViewModel
	{
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Text { get; set; } = null!;

        public string SplitText { get; set; } = null!;
    }
}
