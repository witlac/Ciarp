using Domain;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TeacherRepository: GenericRepository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(IDbContext context)
            : base (context)
        {

        }
    }
}
