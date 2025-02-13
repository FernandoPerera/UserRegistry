using UserRegistry.domain.ports;

namespace UserRegistry.domain.vos;

public class UserId
{
    private readonly Guid _value = Guid.Empty;
    
    public static UserId From(IGeneratorIdentifier generatorIdentifier)
    {
        throw new NotImplementedException();
    }
}