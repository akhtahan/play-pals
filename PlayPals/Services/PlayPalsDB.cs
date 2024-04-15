using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayPals.Models;
using Microsoft.EntityFrameworkCore;

namespace PlayPals.Services
{
    public class PlayPalsDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PlayPals.db");
        }
    }
}