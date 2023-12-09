using Exceptions;
using LanguageExt;
using System.IO.Compression;
using System.Text.RegularExpressions;
using static LanguageExt.Prelude;

public record ValidProdusCantitate {
public decimal Value { get;}
private ValidProdusCantitate(decimal value)
{
    if (IsValid(value)) {
        Value=value;
    }    
    else {
       throw new InvalidProdusCantitateException($"{value:0.##} este o cantitate invalida.");
    }
}
public static Option<ValidProdusCantitate> TryParse(string cantitateString){
    if(decimal.TryParse(cantitateString, out decimal numericCantitate))
    {
        if (IsValid(numericCantitate))
        {
          return Some<ValidProdusCantitate>(new ValidProdusCantitate(numericCantitate));          
        }
        else
        {
            return None;
        }
    }
    else
    {
        return None;
    }
}

    private static bool IsValid(decimal numericCantitate) => numericCantitate > 0;
}