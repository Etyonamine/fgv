using CSO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSO.Repository
{
    public interface IBookService
    {
        List<Book> Order(List<Book> books, List<Order> listOrder);
    }
}
