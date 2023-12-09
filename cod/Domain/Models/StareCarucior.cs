using CSharp.Choices;
namespace Domain.Models {
    [AsChoice]
    public static partial class Stare { 

    public interface iStare {}
    public record Gol(IReadOnlyCollection<UnvalidatedCos> listaCos) : iStare;

    public record Nevalidat(IReadOnlyCollection<UnvalidatedCos> listaCos, string reason) : iStare;

    public record Validat(IReadOnlyCollection<ValidatedCos> listaCos) : iStare;

    public record Platit(IReadOnlyCollection<ValidatedCos> listaCos, DateTime payDate) : iStare;
    }
}