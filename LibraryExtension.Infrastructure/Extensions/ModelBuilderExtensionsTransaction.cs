using LibraryExtension.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryExtension.Infrastructure.Extensions;

public static class ModelBuilderExtensionsTransaction
{
    public static void SeedTransaction(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().HasData(
            new Transaction
            {
                Id = 1,
                BookId = 1,
                RentDate = DateTime.UtcNow,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(7),
                ReaderId = 1
            },

            new Transaction
            {
                Id = 2,
                BookId = 3,
                RentDate = DateTime.UtcNow,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(3),
                ReaderId = 5
            },

            new Transaction
            {
                Id = 3,
                BookId = 2,
                RentDate = DateTime.UtcNow,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(15),
                ReaderId = 2
            });
    }
}
