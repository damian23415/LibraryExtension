using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    [Required, MaxLength(255)]
    public string Title { get; set; }
    [Required, MaxLength(255)]
    public string Author { get; set; }
    [Required]
    public int BookAmount { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}
