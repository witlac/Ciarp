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
    public class RequestsController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public RequestsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpPost]
        public ActionResult<CreateArticleService> Post(SendRequestProperties request)
        {
            SendRequestService _service = new SendRequestService(_unitOfWork);
            CreateRequestResponse response = _service.SendArticle(request);
            return Ok(response);
        }

        [HttpGet]
        public IEnumerable<Request> Gets()
        {
            SendRequestService _service = new SendRequestService(_unitOfWork);
            var requests = _service.ConsultAll();
            return requests;
        }


    }
}
