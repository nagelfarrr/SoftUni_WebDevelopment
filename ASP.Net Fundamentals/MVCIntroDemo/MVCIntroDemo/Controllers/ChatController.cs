using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models.Message;

namespace MVCIntroDemo.Controllers
{
	public class ChatController : Controller
	{
		private static List<KeyValuePair<string, string>> _messages =
			new List<KeyValuePair<string, string>>();

		public IActionResult Show()
		{
			if (_messages.Count < 1)
			{
				return View(new ChatViewModel());
			}

			var chatModel = new ChatViewModel()
			{
				Messages = _messages
						.Select(m => new MessageViewModel()
						{
							Sender = m.Key,
							MessageText = m.Value
						})
						.ToList()
			};

			return View(chatModel);
		}

		[HttpPost]
		public IActionResult Send(ChatViewModel chat)
		{
			var newMessage = chat.CurrentMessage;

			_messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

			return RedirectToAction("Show");
		}
	}
}
