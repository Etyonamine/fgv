using CSO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO.Domain.Services
{
    public class BookOrderer : IBookOrderer
    {
        public List<Book> Order(List<Book> books, int codigoConfiguracaoOrdem)
        {
            //campo: Título ordencao: ascendente
             if (codigoConfiguracaoOrdem == 1)
            {
                books = books.OrderBy(x => x.Title).ToList();

            }
            /*campo: Autor ordenação: ascendente + campo: "Título" ordencao: "descendente"*/
            else if(codigoConfiguracaoOrdem == 2) 
             {
                books = books.OrderBy(x => x.Author).ThenByDescending(x=>x.Title).ToList();
            }
            //campo: Edição ordenação:descendente + campo: "Autor"  ordencao: "descendente" + campo: "Autor"  "Título" + ordencao:"ascendente"
            else if (codigoConfiguracaoOrdem == 3)
            {
                books = books.OrderByDescending(x => x.Edition).ThenByDescending(x => x.Author).ThenBy(x=>x.Title).ToList();
            }



            return books;
        }

    }
}
