using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class AcademicProductivity
    {
        public AcademicProductivity()
        {
            Suports = new List<string>();
        }

        public string Title { get; set; }
        public List<string> Suports { get; set; }
        public bool Credit { get; set; }
        public decimal Points { get; set; }
        public abstract void Evaluate();
        public abstract void Modify();

        public void AddSuport(String suport)
        {
            Suports.Add(suport);
        }

        public override string ToString()
        {
            return ($"El puntaje de su prodictividad es {Points}");
        }

    }
}
