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
    public class TeachersController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public TeachersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<CreateTeacherService> Post(TeacherRequest request)
        {
            CreateTeacherService _service = new CreateTeacherService(_unitOfWork);
            CreateTeacherResponse response = _service.Execute(request);
            return Ok(response);
        }


        [HttpGet]
        public IEnumerable<Teacher> Gets()
        {
            CreateTeacherService _service = new CreateTeacherService(_unitOfWork);
            var teachers = _service.ConsultAll();
            return teachers;
        }

    }
}
