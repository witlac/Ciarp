using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class AcademicProductivity : Entity<int>
    {
        public AcademicProductivity()
        {
            Suports = new List<string>();
        }

        public string Title { get; set; }
        public List<string> Suports { get; set; }
        public bool Credit { get; set; }
        public int NumberOfAuthors { get; set; }
        public abstract Request RequestEvaluate();
        public abstract string Consult();
        public void AddSuport(String suport)
        {
            Suports.Add(suport);
        }

        public Request GenerateRequest(decimal points)
        {
            Request request = new Request();
            request.EstimatedPoints = points;
            request.DateRequest = DateTime.Now;
            request.academicProductivity = this;
            //throw new InvalidOperationException($"Solicitud registrada exitosamente, su puntaje estimado es {request.EstimatedPoints}");
            return request;

        }


    }
}
