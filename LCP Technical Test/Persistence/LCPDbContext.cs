using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class LCPDbContext : DbContext
    {
        public LCPDbContext(
            DbContextOptions<LCPDbContext> options)
            : base(
                options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ID = 1,
                    FirstName = "Bob",
                    LastName = "Thompson",
                    Email = "bob.thompson@gmail.com",
                    PhoneNumber = "07546378945",
                    Address = "123 code lane",
                    Postcode = "ET10 9RG",
                    CreatedDate = DateTime.Now
                },
                new Client
                {
                    ID = 2,
                    FirstName = "Brenda",
                    LastName = "Danby",
                    Email = "brenda@outlook.com",
                    PhoneNumber = "07147616544",
                    Address = "987 lanehouse road",
                    Postcode = "AB12 3CD",
                    CreatedDate = DateTime.Now
                });
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}