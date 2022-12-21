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
    [Required]
    public DateTime RentDate { get; set; }
    [Required]
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    [Required]
    public int ReaderId { get; set; }
    public virtual Reader Reader { get; set; }

    [Required]
    public int BookId { get; set; }
    public virtual Book Book { get; set; }

}
