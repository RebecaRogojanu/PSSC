using Domain.Models;
using LanguageExt;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        TryAsync<List<ComandaNevalidata>> TryGetComenzi();

        TryAsync<Unit> TrySaveGrades(ComandaValidata comanda);
    }
}