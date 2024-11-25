using Microsoft.EntityFrameworkCore;

namespace TTask.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<Task> Tasks { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                    .HasMany(p => p.Projects)
                    .WithMany(pl => pl.People)
                    .UsingEntity(j => j.ToTable("EmployeeProjects"));

            modelBuilder.Entity<Person>()
                .HasOne(p => p.ManagingProject)
                .WithOne(pr => pr.ProjectManager)
                .HasForeignKey<Project>(p=>p.ManagerKey);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(tk => tk.ProjectKey);
        }
    }
}
