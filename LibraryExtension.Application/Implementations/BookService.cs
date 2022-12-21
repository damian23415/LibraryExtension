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

    public async Task<Book> GetBook(int bookId)
    {
        using(_context)
        {
            var book = await _context.Book.FirstOrDefaultAsync(x => x.Id == bookId);
            if (book is null)
                throw new Exception("Nie ma takiej książki, którą chcesz pobrać");
            else
                return book;
        }
    }

    public async Task<Book> RemoveBook(int bookId)
    {
        using(_context)
        {
            var book = await _context.Book.FirstOrDefaultAsync(x => x.Id == bookId);
            if (book is null)
                throw new Exception("Nie ma takiej książki, którą chcesz usunąć");
            else
            {
                _context.Book.Remove(book);
                await _context.SaveChangesAsync();
                return book;
            }
        }
    }

    public async Task<Book> UpdateBook(int bookId, Book book)
    {
        using(_context)
        {
            var bookToEdit = await _context.Book.FirstOrDefaultAsync(x => x.Id == bookId);
            if (bookToEdit is null)
                throw new Exception("Nie możesz edytować książki, której nie ma w bazie");
            else
            {
                bookToEdit.Author = book.Author;
                bookToEdit.Title = book.Title;
                bookToEdit.BookAmount = book.BookAmount;

                await _context.SaveChangesAsync();

                return bookToEdit;
            }
        }
    }
}
