using Domain;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CreateBookService
    {
        readonly IUnitOfWork _unitOfWork;
        public CreateBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateBookResponse Execute(CreateBookRequest request)
        {
            AcademicProductivity book = _unitOfWork.BookRepository.FindFirstOrDefault(t=> t.Isbn == request.Isbn);
            if(book == null)
            {
                Book newBook = new Book();
                newBook.Isbn = request.Isbn;
                newBook.Languaje = request.Languaje;
                newBook.NumberOfAuthors = request.NumberOfAuthors;
                newBook.PublicationDate = request.PublicationDate;
                newBook.Title = request.Title;
                newBook.Credit = request.Credit;
                newBook.Editorial = request.Editorial;
                _unitOfWork.BookRepository.Add(newBook);
                _unitOfWork.Commit();
                return new CreateBookResponse() { Menssage = "Libro registado con exito" };

            }
            else
            {
                return new CreateBookResponse() { Menssage = "No se pudo registrar el libor" };
            }
        }

    }

    public class CreateBookRequest
    {
        public string Title { get; set; }
        public bool Credit { get; set; }
        public int NumberOfAuthors { get; set; }
        public string BookType { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Languaje { get; set; }
        public string Isbn { get; set; }
        public string Editorial { get; set; }
    }

    public class CreateBookResponse
    {
        public string Menssage { get; set; }
    }
}
