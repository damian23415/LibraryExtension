using LibraryExtension.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Domain.Entities;

public class Reader
{
    public int Id { get; set; }
    [Required, MaxLength(255)]
    public string Name { get; set; }
    [Required, MaxLength(255)]
    public string Surname { get; set; }
    [Required, StringLength(11)]
    public string Pesel { get; set; }
    [Required]
    public ReaderTypeEnum ReaderTypeEnum { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}
