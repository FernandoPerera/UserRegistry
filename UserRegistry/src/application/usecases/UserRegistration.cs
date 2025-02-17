using UserRegistry.application.dtos;
using UserRegistry.domain.errors;
using UserRegistry.domain.models;
using UserRegistry.domain.ports;

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
        var email = Email.From(userRegisterRequest.Email);
        var password = Password.From(userRegisterRequest.Password);
        var userToRegister = new User(id, email, password);

        if (repository.ExistsByEmail(email))
        {
            throw new EmailAlreadyExistsException(email);
        }
        
        repository.Save(userToRegister);
        sender.NotifyWelcome(email);

        return userToRegister;
    }
}