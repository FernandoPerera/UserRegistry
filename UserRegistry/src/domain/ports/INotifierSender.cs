using UserRegistry.domain.vos;

namespace UserRegistry.domain.ports;

public interface INotifierSender
{
    void NotifyWelcome(Email email);
}