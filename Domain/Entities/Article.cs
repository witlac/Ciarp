using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class Article : AcademicProductivity
    {
        public int Number { get; set; }
        public string JournalType { get; set; }
        public string ArticleType { get; set; }
        public string JournalName { get; set; }
        public string Issn { get; set; }
        public string Language { get; set; }

        public IReadOnlyList<string> CanEvaluate(string journalType,string articleType,string journalName,string issn)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(journalType))
                errors.Add("Debe especificar un tipo de revista");

            if (string.IsNullOrWhiteSpace(issn))
                errors.Add("Debe especificar un codigo issn");

            if (string.IsNullOrWhiteSpace(articleType))
                errors.Add("Debe especificar un tipo de articulo");

            if (string.IsNullOrWhiteSpace(journalName))
                errors.Add("Debe especificar un nombre a la revista");

            return errors;

        }

        public override decimal RequestEvaluate()
        {
           IReadOnlyList<string> canDeliver = CanEvaluate(JournalType, ArticleType, JournalName, Issn);
           if (canDeliver.Any())
            {
                throw new InvalidOperationException("Falta un campo por expecificar");
            }
            else
            {
                int basePoints = BasePoints(JournalType);
                switch (ArticleType)
                {
                    case "Articulo Tradicional":
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
                    case "Articulo Corto":
                        if (NumberOfAuthors <= 3)
                        {
                            return basePoints * 0.6M;
                        }
                        else if (NumberOfAuthors <= 5)
                        {
                            return basePoints * 0.6M / 2M;
                        }
                        else
                        {
                            decimal points = basePoints * 0.6M / (NumberOfAuthors / 2M);

                            return points;
                        }
                    case "Editorial":
                        if (NumberOfAuthors <= 3)
                        {
                            return basePoints * 0.3M;
                        }
                        else if (NumberOfAuthors <= 5)
                        {
                            return basePoints * 0.3M / 2M;
                        }
                        else
                        {
                            decimal points = basePoints * 0.3M / (NumberOfAuthors / 2M);

                            return points;
                        }
                    default:
                        return 0;

                }
            }  
             
        }

        public override string Consult()
        {
            return $"Titulo: {Title} Tipo de revista: {JournalType} Nombre revista {JournalName} Numero de autores {NumberOfAuthors}";
        }

        public int BasePoints(string typeJournal)
        {
            if (typeJournal == "A1")
            {
                return 15;
            }
            else if (typeJournal == "A2")
            {
                return 12;
            }
            else if (typeJournal == "B")
            {
                return 8;
            }
            else
            {
                return 3;
            }
        }

        [Serializable]
        public class ArticleRequestExeption : Exception
        {
            public ArticleRequestExeption() { }
            public ArticleRequestExeption(string message) : base(message) { }
            public ArticleRequestExeption(string message, Exception inner) : base(message, inner) { }
            protected ArticleRequestExeption(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
