using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Faculty
    {
        public string Name { get; set; }

        public Faculty()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
