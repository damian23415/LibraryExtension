using LibraryExtension.Domain.Entities;
using LibraryExtension.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Application.Interfaces;

public interface IReaderService
{
    Task<Reader> AddReader(Reader reader);
    Task<Reader> Promote(int readerId, ReaderTypeEnum readerTypeEnum);
    Task<decimal> CalculateFine(int readerId);
    Task<Reader> RemoveReader(int readerId);
    Task<Reader> UpdateReader(int readerId, Reader reader);
    Task<Reader> GetReader(int readerId);
}
