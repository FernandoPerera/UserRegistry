using UserRegistry.domain.models;

namespace UserRegistry.domain.ports;

public interface IUserRepository
{
    User Save(User user);
}