using CSharp.Choices;
using Domain.Models;

namespace Domain.Models
{
    [AsChoice]
    public static partial class StareComanda
    {
        public interface IStareComanda { }

        public record Nevalidata(IReadOnlyCollection<Orders.UnvalidatedOrders> listaComenzi, string reason) : IStareComanda;
        public record Validata(IReadOnlyCollection<Orders.ValidatedOrders> listaComenzi) : IStareComanda;
        public record Anulata(IReadOnlyCollection<Orders.ValidatedOrders> listaComenzi) : IStareComanda;
        public record Emisa(IReadOnlyCollection<Orders.ValidatedOrders> listaComenzi) : IStareComanda;
    }
}