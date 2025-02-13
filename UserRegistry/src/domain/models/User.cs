using UserRegistry.domain.vos;

namespace UserRegistry.domain.models;

public class User(UserId id, Email email, Password password)
{
    private readonly UserId _id = id;

    private readonly Email _email = email;

    private readonly Password _password = password;

    protected bool Equals(User other)
    {
        return _id.Equals(other._id) && _email.Equals(other._email) && _password.Equals(other._password);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((User)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _email, _password);
    }
}