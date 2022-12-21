using LibraryExtension.Domain.Entities;
using LibraryExtension.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LibraryExtension.Infrastructure.Extensions;

public static class ModelBuilderExtensionsReader
{
    public static void SeedReader(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reader>().HasData(
            new Reader
            {
                Id = 1,
                Name = "Franciszek",
                Surname = "Kowalski",
                Pesel = "12312312311",
                ReaderTypeEnum = ReaderTypeEnum.Wykladowca
            },
            new Reader
            {
                Id = 2,
                Name = "Julia",
                Surname = "Nowak",
                Pesel = "12312312311",
                ReaderTypeEnum = ReaderTypeEnum.Pracownik
            },
            new Reader
            {
                Id = 3,
                Name = "Jan",
                Surname = "Wiśniewski",
                Pesel = "12312312311",
                ReaderTypeEnum = ReaderTypeEnum.Wykladowca
            },
            new Reader
            {
                Id = 4,
                Name = "Maja",
                Surname = "Wójcik",
                Pesel = "12312312311",
                ReaderTypeEnum = ReaderTypeEnum.Student
            },
            new Reader
            {
                Id = 5,
                Name = "Zofia",
                Surname = "Kowalczyk",
                Pesel = "12312312311",
                ReaderTypeEnum = ReaderTypeEnum.Student
            });
    }
}
