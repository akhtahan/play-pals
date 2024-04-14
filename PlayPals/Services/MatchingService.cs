using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayPals.Services
{
    public interface IMatchingService
    {
        IEnumerable<User> GetPotentialMatches(int userId);
        void LikeMatch(int userId, int matchId);
        void DislikeMatch(int userId, int matchId);
    }
}