using LibraryExtension.Application.Interfaces;
using LibraryExtension.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Application.Implementations;

public class Reader : IReader
{
    private readonly ApplicationDbContext _context;

    public Reader(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Reader> AddReader(Domain.Entities.Reader reader)
    {
        using (_context)
        {
            var newReader = new Domain.Entities.Reader()
            {
                Name = reader.Name,
                Surname = reader.Surname,
                Pesel = reader.Pesel,
                ReaderTypeEnum = reader.ReaderTypeEnum
            };

            var readerPeselAlreadyExists = await _context.Reader.FirstOrDefaultAsync(x => x.Pesel == newReader.Pesel);

            if (readerPeselAlreadyExists != null)
            {
                _context.Reader.Add(newReader);
                _context.SaveChangesAsync();
                return newReader;
            }

            throw new Exception("Użytkownik z podanym numerem PESEL już istnieje w bazie, nie można stworzyć takiego użytkownika");
        }
    }
}
