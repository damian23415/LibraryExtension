using LibraryExtension.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryExtension.Infrastructure.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.Property(x => x.RentDate)
            .IsRequired();


        builder
            .HasOne<Reader>(x => x.Reader)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.ReaderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}