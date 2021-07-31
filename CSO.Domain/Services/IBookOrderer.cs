using CSO.Domain.Entities;
using System.Collections.Generic;

namespace CSO.Domain.Services
{
    public interface IBookOrderer
    {
        List<Book> Order(List<Book> books, int codigoConfiguracaoOrdem);
    }
}
