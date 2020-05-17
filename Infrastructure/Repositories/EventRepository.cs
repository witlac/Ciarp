using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EventRepository : GenericRepository<Event>,IEventRepository
    {
        public EventRepository(IDbContext context) 
            : base(context)
        {

        }
    }
}
