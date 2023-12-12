using Domain.Models;
using Data.Context;
using LanguageExt;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using static Domain.Models.StareComanda;
using Data.Models;
namespace Data.Repository{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext dbContext;

        public OrderRepository(OrderContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public TryAsync<List<ComandaValidata>> TryGetExistingOrders() => async () =>
        (await (
            from comanda in dbContext.Comenzi
            join carucior in dbContext.Carucioare on comanda.CaruciorId equals carucior.CaruciorId
            join client in dbContext.Clienti on comanda.ClientId equals client.ClientId
            join list in dbContext.Liste on carucior.ListId equals list.ListId
            join produsList in dbContext.ListeProduse on list.ListId  equals produsList.ProdusListId
            join produs in dbContext.Produse on produsList.ProdusListId equals produs.ProdusId
            join adresa in dbContext.Adrese on client.AdresaId equals adresa.AdresaId
            join contact in dbContext.Contacte on client.ContactId equals contact.ContactId
            select new {adresa.Oras, adresa.Strada, comanda.ComandaId})
            .AsNoTracking()
            .ToListAsync())
            .Select(result => new ComandaValidata(
               ValidRegistrationCity:  new ValidRegistrationCity(result.Oras),
               ValidRegistrationStreet: new ValidRegistrationStreet(result.Strada))
               {
                ComandaId = result.ComandaId
               })
               .ToList();
    }
}
            