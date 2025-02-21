using System.Text.RegularExpressions;

namespace NurBilgi.Domain.ValueObjects;

public sealed record Email
{
//Eşittir kullandığınızda referans eşitliği yapar. Yani aynı referansı tutan nesneleri karşılaştırır.
//referansını almaz değerini alır. Yani içindeki değerler aynı ise eşit kabul eder.

    private const string Pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
    public string Value { get; init; }

    public Email(string value)
    {
        if (!IsValid(value))
            throw new ArgumentException($"Invalid email address. {value}");

        Value = value;
    }

    public Email()
    {
        
    }

    private static bool IsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
            return false;

        if (!Regex.IsMatch(value, Pattern))
            return false;

        return true;
    }
    
    public static implicit operator string(Email email) => email.Value; // Email to string

    public static implicit operator Email(string value) => new(value); // string to Email
    
    public override string ToString() => Value;
}