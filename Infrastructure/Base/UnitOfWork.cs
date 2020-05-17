using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private IArticleRepository _articleRepository;

        private IBookRepository _bookRepository;

        private IClaimRepository _claimRepository;

        private IEventRepository _eventRepository;

        private ISoftwareRepository _softwareRepository;

        private ITeacherRepository _teacherRepository;

        private IUserRepository _userRepository;

        private IRequestRepository _requestRepository;


        public IArticleRepository ArticleRepository { get { return _articleRepository ?? (_articleRepository = new ArticleRepository(_dbContext)); } }

        public IBookRepository BookRepository { get { return _bookRepository ?? (_bookRepository = new BookRepository(_dbContext)); } }

        public IClaimRepository ClaimRepository { get { return _claimRepository ?? (_claimRepository = new ClaimRepository(_dbContext)); } }

        public IEventRepository EventRepository { get { return _eventRepository ?? (_eventRepository = new EventRepository(_dbContext)); } }

        public ISoftwareRepository SoftwareRepository { get { return _softwareRepository ?? (_softwareRepository = new SoftwareRepository(_dbContext)); } }

        public ITeacherRepository TeacherRepository { get { return _teacherRepository ?? (_teacherRepository = new TeacherRepository(_dbContext)); } }

        public IUserRepository UserRepository { get { return _userRepository ?? (_userRepository = new UserRepository(_dbContext)); } }

        public IRequestRepository RequestRepository { get { return _requestRepository ?? (_requestRepository = new RequestRepository(_dbContext)); } }
        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }

    }
}
