using Domain.Models;
using LanguageExt;
using static Domain.Models.Orders;
namespace Domain.Operations {
    public static class OrdersOperation {
        public static Task<IOrders> ValidateOrders (Func<CheckOrderValidation,TryAsync<bool>> checkOrderExists, UnvalidatedOrders orders) => 
        orders.OrderList
              .Select(ValidateOrder(checkOrderExists))
              .Aggregate(CreateEmptyValatedOrdersList().toAsync, ReduceValidGrades)
              .MatchAsync (
                Right: validatedOrders => new ValidatedOrders(validatedOrders),
                LeftAsync: errorMessage => Task.FromResult((IOrders)new InvalidOrders(orders.OrderList, errorMessage))       
              );

        // private static Func<UnvalidatedOrders, EitherAsync<string, ValidatedOrders>> ValidateOrder(Func<ValidRegistrationCity, Option<ValidRegistrationCity>> checkOrderExists, UnvalidatedOrders unvalidatedOrders) =>
        //     unvalidatedOrder => ValidateOrder(checkOrderExists, unvalidatedOrder);

        // private static EitherAsync<string, ValidatedOrders> ValidateOrder(Func<ValidRegistrationCity, Option<ValidRegistrationCity>> checkOrderExists, UnvalidatedOrders unvalidatedOrders) =>
        // from 
    }
}