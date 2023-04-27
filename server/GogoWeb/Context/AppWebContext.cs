using GogoWeb.API.Models;
using GogoWeb.API.Seeds;
using Microsoft.EntityFrameworkCore;

namespace GogoWeb.API.Context
{
    public class AppWebContext : DbContext
    {
        public AppWebContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }

        
    }
}
