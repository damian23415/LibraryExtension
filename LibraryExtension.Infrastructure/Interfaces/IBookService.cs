using LibraryExtension.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Infrastructure.Interfaces;

public interface IBookService
{
    public Task<Book> AddBook(Book book);
}
