using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Service
{
    public class AtDbContext : IdentityDbContext
    {
        public DbSet<Livro> livros { get; set; }
        public DbSet<Autor> autores { get; set; }

        public AtDbContext(DbContextOptions options) : base(options) { }
    }
}

