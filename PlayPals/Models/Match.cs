using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayPals.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MatchedUserId { get; set; }
        public User MatchedUser { get; set; }
        public bool IsLiked { get; set; }
    }
}