using LibraryExtension.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Infrastructure.Interfaces;

public interface ITransactionService
{
    public Task<Transaction> BorrowBook(int bookId, int readerId, int rentalDays);
    public Task<Transaction> ReturnBook(int transactionId);
}
