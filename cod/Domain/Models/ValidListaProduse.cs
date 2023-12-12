using Domain.Models;
using Exceptions;
using LanguageExt;
using System.IO.Compression;
using System.Text.RegularExpressions;
using static LanguageExt.Prelude;

public record ValidListaProduse {
public List<Produs>listaProduse { get;}
private ValidListaProduse(List<Produs>listaProduse)
{
    if (IsValid(listaProduse)) {
        this.listaProduse=listaProduse;
    }    
    else {
    //    throw new InvalidProdusCantitateException($"{listaProduse:0.##} este o cantitate invalida.");
    }
}

    public static Option<ValidListaProduse> TryParse(List<Produs> listaProduse)
    {
        return IsValid(listaProduse) ? Some(new ValidListaProduse(listaProduse)) : None;
    }

    private static bool IsValid(List<Produs> listaProduse)
    {
        return listaProduse.All(produs => IsValidCantitate(produs.cantitate.ToString()));
    }
    private static bool IsValidCantitate(string cantitateString)
    {
        return ValidProdusCantitate.TryParse(cantitateString).IsSome;
    }
}