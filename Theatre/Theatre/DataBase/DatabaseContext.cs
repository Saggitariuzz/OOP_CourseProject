using Microsoft.EntityFrameworkCore;
using Theatre.Models;

namespace Theatre.DataBase
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Performance> Performances {
            get { return Set<Performance>(); } }

        private readonly string СonnectionString;

        public DatabaseContext(string connectionString)
        {
            СonnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(СonnectionString);
        }
    }
}
