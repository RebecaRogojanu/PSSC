using Domain.Models;
using Data.Context;
using LanguageExt;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Data.Repository{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext dbContext;

        public OrderRepository(OrderContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public TryAsync<List<Comanda>> TryGetExistingOrders() => async () =>
        {
        try
        {
        var result = await (
            from comanda in dbContext.Comanda
            join carucior in dbContext.Carucior on comanda.CaruciorId equals carucior.CaruciorId
            join client in dbContext.Client on comanda.ClientId equals client.ClientId
            join list in dbContext.List on comanda.ListId equals list.ListId
            join produsList in dbContext.ProdusList on list.ListId equals produsList.ListId
            join produs in dbContext.Produs on produsList.ProdusId equals produs.ProdusId
            join adresa in dbContext.Adresa on client.AdresaId equals adresa.AdresaId
            join contact in dbContext.Contact on client.ContactId equals contact.ContactId
            select new
            {
                ComandaId = comanda.ComandaId,
                Status = comanda.Status,
                Total = comanda.Total,
                Carucior = new
                {
                    CaruciorId = carucior.CaruciorId,
                    // Add other properties as needed
                },
                Client = new
                {
                    ClientId = client.ClientId,
                    Nume = client.Nume,
                    Adresa = new
                    {
                        AdresaId = adresa.AdresaId,
                        Strada = adresa.Strada,
                        Oras = adresa.Oras
                    },
                    Contact = new
                    {
                        ContactId = contact.ContactId,
                        Telefon = contact.Telefon,
                        Email = contact.Email
                    }
                    // Add other properties as needed
                },
                Produs = new
                {
                    ProdusId = produs.ProdusId,
                    CodProdus = produs.Cod_produs,
                    DenumireProdus = produs.Denumire,
                    PretProdus = produs.Pret
                    // Add other properties as needed
                },
                ProdusListId = produsList.ProdusListId,
                Cantitate = produsList.Cantitate
            })
            .ToListAsync();

        var comenzi = result.GroupBy(r => r.ComandaId).Select(group =>
        {
            var first = group.First();
            var carucior = new Carucior(first.CaruciorId, /* Add other properties */);
            var client = new Client(first.ClientId, first.Nume, /* Add other properties */);
            var produs = new Produs(first.ProdusId, first.CodProdus, first.DenumireProdus, first.PretProdus, first.Cantitate);
            
            // Add other properties as needed
            
            var comanda = new Comanda(carucior, client);
            comanda.Total = first.Total;
            comanda.idComanda = first.ComandaId;

            return comanda;
        }).ToList();
        return Result.Success(comenzi);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Comanda>>(ex.Message);
        }
    };

    public TryAsync<Unit> TrySaveComenzi(PublishOrderCommand comenzi) => async () =>
        {
          var comenzi = (await dbContext.Comenzi.ToListAsync()).ToLookup(comenzi => comenzi.ComandaId);
        }
    }
}

    //     public TryAsync<Unit> TrySaveGrades(PublishedExamGrades grades) => async () =>
    //     {
    //         var students = (await dbContext.Students.ToListAsync()).ToLookup(student=>student.RegistrationNumber);
    //         var newGrades = grades.GradeList
    //                                 .Where(g => g.IsUpdated && g.GradeId == 0)
    //                                 .Select(g => new GradeDto()
    //                                 {
    //                                     StudentId = students[g.StudentRegistrationNumber.Value].Single().StudentId,
    //                                     Exam = g.ExamGrade.Value,
    //                                     Activity = g.ActivityGrade.Value,
    //                                     Final = g.FinalGrade.Value,
    //                                 });
    //         var updatedGrades = grades.GradeList.Where(g => g.IsUpdated && g.GradeId > 0)
    //                                 .Select(g => new GradeDto()
    //                                 {
    //                                     GradeId = g.GradeId,
    //                                     StudentId = students[g.StudentRegistrationNumber.Value].Single().StudentId,
    //                                     Exam = g.ExamGrade.Value,
    //                                     Activity = g.ActivityGrade.Value,
    //                                     Final = g.FinalGrade.Value,
    //                                 });

    //         dbContext.AddRange(newGrades);
    //         foreach (var entity in updatedGrades)
    //         {
    //             dbContext.Entry(entity).State = EntityState.Modified;
    //         }

    //         await dbContext.SaveChangesAsync();

    //         return unit;
    //     };
    // }