using Microsoft.EntityFrameworkCore;
using BackTaskWeb.Models;

namespace BackTaskWeb.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) 
          : base(options) 
        {
        
        }

        public DbSet<TaskModel> TaskM  { get; set; }

    }
}
