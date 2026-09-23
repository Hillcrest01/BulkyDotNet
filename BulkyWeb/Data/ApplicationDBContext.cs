using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }
        //we then create the tables by defining the DBSet
        //inside the <> , we pass the name of the Model we created, then we pass the name to appear on the SQL.
        //in this case, the name of our Model is Category and the name we want to appear is Categories.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Users> PortalUsers { get; set; }

        //we use the method overriding below to seed data into our database using Entity Framework.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Actions", DisplayOrder=1 },
                new Category { Id=2, Name="Action Test", DisplayOrder=2}
                );
        }
    }
}
