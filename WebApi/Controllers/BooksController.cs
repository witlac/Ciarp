using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infrastructure;
using Domain.Contracts;
using Application;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<CreateBookService> Post(CreateBookRequest request)
        {
            CreateBookService _service = new CreateBookService(_unitOfWork);
            CreateBookResponse response = _service.CreateBook(request);
            return Ok(response);
        }

        [HttpGet]
        public IEnumerable<Book> Gets()
        {
            CreateBookService _service = new CreateBookService(_unitOfWork);
            var books = _service.ConsultAll();
            return books;
        }

    }
}
