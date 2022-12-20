using LibraryExtension.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryExtension.Infrastructure.Configuration;

public class BookTransactionConfiguration : IEntityTypeConfiguration<BookTransaction>
{
    public void Configure(EntityTypeBuilder<BookTransaction> builder)
    {
        builder.ToTable("BookTransactions");

        builder
            .HasKey(x => new { x.TransactionId, x.BookId });

        builder
            .HasOne<Book>(x => x.Book)
            .WithMany(x => x.BookTransactions)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<Transaction>(x => x.Transaction)
            .WithMany(x => x.BookTransactions)
            .HasForeignKey(x => x.TransactionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
