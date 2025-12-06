using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    EducationLevel = "Bachelor"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1995, 5, 15),
                    EducationLevel = "Master"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    DateOfBirth = new DateTime(1985, 8, 22),
                    EducationLevel = "PhD"
                }
            );
        }
    }
}
