using Domain.Models;
using LanguageExt;
using static Domain.Models.Comanda;
using static Domain.Models.StareComanda;
using static LanguageExt.Prelude;

namespace Domain.Operations {
    public static class OrdersOperation {
        public static Task<IStareComanda> ValidateOrders (Func<CheckOrderValidation, Option<CheckOrderValidation>> checkOrderExists, Nevalidata comanda) => 
        comanda.listaComenzi
              .Select(ValidateOrder(checkOrderExists))
              .Aggregate(CreateEmptyValatedOrdersList().ToAsync(), ReduceOrders)
              .MatchAsync (
                Right: validatedOrders => new Validata(validatedOrders),
                LeftAsync: errorMessage => Task.FromResult((IStareComanda)new Nevalidata(comanda.listaComenzi, errorMessage))
              );

        private static Func<ComandaNevalidata, EitherAsync<string, ComandaValidata>> ValidateOrder(Func<CheckOrderValidation, Option<CheckOrderValidation>> checkOrderExists) =>
            unvalidatedOrder => ValidateOrder(checkOrderExists, unvalidatedOrder); 

        private static EitherAsync<string, ComandaValidata> ValidateOrder(Func<CheckOrderValidation, Option<CheckOrderValidation>> checkOrderExists, ComandaNevalidata unvalidatedOrders) =>
            from oras in ValidRegistrationCity.TryParse(unvalidatedOrders.oras).ToEitherAsync($"Oras nevalid ({unvalidatedOrders.oras}, {unvalidatedOrders.oras})")
            from strada in ValidRegistrationStreet.TryParse(unvalidatedOrders.strada).ToEitherAsync($"Strada nevalida ({unvalidatedOrders.strada}, {unvalidatedOrders.strada})")
            // from cantitate in ValidListaProduse.TryParse(unvalidatedOrders.comanda.carucior.listaProduse).ToEitherAsync($"Strada nevalida ({unvalidatedOrders.comanda.carucior.listaProduse}, {unvalidatedOrders.comanda.carucior.listaProduse})")
            select new ComandaValidata(oras, strada);

        private static Either<string, List<ComandaValidata>> CreateEmptyValatedOrdersList() =>
            Right(new List<ComandaValidata>());
                                            
        private static EitherAsync<string, List<ComandaValidata>> ReduceOrders(EitherAsync<string, List<ComandaValidata>> acc, EitherAsync<string, ComandaValidata> next) =>
            from list in acc
            from nextGrade in next
            select list.AppendOrder(nextGrade);

        private static List<ComandaValidata> AppendOrder(this List<ComandaValidata> list, ComandaValidata comandaValida)
        {
            list.Add(comandaValida);
            return list;
        }
    }
}