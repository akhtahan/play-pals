using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PlayPals.Models;
using PlayPals.Services;

namespace PlayPals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private static List<Chat> chats = new List<Chat>
        {
            new Chat
            {
                Id = 1,
                User1Id = 1,
                User1 = new User { Id = 1, Name = "John" },
                User2Id = 2,
                User2 = new User { Id = 2, Name = "Jane" },
                Messages = new List<Message>
                {
                    new Message { Id = 1, ChatId = 1, SenderId = 1, Sender = new User { Id = 1, Name = "John" }, Content = "Hello, Jane!", SentAt = DateTime.UtcNow.AddHours(-2) },
                    new Message { Id = 2, ChatId = 1, SenderId = 2, Sender = new User { Id = 2, Name = "Jane" }, Content = "Hi, John! How are you?", SentAt = DateTime.UtcNow.AddHours(-1) }
                }
            },
            new Chat
            {
                Id = 2,
                User1Id = 1,
                User1 = new User { Id = 1, Name = "John" },
                User2Id = 3,
                User2 = new User { Id = 3, Name = "Bob" },
                Messages = new List<Message>
                {
                    new Message { Id = 3, ChatId = 2, SenderId = 1, Sender = new User { Id = 1, Name = "John" }, Content = "Hey, Bob! How's it going?", SentAt = DateTime.UtcNow.AddDays(-1) },
                    new Message { Id = 4, ChatId = 2, SenderId = 3, Sender = new User { Id = 3, Name = "Bob" }, Content = "I'm doing great, John! Thanks for asking.", SentAt = DateTime.UtcNow.AddHours(-3) }
                }
            }
        };

        [HttpGet("GetChats")]
        public IActionResult GetChats()
        {
            int currentUserId = 1; // Hard-coded for demonstration purposes
            var userChats = chats.Where(c => c.User1Id == currentUserId || c.User2Id == currentUserId).ToList();
            return Ok(userChats);
        }

        [HttpGet("GetMessages/{chatId}")]
        public IActionResult GetMessages(int chatId)
        {
            int currentUserId = 1; // Hard-coded for demonstration purposes
            var chat = chats.FirstOrDefault(c => c.Id == chatId && (c.User1Id == currentUserId || c.User2Id == currentUserId));
            if (chat == null)
                return NotFound();

            return Ok(chat.Messages);
        }

        [HttpPost("SendMessage")]
        public IActionResult SendMessage(SendMessageRequest request)
        {
            int currentUserId = 1; // Hard-coded for demonstration purposes
            var chat = chats.FirstOrDefault(c => c.Id == request.ChatId && (c.User1Id == currentUserId || c.User2Id == currentUserId));
            if (chat == null)
                return NotFound();

            var message = new Message
            {
                Id = chat.Messages.Count + 1,
                ChatId = request.ChatId,
                SenderId = currentUserId,
                Sender = new User { Id = currentUserId, Name = "John" }, // Hard-coded for demonstration purposes
                Content = request.Content,
                SentAt = DateTime.UtcNow
            };

            chat.Messages.Add(message);
            return Ok();
        }
    }

    public class SendMessageRequest
    {
        public int ChatId { get; set; }
        public string Content { get; set; }
    }
}