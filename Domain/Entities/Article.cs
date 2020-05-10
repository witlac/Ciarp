using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class Article : AcademicProductivity
    {
        public string JournalType { get; set; }
        public string ArticleType { get; set; }
        public string JournalName { get; set; }
        public string Issn { get; set; }
        public string Language { get; set; }

        public override Request RequestEvaluate()
        {
            if(ArticleType != null)
            {
                if(JournalType != null)
                {
                    int basePoints = BasePoints(JournalType);
                    switch (ArticleType)
                    {
                        case "Articulo Tradicional":
                            if (NumberOfAuthors <= 3)
                            {
                                return GenerateRequest(basePoints);
                            }
                            else if (NumberOfAuthors <= 5)
                            {
                                return GenerateRequest(basePoints / 2M);
                            }
                            else
                            {
                                decimal points = basePoints / (NumberOfAuthors / 2M);
                                return GenerateRequest(points);
                            }
                        case "Articulo Corto":
                            if (NumberOfAuthors <= 3)
                            {
                                return GenerateRequest(basePoints * 0.6M);
                            }
                            else if (NumberOfAuthors <= 5)
                            {
                                return GenerateRequest(basePoints * 0.6M / 2M);
                            }
                            else
                            {
                                decimal points = basePoints * 0.6M / (NumberOfAuthors / 2M);

                                return GenerateRequest(points);
                            }
                        case "Editorial":
                            if (NumberOfAuthors <= 3)
                            {
                                return GenerateRequest(basePoints * 0.3M);
                            }
                            else if (NumberOfAuthors <= 5)
                            {
                                return GenerateRequest(basePoints * 0.3M / 2M);
                            }
                            else
                            {
                                decimal points = basePoints * 0.3M / (NumberOfAuthors / 2M);

                                return GenerateRequest(points);
                            }
                        default:
                            return null;
                            
                    }
                }
                else
                {
                    throw new ArticleRequestExeption("No se a asignado un tipo de revista");

                }

            }
            else
            {
                throw new ArticleRequestExeption("No se a asignado un tipo de articulo");
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
