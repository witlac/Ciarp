using Domain.Entities;
using NUnit.Framework;
using System;

namespace Domain.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegistrarSolicitudPonenciaInternacionalMenosDeTresAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 2;
            even.EventDate = DateTime.Now;
            even.EventType = "Internacional";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Madrid";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual(request.EstimatedPoints, 84);
        }

        [Test]
        public void RegistrarSolicitudPonenciaInternacionalMenosDeCincoAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 5;
            even.EventDate = DateTime.Now;
            even.EventType = "Internacional";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Madrid";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            Suport suport = new Suport();
            suport.Name = "asdas";
            even.AddSuport(suport);
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual(42, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudPonenciaInternacionalMasDeCincoAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 7;
            even.EventDate = DateTime.Now;
            even.EventType = "Internacional";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Madrid";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual(24, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudPonenciaInternacionalCeroAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 0;
            even.EventDate = DateTime.Now;
            even.EventType = "Internacional";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Madrid";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => even.RequestEvaluate());
            Assert.AreEqual("Numero de autores invalido", ex.Message);
        }

        [Test]
        public void RegistrarSolicitudPonenciaNacionalMenosDeTresAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 2;
            even.EventDate = DateTime.Now;
            even.EventType = "Nacional";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Bogota";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual(request.EstimatedPoints, 48);
        }

        [Test]
        public void RegistrarSolicitudPonenciaNacionalMenosDeCincoAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 5;
            even.EventDate = DateTime.Now;
            even.EventType = "Nacional";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Bogota";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual(24, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudPonenciaNacionalMasDeCincoAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 7;
            even.EventDate = DateTime.Now;
            even.EventType = "Nacional";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Valledupar";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual("13,714", string.Format("{0:0.000}", request.EstimatedPoints) );
        }

        [Test]
        public void RegistrarSolicitudPonenciaLocalMenosDeTresAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 2;
            even.EventDate = DateTime.Now;
            even.EventType = "Local";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Valledupar";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual(24, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudPonenciaLocalMenosDeCincoAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 5;
            even.EventDate = DateTime.Now;
            even.EventType = "Local";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Valledupar";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
           
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual(12, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudPonenciaLocalMasDeCincoAutores()
        {
            var even = new Event();
            even.Title = "Seminario";
            even.Name = "Patrones Gof";
            even.NumberOfAuthors = 7;
            even.EventDate = DateTime.Now;
            even.EventType = "Local";
            even.Credit = true;
            even.EventWeb = "www.adad.com";
            even.EventPlace = "Valledupar";
            even.Memories = "memories";
            even.Isbn = "131A";
            even.Issn = "1544S";
            
            Request request = new Request(even);
            request.SendRequest();
            Assert.AreEqual("6,857", string.Format("{0:0.000}", request.EstimatedPoints));
        }

        [Test]
        public void RegistrarSolicitudArticuloTradicionalA1MenosDeTresAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 2;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "A1";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
           
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(15, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloTradicionalA2MenosDeTresAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 2;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "A2";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(12, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloTradicionalBMenosDeTresAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 2;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "B";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(8, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloTradicionalCMenosDeTresAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 2;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "C";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(3, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloTradicionalA1MenosDeCincoAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 5;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "A1";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual("7,5", string.Format("{0:0.0}", request.EstimatedPoints));
        }

        [Test]
        public void RegistrarSolicitudArticuloTradicionalA2MenosDeCincoAtuores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 5;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "A2";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(6,request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloTradicionalBMasDeCincoAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 7;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "B";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual("2,29", string.Format("{0:0.00}", request.EstimatedPoints));
        }

        [Test]
        public void RegistrarSolicitudArticuloTradicionalCMasDeCincoAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 7;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "C";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
           
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual("0,857", string.Format("{0:0.000}", request.EstimatedPoints));
        }

        [Test]
        public void RegistrarSolicitudArticuloCortoA1MenosDeTresAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 2;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "A1";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Corto";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(9, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloCortoA2MenosDeTresAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 2;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "A2";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Corto";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(7.2M, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloCortoBMenosDeTresAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 2;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "B";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Corto";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(4.8, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloCortoCMenosDeTresAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 2;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "C";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Corto";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(1.8, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudArticuloCortoA1MenosDeCincoAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 5;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "A1";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Corto";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual("4,50", string.Format("{0:0.00}", request.EstimatedPoints));
        }

        [Test]
        public void RegistrarSolicitudArticuloCortoA2MenosDeCincoAtuores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 5;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "A2";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Corto";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual(3.6, request.EstimatedPoints);
        }

        [Test]
        public void RegistrarSolicitudCortoCortoBMasDeCincoAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 7;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "B";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Corto";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual("1,371", string.Format("{0:0.000}", request.EstimatedPoints));
        }

        [Test]
        public void RegistrarSolicitudArticuloCortoCMasDeCincoAutores()
        {
            var article = new Article();
            article.Title = "Realidad Aumentada";
            article.NumberOfAuthors = 7;
            article.Credit = true;
            article.Issn = "1544S";
            article.JournalType = "C";
            article.JournalName = "Nature";
            article.ArticleType = "Articulo Tradicional";
            article.Language = "Español";
            
            Request request = new Request(article);
            request.SendRequest();
            Assert.AreEqual("0,9", string.Format("{0:0.0}", request.EstimatedPoints));
        }

        [Test]
        public void RegistrarSolicitudSoftwareCorrectamente()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
           
            Request request = new Request(software);
            request.SendRequest();
            Assert.AreEqual(request.EstimatedPoints, 15);
        }

        [Test]
        public void RegistrarSolicitudSoftwareAutoresMenor0()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 0;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
            
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => software.RequestEvaluate());

            Assert.AreEqual(ex.Message, "Numero de autores invalido, debe ser mayo a 0");
        }

        [Test]
        public void RegistrarSolicitudLibroAutoresMenor3()
        {
            var book = new Book();
            book.Title = "Ciarp";
            book.NumberOfAuthors =2;
            book.Title = "Ready Player One";
            book.PublicationDate = DateTime.Now;
            book.Languaje = "Español";
            book.Isbn = "assd";
            book.Credit = true;
            book.BookType = "Libro de ensayo";

            Request request = new Request(book);
            request.SendRequest();
            Assert.AreEqual(15, request.EstimatedPoints);
        }

        [Test]
        public void CambiarEstadoSolicitudRecibido()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
           
            Request request = new Request(software);
            request.SendRequest();
            request.RequestState(1);

            Assert.AreEqual("Recibido", request.State);
        }

        [Test]
        public void CambiarEstadoSolicitudAprobado()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
            
            Request request = new Request(software);
            request.SendRequest();
            request.RequestState(2);

            Assert.AreEqual( "Aprobado",request.State);
        }

        [Test]
        public void CambiarEstadoSolicitudInvalidoMayorA3()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
            
            Request request = new Request(software);
            request.SendRequest();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => request.RequestState(4));

            Assert.AreEqual("Estado invalido", ex.Message);
        }

        [Test]
        public void CambiarEstadoSolicitudInvalidoMenorA0()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
            
            Request request = new Request(software);
            request.SendRequest();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => request.RequestState(0));

            Assert.AreEqual("Estado invalido",ex.Message);
        }

        [Test]
        public void EvaluarSolicitudAceptandoPuntosEstimados()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
            
            Request request = new Request(software);
            request.SendRequest();
            request.RequestState(2);
            request.Evaluate(true);

            Assert.AreEqual(request.EstimatedPoints, request.AssignedPoints);
        }

        [Test]
        public void EvaluarSolicitudAsignandoPuntajeMenor0()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
            
            Request request = new Request(software);
            request.SendRequest();
            request.RequestState(2);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => request.Evaluate(-1));
            Assert.AreEqual("Asignacion de puntaje incorrecta, debe ser mayor a 0", ex.Message);
        }

        [Test]
        public void EvaluarSolicitudAsignandoPuntajeCorrectoIgualA15()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
            
            Request request = new Request(software);
            request.SendRequest();
            request.RequestState(2);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => request.Evaluate(15));
            Assert.AreEqual("Solicitud evaluada exitosamente, su puntaje asignado es 15", ex.Message);
        }

        [Test]
        public void RealizarReclamo()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
            
            Request request = new Request(software);
            request.SendRequest();
            request.RequestState(2);
            var claim = new Claim();
            claim.RequestClaim("No estoy conforme, por esto...");
            Assert.AreEqual("No estoy conforme, por esto...", claim.Description);
        }

        [Test]
        public void ResponderReclamo()
        {
            var software = new Software();
            software.Title = "Ciarp";
            software.NumberOfAuthors = 2;
            software.AddAuthors("Rafael Camelo");
            software.AddAuthors("Cristian Mejia");
            software.Credit = true;
            software.Headline = "Eydy Perez";
           
            Request request = new Request(software);
            request.SendRequest();
            request.RequestState(2);
            var claim = new Claim();
            claim.RequestClaim("No estoy conforme, por esto...");
            claim.AnswerClaim("La decicion del comite fue unanime por esto...");
            Assert.AreEqual("La decicion del comite fue unanime por esto...", claim.Answer);
        }


    }
}