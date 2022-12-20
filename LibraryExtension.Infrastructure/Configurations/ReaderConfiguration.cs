using LibraryExtension.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Infrastructure.Configuration;

public class ReaderConfiguration : IEntityTypeConfiguration<Reader>
{
    public void Configure(EntityTypeBuilder<Reader> builder)
    {
        builder.ToTable("Readers");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.Surname)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.ReaderTypeEnum)
            .IsRequired();

        builder
            .HasIndex(x => x.Pesel)
            .IsUnique();
    }
}
