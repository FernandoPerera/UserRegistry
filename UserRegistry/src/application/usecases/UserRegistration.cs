using UserRegistry.application.dtos;
using UserRegistry.domain.models;
using UserRegistry.domain.ports;

namespace UserRegistry.application.usecases;

public class UserRegistration (IUserRepository repository, IGeneratorIdentifier generatorIdentifier, INotifierSender sender)
{
    private readonly IUserRepository _repository = repository;
    private readonly IGeneratorIdentifier _generatorIdentifier = generatorIdentifier;
    private readonly INotifierSender _sender = sender;

    public User Register(UserRegister userRegister)
    {
        throw new NotImplementedException();
    }
}