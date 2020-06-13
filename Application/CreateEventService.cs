using Domain;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CreateEventService
    {
        readonly IUnitOfWork _unitOfWork;
        public CreateEventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateEventResponse Execute(CreateEventRequest request)
        {
            Teacher teacher = _unitOfWork.TeacherRepository.FindFirstOrDefault(t => t.DocumentId == request.DocumentTeacher);
            if (teacher == null)
            {
                return new CreateEventResponse() { Menssage = $"El docente no existe" };
            }
            else
            {
                AcademicProductivity soft = _unitOfWork.EventRepository.FindFirstOrDefault(t => t.Title == request.Title);
                if (soft == null)
                {
                    Event newEvent = new Event();
                    newEvent.NumberOfAuthors = request.NumberOfAuthors;
                    newEvent.Title = request.Title;
                    newEvent.Credit = request.Credit;
                    newEvent.Title = request.Title;
                    newEvent.Memories = request.Memories;
                    newEvent.Languaje = request.Languaje;
                    newEvent.Issn = request.Issn;
                    newEvent.Isbn = request.Isbn;
                    newEvent.EventDate = request.EventDate;
                    newEvent.EventPlace = request.EventPlace;
                    newEvent.EventWeb = request.EventWeb;
                    newEvent.EventType = request.EventType;
                    _unitOfWork.EventRepository.Add(newEvent);
                    _unitOfWork.Commit();
                    return new CreateEventResponse() { Menssage = "Event registado con exito" };

                }
                else
                {
                    return new CreateEventResponse() { Menssage = "No se pudo registrar el Event" };
                }
            }    
        }

        public Event Consult(string isbn)
        {
            return _unitOfWork.EventRepository.FindFirstOrDefault(t => t.Isbn == isbn);

        }

        public IEnumerable<Event> ConsultAll()
        {
            IEnumerable<Event> events = _unitOfWork.EventRepository.GetAll();
            return events;
        }
    }

    public class CreateEventRequest
    {
        public string DocumentTeacher { get; set; }
        public string Title { get; set; }
        public bool Credit { get; set; }
        public int NumberOfAuthors { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public string EventType { get; set; }
        public string Languaje { get; set; }
        public string EventPlace { get; set; }
        public string EventWeb { get; set; }
        public string Memories { get; set; }
        public string Isbn { get; set; }
        public string Issn { get; set; }
    }

    public class CreateEventResponse
    {
        public string Menssage { get; set; }
    }

}
