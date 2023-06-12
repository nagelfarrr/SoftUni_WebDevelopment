using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models.TextSplitter;

namespace MVCIntroDemo.Controllers
{
	public class TextSplitterController : Controller
	{
		public IActionResult Index(TextSplitterViewModel model)
		{
			return View(model);
		}

		public IActionResult Split(TextSplitterViewModel model)
		{
			var splitTextArray = model
									.Text
									.Split(" ", StringSplitOptions.RemoveEmptyEntries)
									.ToArray();

			model.SplitText = string.Join(Environment.NewLine, splitTextArray);

			return RedirectToAction("Index", model);
		}
	}
}
