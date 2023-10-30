using CSharp.Choices;
using static Exemple.Domain.Orders;
namespace StareCarucior.Domain
{
    [AsChoice]
    public static partial class StareComanda { 

    public interface iStareComanda {}

    public record Nevalidata(IReadOnlyCollection<UnvalidatedOrders> listaComenzi, string reason) : iStareComanda;
    public record Validata(IReadOnlyCollection<ValidatedOrders> listaComenzi) : iStareComanda;
    public record Anulata(IReadOnlyCollection<ValidatedOrders> listaComenzi) : iStareComanda;
    public record Emisa(IReadOnlyCollection<ValidatedOrders> listaComenzi) : iStareComanda;
    }
}