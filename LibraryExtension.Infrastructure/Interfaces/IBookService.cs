using LibraryExtension.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Infrastructure.Interfaces;

public interface IBookService
{
    Task<Book> AddBook(Book book);
    Task<Book> RemoveBook(int bookId);
    Task<Book> UpdateBook(int bookId, Book book);
    Task<Book> GetBook(int bookId);
}
