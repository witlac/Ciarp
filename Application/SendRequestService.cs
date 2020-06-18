using Domain;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class SendRequestService
    {
        readonly IUnitOfWork _unitOfWork;
        public SendRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateRequestResponse SendProductivity(SendRequestProperties properties)
        {
            switch (properties.ProductivityType)
            {
                case "Articulo":
                    AcademicProductivity article = _unitOfWork.ArticleRepository.FindFirstOrDefault(t => t.Title == properties.TitleProductivity);
                    return SendRequest(article);
                case "Libro":
                    AcademicProductivity book = _unitOfWork.BookRepository.FindFirstOrDefault(t => t.Title == properties.TitleProductivity);
                    return SendRequest(book);
                case "Ponencia":
                    AcademicProductivity Event = _unitOfWork.EventRepository.FindFirstOrDefault(t => t.Title == properties.TitleProductivity);
                    return SendRequest(Event);
                case "Software":
                    AcademicProductivity software = _unitOfWork.SoftwareRepository.FindFirstOrDefault(t => t.Title == properties.TitleProductivity);
                    return SendRequest(software);
                default:
                    return new CreateRequestResponse() { Menssage = $"No fue posible enviar la solicitud" };
            }
                

        }

        public CreateRequestResponse SendRequest(AcademicProductivity productivity)
        {
            if (productivity == null)
            {
                return new CreateRequestResponse() { Menssage = $"La productividad academica que desea enviar  no existe" };
            }
            else
            {
                Request request = _unitOfWork.RequestRepository.FindFirstOrDefault(t => t.Productivity.Id == productivity.Id);
                if (request == null)
                {
                    Request newRequest = new Request(productivity);
                    newRequest.SendRequest();
                    _unitOfWork.RequestRepository.Add(newRequest);
                    _unitOfWork.Commit();
                    return new CreateRequestResponse() { Menssage = $"La solicitud de la productividad {newRequest.Productivity.Title} fue enviada con exito, su puntaje estimado es {newRequest.EstimatedPoints}." };
                }
                else
                {
                    return new CreateRequestResponse() { Menssage = $"No se pudo el envio de la solicitud porque ya realizo una solicitud de esa productividad" };
                }
            }
        }

        public IEnumerable<Request> ConsultAll()
        {
            IEnumerable<Request> request = _unitOfWork.RequestRepository.GetAll();
            return request;
        }
    }
    public class SendRequestProperties
    {
        public string ProductivityType { get; set; }
        public string TitleProductivity { get; set; }

        public string IssnProductivity { get; set; }
    }

    public class CreateRequestResponse
    {
        public string Menssage { get; set; }
    }
}
