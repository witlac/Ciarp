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

        public CreateRequestResponse Execute(CreateRequestProperties properties)
        {
            Request request = _unitOfWork.RequestRepository.FindFirstOrDefault(t => t.Productivity == properties.Productivity);
            if (request == null)
            {
                Request newRequest = new Request(properties.Productivity);
                newRequest.SendRequest();
                _unitOfWork.RequestRepository.Add(newRequest);
                _unitOfWork.Commit();
                return new CreateRequestResponse() { Menssage = $"La solicitud del articulo {properties.Productivity.Title} fue enviada con exito, su puntaje estimado es {newRequest.EstimatedPoints}." };
            }
            else
            {
                return new CreateRequestResponse() { Menssage = $"No se pudo el envio de la solicitud porque ya realizo una solicitud de esa productividad" };
            }

        }        
    }
    public class CreateRequestProperties
    {
        public AcademicProductivity Productivity { get; set; }

    }

    public class CreateRequestResponse
    {
        public string Menssage { get; set; }
    }
}
