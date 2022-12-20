using LibraryExtension.Infrastructure;
using LibraryExtension.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Application.Implementations;

public class Transaction : ITransaction
{
    private readonly ApplicationDbContext _context;

    public Transaction(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Domain.Entities.Transaction> BorrowBook(Domain.Entities.Transaction transaction)
    {
        using (_context)
        {
            var newBorrow = new Domain.Entities.Transaction()
            {
                ReaderId = transaction.ReaderId,
                BookTransactions = transaction.BookTransactions,
                RentDate = transaction.RentDate,
            };
            var book = _context.Transaction.FirstOrDefault(x => x.)
            _context.Transaction.Add(newBorrow);
        }
    }

    public Task<System.Transactions.Transaction> ReturnBook(DateTime dateTime, int transactionId)
    {
        throw new NotImplementedException();
    }
}
