namespace ChatApp.Controllers

{
    using Microsoft.AspNetCore.Mvc;
    
    using ChatApp.Models.Chat;

    public class ChatController : Controller
    {
        private static readonly List<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();

        [HttpGet]
        public IActionResult Show()
        {
            if (messages.Count <= 0) 
            {
                return View(new ChatViewModel());
            }

            ChatViewModel chatModel = new ChatViewModel()
            {
                Messages = messages
                .Select(m=> new MessageViewModel()
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
            var currMessage = chat.CurrentMessage;
            messages.Add(new KeyValuePair<string, string>(currMessage.Sender, currMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
