using Application;
using Domain;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Aplicattion.Test
{
    public class Tests
    {
        CiarpContext _context;
        [SetUp]
        public void Setup()
        {
           /* var optionsSqlServer = new DbContextOptionsBuilder<CiarpContext>()
                .UseSqlServer("Server=.\\;Database=Ciarp;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;*/
            var optionsInMemory = new DbContextOptionsBuilder<CiarpContext>().UseInMemoryDatabase("Ciarp").Options;
            _context = new CiarpContext(optionsInMemory);
        }

        [Test]
        public void CrearDocente()
        {

            var requestUser = new UserRequest { Name = "cjhair", Password = "123" };

            CreateUserService _service = new CreateUserService(new UnitOfWork(_context));
            var responseUser = _service.Execute(requestUser);
            User user = _service.Consult(requestUser.Name);
            var requestTeacher = new TeacherRequest {
                Name = "Cristian",
                Category = "Planta",
                DedicationTime = "12h",
                DocumentType = "CC",
                DocumentId = "1035",
                Email = "cjhair@gmail.com",
                InvestigationGroup = "Gisco",
                Phone = "12345",
                User = user
            };
            CreateTeacherService _teacherService = new CreateTeacherService(new UnitOfWork(_context));
            var responseTeacher = _teacherService.Execute(requestTeacher);
            Assert.AreEqual("Se creo con exito el docente Cristian.", responseTeacher.Menssage);


        }

        [Test]
        public void CrearDocenteConIdRepetida()
        {

            var requestUser = new UserRequest { Name = "cjhair", Password = "123" };

            CreateUserService _service = new CreateUserService(new UnitOfWork(_context));
            var responseUser = _service.Execute(requestUser);
            User user = _service.Consult(requestUser.Name);
            var requestTeacher = new TeacherRequest
            {
                Name = "Cristian",
                Category = "Planta",
                DedicationTime = "12h",
                DocumentType = "CC",
                DocumentId = "1035",
                Email = "cjhair@gmail.com",
                InvestigationGroup = "Gisco",
                Phone = "12345",
                User = user
            };
            CreateTeacherService _teacherService = new CreateTeacherService(new UnitOfWork(_context));
            var responseTeacher = _teacherService.Execute(requestTeacher);
            Assert.AreEqual("Ya existe un docente registrado con esa id", responseTeacher.Menssage);


        }

        [Test]
        public void CrearUsuarioConNombreExistente()
        {

            var requestUser = new UserRequest { Name = "cjhair", Password = "123" };

            CreateUserService _service = new CreateUserService(new UnitOfWork(_context));
            var responseUser = _service.Execute(requestUser);
          
            Assert.AreEqual("Ya existe un usuario con ese nombre", responseUser.Menssage);


        }


        [Test]
        public void EnviarSolicitudArticulo()
        {

            CreateArticleService _articleService = new CreateArticleService(new UnitOfWork(_context));
            var articleRequest = new ArticleRequest { ArticleType = "Articulo Tradicional", Title = "Realidad Aumentada", NumberOfAuthors = 2, Credit = true, Issn = "1213s", JournalName = "Nature", JournalType = "A1", Language = "Español" };
            _articleService.Execute(articleRequest);

            Article article = _articleService.Consult(articleRequest.Title);
            SendRequestService _sendRequestService = new SendRequestService(new UnitOfWork(_context));
            var propertiesRequest = new CreateRequestProperties { Productivity = article };
            var responseRequest = _sendRequestService.Execute(propertiesRequest);

            Assert.AreEqual("La solicitud de la productividad Realidad Aumentada fue enviada con exito, su puntaje estimado es 15.", responseRequest.Menssage);

        }

        [Test]
        public void EnviarSolicitudLibro()
        {

            CreateBookService _bookService = new CreateBookService(new UnitOfWork(_context));
            var bookRequest = new CreateBookRequest { Title = "DDD", NumberOfAuthors = 2, Credit = true , BookType = "Libro de ensayo", Editorial="Norma",Isbn="asaa",Languaje="Español",PublicationDate=DateTime.Now};
            _bookService.Execute(bookRequest);

            Book book = _bookService.Consult(bookRequest.Title);
            SendRequestService _sendRequestService = new SendRequestService(new UnitOfWork(_context));
            var propertiesRequest = new CreateRequestProperties { Productivity = book };
            var responseRequest = _sendRequestService.Execute(propertiesRequest);

            Assert.AreEqual("La solicitud de la productividad DDD fue enviada con exito, su puntaje estimado es 15.", responseRequest.Menssage);

        }

        [Test]
        public void EnviarSolicitudEvent()
        {

            CreateEventService _eventService = new CreateEventService(new UnitOfWork(_context));
            var eventRequest = new CreateEventRequest {Title = "Ready Player One", NumberOfAuthors = 2, Credit = true, EventPlace="",EventType="Internacional",Isbn="ssad",Issn="asdfas",Languaje="Español",Memories="carlos",Name="Mineria de datos en la actualidad",EventWeb="www.con.com",EventDate=DateTime.Now};
            _eventService.Execute(eventRequest);

            Event events = _eventService.Consult(eventRequest.Isbn);
            
            SendRequestService _sendRequestService = new SendRequestService(new UnitOfWork(_context));
            var propertiesRequest = new CreateRequestProperties { Productivity = events };
            var responseRequest = _sendRequestService.Execute(propertiesRequest);

            Assert.AreEqual("La solicitud de la productividad Ready Player One fue enviada con exito, su puntaje estimado es 84.", responseRequest.Menssage);

        }

        [Test]
        public void EnviarSolicitudSoftware()
        {

            CreateSoftwareService _softwareService = new CreateSoftwareService(new UnitOfWork(_context));
            var softwareRequest = new CreateSoftwareRequest { Title = "Ciarp", NumberOfAuthors = 2, Credit = true, Headline="Rafael",Impact="yes"};
            _softwareService.Execute(softwareRequest);

            Software article = _softwareService.Consult(softwareRequest.Title);
            SendRequestService _sendRequestService = new SendRequestService(new UnitOfWork(_context));
            var propertiesRequest = new CreateRequestProperties { Productivity = article };
            var responseRequest = _sendRequestService.Execute(propertiesRequest);

            Assert.AreEqual("La solicitud de la productividad Ciarp fue enviada con exito, su puntaje estimado es 15.", responseRequest.Menssage);

        }
    }
}