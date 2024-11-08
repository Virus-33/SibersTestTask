using Microsoft.EntityFrameworkCore;

namespace TTask.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
