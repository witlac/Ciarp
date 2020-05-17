using Domain;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CreateTeacherService
    {
        readonly IUnitOfWork _unitOfWork;
        public CreateTeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateTeacherResponse Execute(TeacherRequest request)
        {
            Teacher teacher = _unitOfWork.TeacherRepository.FindFirstOrDefault(t => t.DocumentId == request.DocumentId);
            if (teacher == null)
            {
                Teacher newTeacher = new Teacher(request.User);
                newTeacher.Name = request.Name;
                newTeacher.DocumentId = request.DocumentId;
                newTeacher.Category = request.Category;
                newTeacher.DocumentType = request.DocumentType;
                newTeacher.Email = request.Email;
                newTeacher.DedicationTime = request.DedicationTime;
                newTeacher.Phone = request.Phone;
                newTeacher.InvestigationGroup = request.InvestigationGroup;
                _unitOfWork.TeacherRepository.Add(newTeacher);
                _unitOfWork.Commit();
                return new CreateTeacherResponse() { Menssage = $"Se creo con exito el docente {newTeacher.Name}." };
            }
            else
            {
                return new CreateTeacherResponse() { Menssage = $"Ya existe un docente registrado con esa id" };
            }

        }

       
    }

    public class TeacherRequest
    {
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DedicationTime { get; set; }
        public string InvestigationGroup { get; set; }
        public User User { get; set; }

    }
    public class CreateTeacherResponse
    {
        public string Menssage { get; set; }
    }
}
