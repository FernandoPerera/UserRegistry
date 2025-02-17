using System.Text.RegularExpressions;
using UserRegistry.domain.errors;

namespace UserRegistry.domain.vos;

public class Email
{
    private readonly string _value;
    private const string Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    private Email(string value)
    {
        _value = value;
    }

    public static Email From(string value)
    {
        var isInvalidEmail = !Regex.IsMatch(value, Pattern);
        if (isInvalidEmail)
        {
            throw new InvalidEmailException();
        }

        return new Email(value);
    }

    protected bool Equals(Email other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Email)obj);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}