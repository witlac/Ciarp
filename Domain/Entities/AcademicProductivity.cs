using Domain.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class AcademicProductivity : Entity<int>
    {
        public AcademicProductivity()
        {
            Suports = new List<Suport>();
        }
        public string Title { get; set; }
        public List<Suport> Suports { get; set; }
        public bool Credit { get; set; }
        public int NumberOfAuthors { get; set; }
        public abstract decimal RequestEvaluate();
        public abstract string Consult();
        public void AddSuport(Suport suport)
        {
            Suports.Add(suport);
        }

      
    }
}
