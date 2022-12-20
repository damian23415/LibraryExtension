using LibraryExtension.Infrastructure;
using LibraryExtension.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Application.Implementations;

public class Book : IBook
{
    private readonly ApplicationDbContext _context;

    public Book(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Book> AddBook(Domain.Entities.Book book)
    {
        using(_context)
        {
            var newBook = new Domain.Entities.Book()
            {
                Author = book.Author,
                Title = book.Title,
            };

            var bookAlreadyExist = await _context.Book.FirstOrDefaultAsync(x => x.Title == newBook.Title);
            if (bookAlreadyExist != null)
            {
                newBook.BookAmount += 1;
            }

            _context.Book.Add(newBook);
            _context.SaveChangesAsync();

            return newBook;
        }
    }
}
