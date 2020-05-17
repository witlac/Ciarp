using Domain;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SoftwareRepository : GenericRepository<Software>, ISoftwareRepository
    {
        public SoftwareRepository(IDbContext context)
            :base(context)
        {

        }
    }
}
