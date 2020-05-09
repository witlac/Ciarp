using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Book : AcademicProductivity
    {
        public string BookType { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Languaje { get; set; }
        public int NumberOfAuthors { get; set; }
        public string Isbn { get; set; }
        public string Editorial { get; set; }

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
