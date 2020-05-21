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
using Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwaresController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public SoftwaresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<CreateEventService> Post(CreateEventRequest request)
        {
            CreateEventService _service = new CreateEventService(_unitOfWork);
            CreateEventResponse response = _service.Execute(request);
            return Ok(response);
        }

        [HttpGet]
        public IEnumerable<Event> Gets()
        {
            CreateEventService _service = new CreateEventService(_unitOfWork);
            var events = _service.ConsultAll();
            return events;
        }

    }
}
