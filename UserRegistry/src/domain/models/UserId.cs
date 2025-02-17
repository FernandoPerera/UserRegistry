using UserRegistry.domain.ports;

namespace UserRegistry.domain.models;

public class UserId
{

    private readonly Guid _value;

    private UserId(Guid value)
    {
        _value = value;
    }

    public static UserId From(IGeneratorIdentifier generatorIdentifier)
    {
        return new UserId(generatorIdentifier.Generate());
    }
    
    protected bool Equals(UserId other)
    {
        return _value.Equals(other._value);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((UserId)obj);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}