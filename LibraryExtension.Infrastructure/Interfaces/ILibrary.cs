using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryExtension.Infrastructure.Interfaces;

public interface ILibrary
{
    public decimal CalculateFine(Transaction transaction);
}
