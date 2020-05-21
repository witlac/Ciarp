using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure;
using Domain.Contracts;
using Application;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
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
