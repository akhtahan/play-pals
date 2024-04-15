using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlayPals.Models;
using Microsoft.AspNetCore.Identity;

namespace PlayPals.Controllers
{
    [Route("api/[controller]")]
    public class MatchingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private static List<User> matches = new List<User>
        {
            new User { Id = 1, Name = "Alex", Age = 25 },
            new User { Id = 2, Name = "Jordan", Age = 28 },
            new User { Id = 3, Name = "Emily", Age = 22 },
            new User { Id = 4, Name = "Michael", Age = 30 }
        };
        private static List<User> likedMatches = new List<User>();

        public MatchingController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        private int GetCurrentUserId()
        {
            var currentUser = _userManager.GetUserAsync(HttpContext.User);
            return currentUser?.Id ?? 0;
        }

        // GET: api/Matching/GetMatches
        [HttpGet("GetMatches")]
        public IActionResult GetMatches()
        {
            // Get the current user's ID 
            int currentUserId = GetCurrentUserId();

            return Ok(matches);
        }

        // POST: api/Matching/LikeMatch
        [HttpPost("LikeMatch")]
        public IActionResult LikeMatch(int matchId)
        {
            // Find the match in the hardcoded list
            var match = matches.FirstOrDefault(m => m.Id == matchId);

            if (match == null)
            {
                return NotFound();
            }

            // Add the match to the list of liked matches
            likedMatches.Add(match);

            return Ok(likedMatches);
        }

        // POST: api/Matching/DislikeMatch
        [HttpPost("DislikeMatch")]
        public IActionResult DislikeMatch(int matchId)
        {
            // Find the match in the list of liked matches
            var match = likedMatches.FirstOrDefault(m => m.Id == matchId);

            if (match == null)
            {
                return NotFound();
            }

            // Remove the match from the list of liked matches
            likedMatches.Remove(match);

            return Ok(likedMatches);
        }

        public IActionResult MatchingBrowser()
        {
            // Pass the matches as the model to the view
            return View(matches);
        }
    }
}