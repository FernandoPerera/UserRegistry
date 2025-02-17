using UserRegistry.domain.models;
using UserRegistry.domain.vos;

namespace UserRegistry.domain.ports;

public interface IUserRepository
{
    User Save(User user);
    bool ExistsByEmail(Email email);
}