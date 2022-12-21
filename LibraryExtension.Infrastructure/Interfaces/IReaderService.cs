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
    public Task<Reader> AddReader(Reader reader);
    public Task<Reader> Promote(int readerId, ReaderTypeEnum readerTypeEnum);
    public Task<decimal> CalculateFine(int readerId);
}
