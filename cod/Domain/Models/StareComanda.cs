using CSharp.Choices;
using Domain.Models;

namespace Domain.Models
{
    [AsChoice]
    public static partial class StareComanda
    {
        public interface IStareComanda { }

        public record Invalida(IReadOnlyCollection<ComandaNevalidata> listaComenzi) : IStareComanda;
        public record Nevalidata(IReadOnlyCollection<ComandaNevalidata> listaComenzi, string reason) : IStareComanda;
        public record Esuata(IReadOnlyCollection<ComandaNevalidata> listaComenzi, Exception ex) : IStareComanda;
        public record Validata(IReadOnlyCollection<ComandaValidata> listaComenzi) : IStareComanda;
        public record Anulata(IReadOnlyCollection<ComandaValidata> listaComenzi) : IStareComanda;
        public record Emisa(IReadOnlyCollection<ComandaValidata> listaComenzi) : IStareComanda;
    }
}