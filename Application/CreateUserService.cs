using Domain;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CreateUserService
    {
        readonly IUnitOfWork _unitOfWork;
        public CreateUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateUserResponse Execute(UserRequest request)
        {
            User user = _unitOfWork.UserRepository.FindFirstOrDefault(t => t.Name == request.Name);
            if (user == null)
            {
                User newUser = new User();
                newUser.Name = request.Name;
                newUser.Password = request.Password;
                _unitOfWork.UserRepository.Add(newUser);
                _unitOfWork.Commit();
                return new CreateUserResponse() { Menssage = $"Se creo con exito el usuario {newUser.Name}." };
            }
            else
            {
                return new CreateUserResponse() { Menssage = $"Ya existe un usuario con ese nombre" };
            }

        }

        public User Consult(string name)
        {
            return _unitOfWork.UserRepository.FindFirstOrDefault(t => t.Name == name);
        }

        public IEnumerable<User> ConsultAll()
        {
            IEnumerable<User> users = _unitOfWork.UserRepository.GetAll();
            return users;
        }

    }
    public class UserRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }

    }
    public class CreateUserResponse
    {
        public string Menssage { get; set; }
    }
}
