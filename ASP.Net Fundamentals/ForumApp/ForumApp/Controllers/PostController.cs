using ForumApp.Data.Data;
using ForumApp.Data.Data.Models;
using ForumApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
	public class PostController : Controller
	{
		private readonly ForumAppDbContext _context;

		public PostController(ForumAppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> All()
		{
			var posts = await _context
				.Posts
				.Select(p => new PostViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content,
				})
				.ToListAsync();

			return View(posts);
		}

		public async Task<IActionResult> Add()
		=> View();

		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			var post = new Post()
			{
				Title = model.Title,
				Content = model.Content,
			};

			await _context.Posts.AddAsync(post);
			await _context.SaveChangesAsync();

			return RedirectToAction("All");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var post = await _context.Posts.FindAsync(id);

			if (post != null)
			{
				return View(new PostFormModel()
				{
					Title = post.Title,
					Content = post.Content,
				});
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PostFormModel model)
		{
			var post = await _context.Posts.FindAsync(id);

			if (post != null)
			{
				post.Title = model.Title;
				post.Content = model.Content;
				await _context.SaveChangesAsync();

				return RedirectToAction("All");
			}

			return View();
		}


		public async Task<IActionResult> Delete(int id)
		{
			var post = await _context.Posts.FindAsync(id);

			_context.Posts.Remove(post);
			await _context.SaveChangesAsync();	

			return RedirectToAction("All");
		}
	}
}
