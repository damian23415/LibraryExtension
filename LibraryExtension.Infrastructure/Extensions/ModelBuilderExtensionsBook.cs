using LibraryExtension.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Infrastructure.Extensions;

public static class ModelBuilderExtensionsBook
{
    public static void SeedBook(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Author = "Julian Tuwim",
                BookAmount = 1,
                Title = "Cztery żaby w jednym stawie"
            },
            new Book
            {
                Id = 2,
                Author = "Nesbo Joe",
                BookAmount = 3,
                Title = "Krwawy Księżyc"
            },
            new Book
            {
                Id = 3,
                Author = "Remigiusz Mróz",
                BookAmount = 2,
                Title = "Z pierwszej piłki"
            },
            new Book
            {
                Id = 4,
                Author = "Ansyway",
                BookAmount = 4,
                Title = "Paulina Świst"
            },
            new Book
            {
                Id = 5,
                Author = "Schronisko, które przestało istniec",
                BookAmount = 1,
                Title = "Sławomir Gortych"
            });
    }
}