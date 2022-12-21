using LibraryExtension.Domain.Entities;
using LibraryExtension.Infrastructure.Extensions;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedBook();
        modelBuilder.SeedReader();
        modelBuilder.SeedTransaction();
    }
}
