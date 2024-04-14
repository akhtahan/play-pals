using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayPals.Models;
using PlayPals.Services;
using Microsoft.EntityFrameworkCore;

namespace PlayPals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchingController : ControllerBase
    {
        private PlayPalsDB _db = new PlayPalsDB();
        private readonly UserManager<User> _userManager;

        private async Task<int> GetCurrentUserId()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            return currentUser?.Id ?? 0;
        }

        // GET: api/Matching/GetMatches
        [HttpGet("GetMatches")]
        public async Task<IActionResult> GetMatches()
        {
            // Get the current user's ID 
            int currentUserId = GetCurrentUserId();

            // Retrieve potential matches for the current user
            var matches = await _context.Matches
                .Where(m => m.UserId == currentUserId && !m.IsLiked)
                .Select(m => m.MatchedUser)
                .ToListAsync();

            return Ok(matches);
        }

        // POST: api/Matching/LikeMatch
        [HttpPost("LikeMatch")]
        public async Task<IActionResult> LikeMatch(int matchId)
        {
            // Get the current user's ID 
            int currentUserId = GetCurrentUserId();

            // Find the match record
            var match = await _context.Matches.FindAsync(currentUserId, matchId);
            if (match == null)
            {
                return NotFound();
            }

            // Update the match record to indicate a like
            match.IsLiked = true;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Matching/DislikeMatch
        [HttpPost("DislikeMatch")]
        public async Task<IActionResult> DislikeMatch(int matchId)
        {
            // Get the current user's ID 
            int currentUserId = GetCurrentUserId();

            // Find the match record
            var match = await _context.Matches.FindAsync(currentUserId, matchId);
            if (match == null)
            {
                return NotFound();
            }

            // Remove the match record from the database
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}