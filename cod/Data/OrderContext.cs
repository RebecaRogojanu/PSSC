using Data.Models;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public DbSet<ComandaDTO> Comenzi { get; set; }
        public DbSet<ClientDTO> Clienti { get; set; }
        public DbSet<AdresaDTO> Adrese { get; set; }
        public DbSet<ContactDTO> Contacte { get; set; }
        public DbSet<ProdusDTO> Produse { get; set; }
        public DbSet<ProdusListDTO> ListeProduse { get; set; }
        public DbSet<ListDTO> Liste { get; set; }
        public DbSet<CaruciorDTO> Carucioare { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComandaDTO>().ToTable("Comanda").HasKey(comanda => comanda.ComandaId);
            modelBuilder.Entity<ClientDTO>().ToTable("Client").HasKey(client => client.ClientId);
            modelBuilder.Entity<AdresaDTO>().ToTable("Adresa").HasKey(adresa => adresa.AdresaId);
            modelBuilder.Entity<ContactDTO>().ToTable("Contact").HasKey(contact => contact.ContactId);
            modelBuilder.Entity<ProdusDTO>().ToTable("Produs").HasKey(produs => produs.ProdusId);
            modelBuilder.Entity<ProdusListDTO>().ToTable("ProdusList").HasKey(produsList => produsList.ProdusListId);        
            modelBuilder.Entity<ListDTO>().ToTable("List").HasKey(list => list.ListId);     
            modelBuilder.Entity<CaruciorDTO>().ToTable("Carucior").HasKey(carucior => carucior.CaruciorId);
        }
    }
}