﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Software :AcademicProductivity
    {
        public string Headline { get; set; }

        [NotMapped]
        public List<string> Authors { get; set; }
        public string Impact { get; set; }
        public Software()
        {
            Authors = new List<string>();
        }

        public override string Consult()
        {
            string response =  $"Titulo: {Title} Tipo de revista: {Headline} Nombre revista {Impact} Numero de autores: ";

            foreach (var author in Authors)
            {
                response = response +"\n" + author + "\n";
            }

            return response;
        }

        public void AddAuthors(string author)
        {
            Authors.Add(author);
        }

        public override decimal RequestEvaluate()
        {
            if(NumberOfAuthors > 0)
            {
                return 15;
            }
            else
            {
                throw new InvalidOperationException("Numero de autores invalido, debe ser mayo a 0");
            }
        }
    }
}
