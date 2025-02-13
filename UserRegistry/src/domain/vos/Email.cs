namespace UserRegistry.domain.vos;

public class Email
{
    
    private readonly string _value;

    private Email(string value)
    {
        _value = value;
    }

    public static Email Of(string value)
    {
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