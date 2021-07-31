using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSO.Domain.Entities;
using CSO.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace CSO.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookOrderer _iBookService;
        private readonly IConfiguration _iConfig;


        public BooksController(IBookOrderer iBookService, IConfiguration iConfig)
        {
            this._iBookService = iBookService;
            this._iConfig = iConfig;
        }

        [HttpPost]
        [ProducesResponseType(201,Type = typeof(List<Book>))]
        [ProducesResponseType(400)]
        [Route("v1/Ordenar")]
        public ActionResult<List<Book>>  Ordenar([FromBody] List<Book> books)
        {
            try
            {
                    //validar se o objeto possui uma lista e/ou o objeto da lista possui todas os valores necessarios
                    ValidateBooks(books);

                    //recuperar a sequencia de ordem parametrizado no appsettings.json
                    var codigoConfiguracaoOrdem = _iConfig.GetSection("Order:Configuracao").Get<int>();

                    //validar se encontrou informações
                    if (codigoConfiguracaoOrdem == 0)
                    {
                        return null;

                        throw new Exception("No Ordering has been configured!");
                    }

                    //executando a ordenação
                    return _iBookService.Order(books, codigoConfiguracaoOrdem);                                     
                
            }
            catch (Exception ex)
            {              

                string message = "Error: " + ex.Message.ToString();               
                throw;
                
            }            
        }

        private static void ValidateBooks(List<Book> listBooks)
        {
             if (listBooks == null|| listBooks.Count == 0 )
            {
                throw new ArgumentNullException("list book is null");
            }
             foreach(Book book in listBooks)
            {
                if (string.IsNullOrEmpty(book.Title))
                {
                    throw new ArgumentNullException("Title cannot be null ");
                }
                else if (string.IsNullOrEmpty(book.Author))
                {
                    throw new ArgumentNullException("Author cannot be null ");
                }
                if (string.IsNullOrEmpty(book.Edition.ToString()))
                {
                    throw new ArgumentNullException("Edition cannot be null ");
                }
            }
        }
    }
}
