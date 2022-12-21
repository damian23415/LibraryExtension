using LibraryExtension.Application.Interfaces;
using LibraryExtension.Domain.Entities;
using LibraryExtension.Domain.Enums;
using LibraryExtension.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Application.Implementations;

public class ReaderService : IReaderService
{
    private readonly ApplicationDbContext _context;

    public ReaderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Reader> AddReader(Reader reader)
    {
        using (_context)
        {
            var readerPeselAlreadyExists = await _context.Reader.FirstOrDefaultAsync(x => x.Pesel == reader.Pesel);
            if (readerPeselAlreadyExists != null)
                throw new Exception("Użytkownik z podanym numerem PESEL już istnieje w bazie, nie można stworzyć takiego użytkownika");

            await _context.Reader.AddAsync(reader);
            await _context.SaveChangesAsync();

            return reader;
        }
    }

    public async Task<Reader> Promote(int readerId, ReaderTypeEnum readerType)
    {
        using (_context)
        {
            var employee = await _context.Reader.FirstOrDefaultAsync(x => x.Id == readerId);

            if (employee == null)
                throw new Exception("Nie ma takiego pracownika");

            if (employee.ReaderTypeEnum == readerType)
                throw new Exception("Nie możesz się awansować na tego kim jesteś");

            if (employee.ReaderTypeEnum == ReaderTypeEnum.Pracownik)
                throw new Exception("Jeteś pracownikiem i nie można zmienić twojej posady");

            if (employee.ReaderTypeEnum == ReaderTypeEnum.Wykladowca)
            {
                if (readerType == ReaderTypeEnum.Pracownik)
                    employee.ReaderTypeEnum = ReaderTypeEnum.Pracownik;
                else
                    throw new Exception("Nie możesz zostać studentem");
            }

            if (employee.ReaderTypeEnum == ReaderTypeEnum.Student)
                employee.ReaderTypeEnum = readerType;

            await _context.SaveChangesAsync();
            return employee;
        }
    }

    public async Task<Reader> RemoveReader(int readerId)
    {
        using (_context)
        {
            var reader = await _context.Reader.FirstOrDefaultAsync(x => x.Id == readerId);
            if (reader is null)
                throw new Exception("Nie ma takiego czytelnika, którego chcesz usunąć");
            else
            {
                _context.Reader.Remove(reader);
                await _context.SaveChangesAsync();
                return reader;
            }
        }
    }

    public async Task<Reader> UpdateReader(int readerId, Reader reader)
    {
        var readerToEdit = await _context.Reader.FirstOrDefaultAsync(x => x.Id == readerId);
        if (readerToEdit is null)
            throw new Exception("Nie ma czytelnika, którego chcesz edytować w bazie");
        else
        {
            var pesel = _context.Reader.FirstOrDefaultAsync(x => x.Pesel == reader.Pesel).Result;
            if (pesel is not null)
                throw new Exception("Nie możesz edytować na tkai numer pesel ponieważ taki pesel już istnieje w bazie");
            else
            {
                readerToEdit.Pesel = reader.Pesel;
                readerToEdit.Name = reader.Name;
                readerToEdit.Surname = reader.Surname;
                readerToEdit.ReaderTypeEnum = reader.ReaderTypeEnum;
            }

            await _context.SaveChangesAsync();
            return readerToEdit;
        }
    }

    public async Task<Reader> GetReader(int readerId)
    {
        var reader = await _context.Reader.FirstOrDefaultAsync(x => x.Id == readerId);
        if (reader is null)
            throw new Exception("Nie ma takiego czytelnika w bazie danych");
        else
            return reader;
    }

    public async Task<decimal> CalculateFine(int readerId)
    {
        using (_context)
        {
            var reader = await _context.Reader.FirstOrDefaultAsync(x => x.Id == readerId);
            if (reader is null)
                throw new Exception("Nie ma takiego czytelnika w bazie");

            var transactions = await _context.Transaction.Where(x => x.ReaderId == readerId).ToListAsync();

            if (transactions is null)
                throw new Exception("Taki użytkownik nie ma żadnej transakcji");

            transactions = transactions.Where(x => x.ReturnDate is not null).ToList();

            var fine = reader.ReaderTypeEnum switch
            {
                ReaderTypeEnum.Wykladowca => LecturerFine(transactions),
                ReaderTypeEnum.Student => StudentFine(transactions),
                ReaderTypeEnum.Pracownik => EmployeeFine(transactions)
            };

            return fine;
        }
    }

    private static decimal EmployeeFine(IEnumerable<Transaction> transactions)
    {
        var fine = 0;
        foreach (var transaction in transactions.Where(x => (x.ReturnDate - x.ExpectedReturnDate).Value.Days > 28))
        {
            var days = (transaction.ReturnDate - transaction.ExpectedReturnDate).Value.Days - 28;
            fine += 5 * days;
        }
        return fine;
    }

    private static decimal StudentFine(IEnumerable<Transaction> transactions)
    {
        var fine = 0;
        foreach (var transaction in transactions)
        {
            var days = (transaction.ReturnDate - transaction.ExpectedReturnDate).Value.Days;
            if (days > 28)
                fine += 10 * (days - 28);
            else if (days > 14)
                fine += 5 * (days - 14);
            else if (days > 7)
                fine += 2 * (days - 7);
            else if (days > 0)
                fine += days;
        }
        return fine;
    }

    private static decimal LecturerFine(IEnumerable<Transaction> transactions)
    {
        var fine = 0;
        foreach (var transaction in transactions.Where(x => (x.ReturnDate - x.ExpectedReturnDate).Value.Days > 3))
        {
            var days = (transaction.ReturnDate - transaction.ExpectedReturnDate).Value.Days;
            if (days > 28)
                fine += 10 * (days - 28);
            else if (days > 14)
                fine += 5 * (days - 14);
            else if (days > 3)
                fine += 2 * (days - 3);
        }
        return fine;
    }
}
