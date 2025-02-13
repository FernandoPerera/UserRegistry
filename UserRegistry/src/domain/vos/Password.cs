namespace UserRegistry.domain.vos;

public class Password
{
    private readonly string _value;
    
    private Password(string value)
    {
        _value = value;
    }
    
    public static Password Of(string value)
    {
        return new Password(value);
    }
}