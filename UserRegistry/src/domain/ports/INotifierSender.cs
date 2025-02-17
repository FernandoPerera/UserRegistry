using UserRegistry.domain.models;

namespace UserRegistry.domain.ports;

public interface INotifierSender
{
    void NotifyWelcome(Email email);
}