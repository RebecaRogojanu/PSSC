using CSharp.Choices;
namespace Domain.Models {
    [AsChoice]
    public static partial class Stare { 

    public interface IStare {}
    public record Gol(IReadOnlyCollection<UnvalidatedCos> listaCos) : IStare;

    public record Nevalidat(IReadOnlyCollection<UnvalidatedCos> listaCos, string reason) : IStare;

    public record Validat(IReadOnlyCollection<ValidatedCos> listaCos) : IStare;

    public record Platit(IReadOnlyCollection<ValidatedCos> listaCos, DateTime payDate) : IStare;
    }
}