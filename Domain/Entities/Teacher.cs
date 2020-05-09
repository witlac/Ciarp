using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Teacher
    {
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DedicationTime { get; set; }
        public string InvestigationGroup { get; set; }

        public List<AcademicProductivity> academicProductivities;

        public Teacher()
        {
            academicProductivities = new List<AcademicProductivity>();
        }


    }
}
