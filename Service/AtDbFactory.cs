using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Service
{
	public class AtDbFactory : IDesignTimeDbContextFactory<AtDbContext>
    {
        public AtDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AtDbContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspace\\AtLivroAutor\\Service\\AppDb\\atDb.mdf;Integrated Security=True;Connect Timeout=30"
                );
            return new AtDbContext(optionsBuilder.Options);
        }
    }
}

