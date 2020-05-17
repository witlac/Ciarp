using Domain;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ClaimRepository: GenericRepository<Claim>, IClaimRepository
    {
        public ClaimRepository(IDbContext context)
            : base (context)
        {

        }
    }
}
