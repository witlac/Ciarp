using Application;
using Domain;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Aplicattion.Test
{
    public class Tests
    {
        CiarpContext _context;
        [SetUp]
        public void Setup()
        {
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
        public void EnviarSolicitudArticulo()
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

            CreateArticleService _articleService = new CreateArticleService(new UnitOfWork(_context));
            var articleRequest = new ArticleRequest { ArticleType = "Articulo Tradicional", Title = "Realidad Aumentada", NumberOfAuthors = 2, Credit = true, Issn = "1213s", JournalName = "Nature", JournalType = "A1", Language = "Español" };
            _articleService.Execute(articleRequest);

            Article article = _articleService.Consult(articleRequest.Title);
            SendRequestService _sendRequestService = new SendRequestService(new UnitOfWork(_context));
            var propertiesRequest = new CreateRequestProperties { Productivity = article };
            var responseRequest = _sendRequestService.Execute(propertiesRequest);

            Assert.AreEqual("La solicitud del articulo Realidad Aumentada fue enviada con exito, su puntaje estimado es 15.", responseRequest.Menssage);

        }

        [Test]
        public void EnviarSolicitudLibro()
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

            CreateArticleService _articleService = new CreateArticleService(new UnitOfWork(_context));
            var articleRequest = new ArticleRequest { ArticleType = "Articulo Tradicional", Title = "Realidad Aumentada", NumberOfAuthors = 2, Credit = true, Issn = "1213s", JournalName = "Nature", JournalType = "A1", Language = "Español" };
            _articleService.Execute(articleRequest);

            Article article = _articleService.Consult(articleRequest.Title);
            SendRequestService _sendRequestService = new SendRequestService(new UnitOfWork(_context));
            var propertiesRequest = new CreateRequestProperties { Productivity = article };
            var responseRequest = _sendRequestService.Execute(propertiesRequest);

            Assert.AreEqual("La solicitud del articulo Realidad Aumentada fue enviada con exito, su puntaje estimado es 15.", responseRequest.Menssage);

        }

        [Test]
        public void EnviarSolicitudEvent()
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

            CreateArticleService _articleService = new CreateArticleService(new UnitOfWork(_context));
            var articleRequest = new ArticleRequest { ArticleType = "Articulo Tradicional", Title = "Realidad Aumentada", NumberOfAuthors = 2, Credit = true, Issn = "1213s", JournalName = "Nature", JournalType = "A1", Language = "Español" };
            _articleService.Execute(articleRequest);

            Article article = _articleService.Consult(articleRequest.Title);
            SendRequestService _sendRequestService = new SendRequestService(new UnitOfWork(_context));
            var propertiesRequest = new CreateRequestProperties { Productivity = article };
            var responseRequest = _sendRequestService.Execute(propertiesRequest);

            Assert.AreEqual("La solicitud del articulo Realidad Aumentada fue enviada con exito, su puntaje estimado es 15.", responseRequest.Menssage);

        }

        [Test]
        public void EnviarSolicitudSoftware()
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

            CreateArticleService _articleService = new CreateArticleService(new UnitOfWork(_context));
            var articleRequest = new ArticleRequest { ArticleType = "Articulo Tradicional", Title = "Realidad Aumentada", NumberOfAuthors = 2, Credit = true, Issn = "1213s", JournalName = "Nature", JournalType = "A1", Language = "Español" };
            _articleService.Execute(articleRequest);

            Article article = _articleService.Consult(articleRequest.Title);
            SendRequestService _sendRequestService = new SendRequestService(new UnitOfWork(_context));
            var propertiesRequest = new CreateRequestProperties { Productivity = article };
            var responseRequest = _sendRequestService.Execute(propertiesRequest);

            Assert.AreEqual("La solicitud del articulo Realidad Aumentada fue enviada con exito, su puntaje estimado es 15.", responseRequest.Menssage);

        }
    }
}