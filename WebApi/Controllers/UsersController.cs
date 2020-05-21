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
    public class UsersController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<CreateUserService> Post(UserRequest request)
        {
            CreateUserService _service = new CreateUserService(_unitOfWork);
            CreateUserResponse response = _service.Execute(request);
            return Ok(response);
        }


        [HttpGet]
        public IEnumerable<User> Gets()
        {
            CreateUserService _service = new CreateUserService(_unitOfWork);
            var users = _service.ConsultAll();
            return users;
        }
    }
}
