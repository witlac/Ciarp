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

        public CreateBookResponse CreateBook(CreateBookRequest request)
        {
            Teacher teacher = _unitOfWork.TeacherRepository.FindFirstOrDefault(t => t.DocumentId == request.DocumentTeacher);
            if (teacher == null)
            {
                return new CreateBookResponse() { Menssage = $"El docente no existe" };
            }
            else
            {
                AcademicProductivity book = _unitOfWork.BookRepository.FindFirstOrDefault(t => t.Isbn == request.Isbn);
                if (book == null)
                {
                    Book newBook = new Book();
                    newBook.Isbn = request.Isbn;
                    newBook.Languaje = request.Languaje;
                    newBook.NumberOfAuthors = request.NumberOfAuthors;
                    newBook.PublicationDate = request.PublicationDate;
                    newBook.Title = request.Title;
                    newBook.Credit = request.Credit;
                    newBook.Editorial = request.Editorial;
                    newBook.BookType = request.BookType;
                    teacher.AddAcademicProductivities(newBook);
                    _unitOfWork.BookRepository.Add(newBook);
                    _unitOfWork.Commit();
                    return new CreateBookResponse() { Menssage = "Libro registado con exito" };

                }
                else
                {
                    return new CreateBookResponse() { Menssage = "Ya existe una copia registrada de ese libro" };
                }
            }
        }

        public Book Consult(string title)
        {
            return _unitOfWork.BookRepository.FindFirstOrDefault(t => t.Title == title);

        }

        public IEnumerable<Book> ConsultAll()
        {
            IEnumerable<Book> books = _unitOfWork.BookRepository.GetAll();
            return books;
        }

    }

   

    public class CreateBookRequest
    {
        public string DocumentTeacher { get; set; }
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
