using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        IBookRepository BookRepository { get; }
        IClaimRepository ClaimRepository { get; }
        IEventRepository EventRepository { get; }
        ISoftwareRepository SoftwareRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IUserRepository UserRepository { get; }
        IRequestRepository RequestRepository { get; }

        int Commit();
    }
}
