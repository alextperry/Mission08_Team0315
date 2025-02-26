using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0315.Models
{
    public class QuadrantContext : DbContext
    {
        public QuadrantContext(DbContextOptions<QuadrantContext> options) : base(options)
        {

        }

        public DbSet<ToDoListForm> Tasks {  get; set; } //Tasks = Table Name
        public DbSet<QuadrantCategory> QuadrantCategories { get; set; } //Quadrant Categories = Table Name

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuadrantCategory>().HasData(
                new QuadrantCategory { CategoryId = 1, CategoryName = "Home" },
                new QuadrantCategory { CategoryId = 2, CategoryName = "School" },
                new QuadrantCategory { CategoryId = 3, CategoryName = "Work" },
                new QuadrantCategory { CategoryId = 4, CategoryName = "Church" }
                );
                

        }
    }
}
