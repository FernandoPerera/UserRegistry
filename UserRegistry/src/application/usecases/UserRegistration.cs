using UserRegistry.application.dtos;
using UserRegistry.domain.errors;
using UserRegistry.domain.models;
using UserRegistry.domain.ports;
using UserRegistry.domain.vos;

namespace UserRegistry.application.usecases;

public class UserRegistration(
    IUserRepository repository,
    IGeneratorIdentifier generatorIdentifier,
    INotifierSender sender
)
{
    public User Register(UserRegisterRequest userRegisterRequest)
    {
        var id = UserId.From(generatorIdentifier);
        var email = Email.Of(userRegisterRequest.Email);
        var password = Password.Of(userRegisterRequest.Password);
        var userToRegister = new User(id, email, password);

        try
        {
            repository.Save(userToRegister);
        }
        catch (EmailAlreadyExistsException e)
        {
            throw new EmailAlreadyExistsException(userRegisterRequest.Email);
        }

        sender.NotifyWelcome(email);

        return userToRegister;
    }
}