using System.Data;
using JWT_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_API.DBContext;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;" + "Port=5432;Database=employee_sample;"+"User Id=postgres;"+"Password=123;");
    }
}