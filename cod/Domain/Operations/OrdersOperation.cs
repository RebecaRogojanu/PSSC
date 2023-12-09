using Domain.Models;
using LanguageExt;
using static Domain.Models.Orders;
namespace Domain.Operations {
    public static class OrdersOperation {
        public static Task<IOrders> ValidateOrders (Func<CheckOrderValidation,TryAsync<bool>> checkOrderExists, UnvalidatedOrders orders) => orders.OrderList
    }
}