using UserRegistry.domain.errors;

namespace UserRegistry.domain.vos;

public class Password
{
    private const int MinPasswordLength = 8;

    private readonly string _value;
    
    private Password(string value)
    {
        _value = value;
    }
    
    public static Password Of(string value)
    {
        if (value.Length < MinPasswordLength)
        {
            throw new PasswordTooShortException();
        }

        if (!value.Contains('_'))
        {
            throw new PasswordRequirementsExceptions();
        }
        
        return new Password(value);
    }
    
    protected bool Equals(Password other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Password)obj);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}