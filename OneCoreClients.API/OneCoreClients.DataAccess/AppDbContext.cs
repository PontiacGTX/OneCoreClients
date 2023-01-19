using Microsoft.EntityFrameworkCore;
using OneCoreClients.Data.Entity;
using System;

namespace OneCoreClients.DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts)
        {

        }

        public DbSet<Client> Clientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clientes");
            modelBuilder.Entity<Client>().HasKey(x => x.Id);
            modelBuilder.Entity<Client>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Client>().Property(x => x.Nombre).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Client>().Property(x => x.RFC).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Client>().Property(x => x.Direccion).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Client>().Property(x => x.CP).IsRequired().HasMaxLength(5);

            base.OnModelCreating(modelBuilder);
        }
    }
}
