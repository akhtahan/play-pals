using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayPals.Services
{
    public class PlayPalsDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PlayPals.db");
        }
    }
}