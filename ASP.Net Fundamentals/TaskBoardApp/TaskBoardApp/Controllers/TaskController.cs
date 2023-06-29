using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
	public class TaskController : Controller
	{
		private readonly ApplicationDbContext _data;

		public TaskController(ApplicationDbContext data)
		{
			_data = data;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
		{
			TaskFormModel taskModel = new TaskFormModel()
			{
				Boards = GetBoards()
			};

			return View(taskModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(TaskFormModel taskModel)
		{
			if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
			{
				ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
			}

			string currentUserId = GetUserId();

			if (!ModelState.IsValid)
			{
				taskModel.Boards = GetBoards();

				return View(taskModel);
			}

			Task task = new Task()
			{
				Title = taskModel.Title,
				Description = taskModel.Description,
				CreatedOn = DateTime.Now,
				BoardId = taskModel.BoardId,
				OwnerId = currentUserId,
			};

			await _data.Tasks.AddAsync(task);
			await _data.SaveChangesAsync();

			var board = _data.Boards;

			return RedirectToAction("All", "Board");
		}

		public async Task<IActionResult> Details(int id)
		{
			var task = await _data
				.Tasks
				.Where(t => t.Id == id)
				.Select(t => new TaskDetailsViewModel()
				{
					Id = t.Id,
					Title = t.Title,
					Description = t.Description,
					CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
					Board = t.Board.Name,
					Owner = t.Owner.UserName,
				}).FirstOrDefaultAsync();

			if (task == null)
			{
				return BadRequest();
			}
			return View(task);
		}


		public async Task<IActionResult> Edit(int id)
		{
			var task = await _data.Tasks.FindAsync(id);

			if (task == null)
			{
				return BadRequest();
			}

			string currentUserId = GetUserId();

			if (currentUserId != task.OwnerId)
			{
				return Unauthorized();
			}

			TaskFormModel taskModel = new TaskFormModel()
			{
				Title = task.Title,
				Description = task.Description,
				BoardId = task.BoardId,
				Boards = GetBoards()
			};

			return View(taskModel);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
		{
			var task = await _data.Tasks.FindAsync(id);

			if (task == null)
			{
				return BadRequest();
			}

			string currentUserId = GetUserId();

			if (currentUserId != task.OwnerId)
			{
				return Unauthorized();
			}

			if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
			{
				ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
			}

			if (!ModelState.IsValid)
			{
				taskModel.Boards = GetBoards();

				return View(taskModel);
			}

			task.Title = taskModel.Title;
			task.Description = taskModel.Description;
			task.BoardId = taskModel.BoardId;

			await _data.SaveChangesAsync();
			return RedirectToAction("All", "Board");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var task = await _data.Tasks.FindAsync(id);

			if (task == null)
			{
				return BadRequest();
			}

			string currentUserId = GetUserId();

			if(currentUserId != task.OwnerId)
			{
				return Unauthorized();
			}

			TaskViewModel taskModel = new TaskViewModel()
			{
				Id = task.Id,
				Title = task.Title,
				Description = task.Description,
			};

			return View(taskModel);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(TaskViewModel model)
		{
			var task = await _data.Tasks.FindAsync(model.Id);
			if(task == null)
			{
				return BadRequest();
			}

			string currentUserId = GetUserId();
			if(currentUserId != task.OwnerId)
			{
				return Unauthorized();
			}

			_data.Tasks.Remove(task);
			await _data.SaveChangesAsync();
			return RedirectToAction("All", "Board");
		}

		private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

		private IEnumerable<TaskBoardModel> GetBoards()
		{
			return _data
					.Boards
					.Select(x => new TaskBoardModel()
					{
						Id = x.Id,
						Name = x.Name,
					});
		}
	}
}
