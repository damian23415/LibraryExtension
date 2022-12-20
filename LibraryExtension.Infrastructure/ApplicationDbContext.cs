using LibraryExtension.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryExtension.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)
    {

    }

    public DbSet<Book> Book { get; set; }
    public DbSet<Reader> Reader { get; set; }
    public DbSet<Transaction> Transaction { get; set; }
}
