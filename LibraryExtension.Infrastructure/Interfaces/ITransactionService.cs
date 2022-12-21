using LibraryExtension.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Infrastructure.Interfaces;

public interface ITransactionService
{
    Task<Transaction> BorrowBook(int bookId, int readerId, int rentalDays);
    Task<Transaction> ReturnBook(int transactionId);
    Task<Transaction> RemoveTransaction(int transactionId);
    Task<Transaction> UpdateTransaction(int transactionId, Transaction transaction);
    Task<Transaction> GetTransaction(int transactionId);
}
