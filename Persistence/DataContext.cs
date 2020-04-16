using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Client> Clients {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
            .HasData(
                new Client { Id = 1, FirstName = "Thanos", LastName = "Melistas"},
                new Client { Id = 2, FirstName = "Michalis", LastName = "Melistas"},
                new Client { Id = 3, FirstName = "Eva", LastName = "Melista"}
            );
        }
    }
}
