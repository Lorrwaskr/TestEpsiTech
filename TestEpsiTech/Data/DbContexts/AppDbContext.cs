using Microsoft.EntityFrameworkCore;
using TestEpsiTech.Models.Entities;

namespace TestEpsiTech.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
