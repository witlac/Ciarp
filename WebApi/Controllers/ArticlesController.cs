using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infrastructure;
using Application;
using Domain.Contracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public ArticlesController( IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<CreateArticleService> Post(ArticleRequest request)
        {
            CreateArticleService _service = new CreateArticleService(_unitOfWork);
            CreateArticleResponse response = _service.Execute(request);
            return Ok(response);
        }

  
        [HttpGet]
        public IEnumerable<Article> Gets()
        {
            CreateArticleService _service = new CreateArticleService(_unitOfWork);
            var articles = _service.ConsultAll();
            return articles;
        }


    }
}
