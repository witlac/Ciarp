using Domain;
using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class CiarpContext : DbContextBase
    {
        public CiarpContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Book> Books  { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }

    }
}
