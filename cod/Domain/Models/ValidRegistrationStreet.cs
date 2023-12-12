using Exceptions;
using LanguageExt;
using System.IO.Compression;
using System.Text.RegularExpressions;
using static LanguageExt.Prelude;

public record ValidRegistrationStreet {
private static readonly Regex ValidPattern = new("^[A-Z][a-zA-Z]* nr\\.[1-9]*$");
public string Value { get;}
internal ValidRegistrationStreet(string value)
{
    if (isValid(value)) {
        Value=value;
    }    
    else {
    //throw new InvalidRegistrationStreetException();
    }
}
public static Option<ValidRegistrationStreet>TryParse(string value){
    if(isValid(value))
    {
         return Some<ValidRegistrationStreet>(new ValidRegistrationStreet(value));
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