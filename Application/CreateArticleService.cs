using Domain;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CreateArticleService
    {
        readonly IUnitOfWork _unitOfWork;
        public CreateArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateArticleResponse Execute(ArticleRequest request)
        {
            AcademicProductivity article = _unitOfWork.ArticleRepository.FindFirstOrDefault(t => t.Title == request.Title && t.Issn == request.Issn);
            if(article == null)
            {
                Article newArticle = new Article();
                newArticle.Title = request.Title;
                newArticle.Credit = request.Credit;
                newArticle.Issn = request.Issn;
                newArticle.JournalType = request.JournalType;
                newArticle.JournalName = request.JournalName;
                newArticle.ArticleType = request.ArticleType;
                newArticle.Language = request.Language;
                newArticle.NumberOfAuthors = request.NumberOfAuthors;
                _unitOfWork.ArticleRepository.Add(newArticle);
                _unitOfWork.Commit();
                return new CreateArticleResponse() { Menssage = $"Se creo con exito el articulo {newArticle.Title}." };                
            }
            else
            {
                return new CreateArticleResponse() { Menssage = $"No se pudo completar el registro porque un articulo igual ya esta registrado" };
            }

        }

        public Article Consult(string title)
        {
           return _unitOfWork.ArticleRepository.FindFirstOrDefault(t => t.Title == title);

        }

        public IEnumerable<Article> ConsultAll()
        {
            IEnumerable<Article> articles = _unitOfWork.ArticleRepository.GetAll();
            return articles;
        }

    }

    public class ArticleRequest
    {
        public string Title { get; set; }
        public bool Credit { get; set; }
        public int NumberOfAuthors { get; set; }
        public List<string> Suports { get; set; }
        public string JournalType { get; set; }
        public string ArticleType { get; set; }
        public string JournalName { get; set; }
        public string Issn { get; set; }
        public string Language { get; set; }

    }
    public class CreateArticleResponse
    {
        public string Menssage { get; set; }
    }
}
