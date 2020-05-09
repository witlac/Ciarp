using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Software :AcademicProductivity
    {
        public string Headline { get; set; }
        public List<string> Authors { get; set; }
        public string Impact { get; set; }

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
