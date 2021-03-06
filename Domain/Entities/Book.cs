﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Book : AcademicProductivity
    {
        public string BookType { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Languaje { get; set; }
        public string Isbn { get; set; }
        public string Editorial { get; set; }

        public override string Consult()
        {
            return $"Titulo: {Title} Tipo de libro: {BookType} idioma: {Languaje} Numero de autores {NumberOfAuthors} Editorial: {Editorial}";
        }

        public IReadOnlyList<string> CanEvaluate(string bookType, string editorial, DateTime publicationDate, string isbn)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(bookType))
                errors.Add("Debe especificar un tipo de libro");

            if (string.IsNullOrWhiteSpace(editorial))
                errors.Add("Debe especificar una editorial");

            if (string.IsNullOrWhiteSpace(isbn))
                errors.Add("Debe especificar un isbn");

            if (publicationDate==null)
                errors.Add("Debe especificar una fecha de publicacion");

            return errors;

        }


        public override decimal RequestEvaluate()
        {
            if (CanEvaluate(BookType, Editorial,PublicationDate, Isbn).Any())
            {
                throw new InvalidOperationException("Falta un dato por especificar");
            }
            else
            {
                int basePoints = BasePoints(BookType);

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
            
        }
        public int BasePoints(string bookType)
        {
            if (bookType == "Libro de texto")
            {
                return 15;
            }
            else if (bookType == "Libro de ensayo")
            {
                return 15;
            }
            else if (bookType == "Libro de resultado de una labor de investigacion")
            {
                return 20;
            }
            else
                return 0;
        }

        [Serializable]
        public class BookRequestExeption : Exception
        {
            public BookRequestExeption() { }
            public BookRequestExeption(string message) : base(message) { }
            public BookRequestExeption(string message, Exception inner) : base(message, inner) { }
            protected BookRequestExeption(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
