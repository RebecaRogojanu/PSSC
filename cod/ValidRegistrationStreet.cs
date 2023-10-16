
using System.IO.Compression;
using System.Text.RegularExpressions;

public record ValidRegistrationStreet {
private static readonly Regex ValidPattern = new("^[A-Z][a-zA-Z]* nr\\.[1-9]*$");
public string Value { get;}
private ValidRegistrationStreet(string value)
{
    if (isValid(value)) {
        Value=value;
    }    
    else {
    //throw new InvalidRegistrationCityException();
    }
}
public static bool TryParse(string value,out ValidRegistrationStreet validRegistrationCity){
bool valid = false;
validRegistrationCity = null;
    if(isValid(value))
    {
        valid=true;
        validRegistrationCity=new(value);
    }
    return valid;
}
public override string ToString(){
        return Value.ToString();
    }
    private static bool isValid(string value) => ValidPattern.IsMatch(value);
}