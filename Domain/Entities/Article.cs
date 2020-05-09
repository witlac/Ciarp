using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Article : AcademicProductivity
    {
        public string JournalType { get; set; }
        public string JournalName { get; set; }
        public string Issn { get; set; }
        public string Language { get; set; }
        public int NumberOfAuthors { get; set; }

        public override void Evaluate()
        {
            throw new NotImplementedException();
        }

        public override void Modify()
        {
            throw new NotImplementedException();
        }
    }
}
