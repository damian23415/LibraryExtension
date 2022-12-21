using LibraryExtension.Domain.Entities;
using LibraryExtension.Infrastructure;
using LibraryExtension.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Application.Implementations;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _context;

    public BookService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Book> AddBook(Book book)
    {
        using(_context)
        {
            var bookAlreadyExist = await _context.Book.FirstOrDefaultAsync(x => x.Title == book.Title);
            if (bookAlreadyExist != null)
            {
                bookAlreadyExist.BookAmount += 1;

                await _context.SaveChangesAsync();
                return bookAlreadyExist;
            }

            var newBook = new Domain.Entities.Book()
            {
                Author = book.Author,
                Title = book.Title,
                BookAmount = 1
            };

            await _context.Book.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook;
        }
    }
}
