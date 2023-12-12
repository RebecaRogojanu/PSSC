using Domain.Models;
using LanguageExt;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        TryAsync<List<ComandaValidata>>TryGetExistingOrders();
    }
}