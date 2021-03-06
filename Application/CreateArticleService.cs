﻿using Domain;
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
            Teacher teacher = _unitOfWork.TeacherRepository.FindFirstOrDefault(t => t.DocumentId == request.DocumentTeacher);
            if (teacher == null)
            {
                return new CreateArticleResponse() { Menssage = $"El docente no existe" };
            }
            else
            {
                AcademicProductivity article = _unitOfWork.ArticleRepository.FindFirstOrDefault(t => t.Title == request.Title && t.Issn == request.Issn);
                if (article == null)
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
                    teacher.AddAcademicProductivities(newArticle);
                    _unitOfWork.ArticleRepository.Add(newArticle);
                    _unitOfWork.Commit();
                    return new CreateArticleResponse() { Menssage = $"El profesor {teacher.Name} creo con exito el articulo {newArticle.Title}." };
                }
                else
                {
                    return new CreateArticleResponse() { Menssage = $"No se pudo completar el registro porque un articulo igual ya esta registrado" };
                }
            }
           

        }
        public CreateArticleResponse SendRequestArticle(SendRequestProperties properties)
        {
            AcademicProductivity article = _unitOfWork.ArticleRepository.FindFirstOrDefault(t => t.Title == properties.TitleProductivity && t.Issn == properties.IssnProductivity);
            if (article == null)
            {
                return new CreateArticleResponse() { Menssage = $"El articulo que desea enviar al comite no existe" };
            }
            else
            {
                Request request = _unitOfWork.RequestRepository.FindFirstOrDefault(t => t.Productivity.Title == properties.TitleProductivity);
                if (request == null)
                {
                    Request newRequest = new Request(article);
                    newRequest.SendRequest();
                    _unitOfWork.RequestRepository.Add(newRequest);
                    _unitOfWork.Commit();
                    return new CreateArticleResponse() { Menssage = $"La solicitud de la productividad {properties.TitleProductivity} fue enviada con exito, su puntaje estimado es {newRequest.EstimatedPoints}." };
                }
                else
                {
                    return new CreateArticleResponse() { Menssage = $"No se pudo el envio de la solicitud porque ya realizo una solicitud de esa productividad" };
                }
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
        public string DocumentTeacher { get; set; }
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
