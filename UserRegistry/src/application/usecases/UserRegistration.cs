using UserRegistry.application.dtos;
using UserRegistry.domain.models;
using UserRegistry.domain.ports;
using UserRegistry.domain.vos;

namespace UserRegistry.application.usecases;

public class UserRegistration (IUserRepository repository, IGeneratorIdentifier generatorIdentifier, INotifierSender sender)
{
    private readonly IUserRepository _repository = repository;
    private readonly IGeneratorIdentifier _generatorIdentifier = generatorIdentifier;
    private readonly INotifierSender _sender = sender;

    public User Register(UserRegister userRegister)
    {
        var id = UserId.From(_generatorIdentifier);
        var email = Email.Of(userRegister.Email);
        var password = Password.Of(userRegister.Password);
        var userToRegister = new User(id, email, password);
        
        _repository.Save(userToRegister);
        _sender.NotifyWelcome(email);
        
        return userToRegister;
    }
}