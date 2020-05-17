using System;
using System.Collections.Generic;
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
        public override string Consult()
        {
            throw new NotImplementedException();
        }

        public override decimal RequestEvaluate()
        {
            int basePoints = BasePoints(EventType);
            if(NumberOfAuthors > 0)
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
