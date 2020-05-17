using Domain;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class RequestRepository: GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(IDbContext context)
            : base (context)
        {

        }
    }
}
