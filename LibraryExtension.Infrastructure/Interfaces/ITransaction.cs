using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryExtension.Infrastructure.Interfaces;

public interface ITransaction
{
    public Task<Transaction> BorrowBook(Transaction transaction);
    public Task<Transaction> ReturnBook(DateTime dateTime, int transactionId);
}
