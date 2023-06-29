namespace TaskBoardApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using TaskBoardApp.Data;
	using TaskBoardApp.Models.Board;
	using TaskBoardApp.Models.Task;

	public class BoardController : Controller
	{
		private readonly ApplicationDbContext _data;

		public BoardController(ApplicationDbContext data)
		{
			_data = data;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> All()
		{
			var boards = await _data
				.Boards
				.Select(b => new BoardViewModel()
				{
					Id = b.Id,
					Name = b.Name,
					Tasks = b
						.Tasks
						.Select(t => new TaskViewModel()
						{
							Id= t.Id,
							Title = t.Title,
							Description = t.Description,
							Owner = t.Owner.UserName
						})
				})
				.ToListAsync();

			return View(boards);
		}
	}
}
