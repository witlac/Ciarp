using Domain;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CreateSoftwareService
    {

        readonly IUnitOfWork _unitOfWork;
        public CreateSoftwareService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateSoftwareResponse Execute(CreateSoftwareRequest request)
        {
            AcademicProductivity soft = _unitOfWork.SoftwareRepository.FindFirstOrDefault(t => t.Title == request.Title);
            if (soft == null)
            {
                Software newSoft = new Software();
                newSoft.NumberOfAuthors = request.NumberOfAuthors;
                newSoft.Title = request.Title;
                newSoft.Credit = request.Credit;
                newSoft.Headline = request.Headline;
                newSoft.Impact = request.Impact;
                _unitOfWork.SoftwareRepository.Add(newSoft);
                _unitOfWork.Commit();
                return new CreateSoftwareResponse() { Menssage = "Software registado con exito" };

            }
            else
            {
                return new CreateSoftwareResponse() { Menssage = "No se pudo registrar el software" };
            }
        }

    }

    public class CreateSoftwareRequest
    {
        public string Title { get; set; }
        public bool Credit { get; set; }
        public int NumberOfAuthors { get; set; }
        public string Headline { get; set; }
        public string Impact { get; set; }
    }

    public class CreateSoftwareResponse
    {
        public string Menssage { get; set; }
    }
}
