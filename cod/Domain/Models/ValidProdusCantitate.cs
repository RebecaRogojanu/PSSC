using Exceptions;
using System.IO.Compression;
using System.Text.RegularExpressions;

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
public static bool TryParse(string cantitateString, out ValidProdusCantitate validProdusCantitate){
bool valid = false;
validProdusCantitate = null;
    if(decimal.TryParse(cantitateString, out decimal numericCantitate))
    {
        if (IsValid(numericCantitate))
                {
                    valid = true;
                    validProdusCantitate = new(numericCantitate);
                }
    }
    return valid;
}

    private static bool IsValid(decimal numericCantitate) => numericCantitate > 0;
}