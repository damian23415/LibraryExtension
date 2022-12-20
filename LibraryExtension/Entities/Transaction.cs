using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public int ReaderId { get; set; }
    public Reader Reader { get; set; }

    public ICollection<BookTransaction> BookTransactions { get; set; }
}
