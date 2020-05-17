using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Departament
    {
        public string Name { get; set; }

        public Faculty Faculty { get; set; }

        public Departament()
        {

        }

        public Departament(string name, Faculty faculty)
        {
            Faculty = faculty;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
        
    }
}
