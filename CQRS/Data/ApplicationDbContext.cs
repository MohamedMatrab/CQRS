using CQRS.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}