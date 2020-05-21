using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Event : AcademicProductivity
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public string EventType { get; set; }
        public string Languaje { get; set; }
        public string EventPlace { get; set; }
        public string EventWeb { get; set; }
        public string Memories { get; set; }
        public string Isbn { get; set; }
        public string Issn { get; set; }

        public IReadOnlyList<string> CanEvaluate(string eventType, string issn, string isbn,int numActors)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(eventType))
                errors.Add("Debe especificar un tipo de evento");

            if (string.IsNullOrWhiteSpace(issn))
                errors.Add("Debe especificar un codigo issn");

            if (string.IsNullOrWhiteSpace(isbn))
                errors.Add("Debe especificar un  codigo isbn");

            if (numActors<=0)
                errors.Add("Debe especificar un numero de autores");

            return errors;

        }

        public override decimal RequestEvaluate()
        {
            if (CanEvaluate(EventType,Issn, Isbn,NumberOfAuthors).Any())
            {
                throw new InvalidOperationException("Falta un dato por especificar");
            }
            else
            {
                int basePoints = BasePoints(EventType);
                if (NumberOfAuthors > 0)
                {
                    if (NumberOfAuthors <= 3)
                    {
                        return basePoints;
                    }
                    else if (NumberOfAuthors <= 5)
                    {
                        return basePoints / 2M;
                    }
                    else
                    {
                        decimal points = basePoints / (NumberOfAuthors / 2M);
                        return points;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Numero de autores invalido");
                }
            }

           
        }

        public override string Consult()
        {
            return $"Titulo: {Title} Tipo de ponencia: {EventType} idioma: {Languaje} Numero de autores {NumberOfAuthors} Isbn: {Isbn}";
        }

        public int BasePoints(string eventType)
        {
            if (eventType == "Internacional")
            {
                return 84;
            }
            else if (eventType == "Nacional")
            {
                return 48;
            }
            else
            {
                return 24;
            }
        }
    }
}
