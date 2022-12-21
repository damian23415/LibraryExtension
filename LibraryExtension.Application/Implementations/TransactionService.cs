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

public class TransactionService : ITransactionService
{
    private readonly ApplicationDbContext _context;

    public TransactionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Transaction> BorrowBook(int bookId, int readerId, int rentalDays)
    {
        using (_context)
        {
            var book = await _context.Book.FirstOrDefaultAsync(x => x.Id == bookId);
            if (book == null)
            {
                throw new Exception("Nie ma takiej książki");
            }

            if(book.BookAmount == 0)
            {
                throw new Exception("Liczba egzemplarzy jest równa 0");
            }

            var transactions = await _context.Transaction.Where(x => x.BookId == bookId).ToListAsync();

            if (transactions != null && transactions.Count(x => x.ReturnDate is null) == book.BookAmount)
            {
                throw new Exception("Nie ma dostępnych książek do wypożyczenia");
            }

            var newTransaction = new Transaction()
            {
                BookId = bookId,
                ReaderId = readerId,
                RentDate = DateTime.UtcNow,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(rentalDays),
            };

            await _context.AddAsync(newTransaction);
            await _context.SaveChangesAsync();

            return newTransaction;
        }
    }

    public async Task<Transaction> ReturnBook(int transactionId)
    {
        using(_context)
        {
            var transaction = await _context.Transaction.FirstOrDefaultAsync(x => x.Id == transactionId);
            if (transaction == null)
            {
                throw new Exception("Nie ma takiej transakcji");
            }

            transaction.ReturnDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return transaction;
        }
    }
}
