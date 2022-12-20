using LibraryExtension.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Application.Interfaces;

public interface IReader
{
    public Task<Reader> AddReader(Reader reader);
}
