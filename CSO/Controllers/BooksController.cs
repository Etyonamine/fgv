using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSO.Entities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using CSO.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _iBookService;
        private readonly IConfiguration _config;

        public BooksController(IConfiguration config, IBookService iBookService)
        {
            _config = config;
            _iBookService = _iBookService;
        }

        // GET api/<BooksController>/5
        [HttpPost]
        [ProducesResponseType(201,
            Type = typeof(List<Book>))]
        [ProducesResponseType(400)]
        [Route("v1/Ordenar")]
        public List<Book> Ordenar([FromBody] List<Book> books)
        {
             
            var listaRetorno = _iBookService.Ordernar(books);
            
            
            return books;
        }

       
    }
}
