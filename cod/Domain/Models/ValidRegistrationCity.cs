using Exceptions;
using LanguageExt;
using System.IO.Compression;
using System.Text.RegularExpressions;
using static LanguageExt.Prelude;

public record ValidRegistrationCity {
private static readonly Regex ValidPattern = new("^[A-Z][a-zA-Z]*$");
public string Value { get;}
private ValidRegistrationCity(string value)
{
    if (isValid(value)) {
        Value=value;
    }    
    else {
       throw new InvalidRegistrationCityException();
    }
}
public static Option<ValidRegistrationCity>TryParse(string value) {
    if(isValid(value))
    {
        return Some<ValidRegistrationCity>(new ValidRegistrationCity(value));
    }
    else
    {
        return None;
    }
}
public override string ToString(){
        return Value.ToString();
    }
    private static bool isValid(string value) => ValidPattern.IsMatch(value);
}