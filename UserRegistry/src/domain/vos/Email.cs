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
}