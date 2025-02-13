using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using UserRegistry.application.dtos;
using UserRegistry.application.usecases;
using UserRegistry.domain.errors;
using UserRegistry.domain.models;
using UserRegistry.domain.ports;
using UserRegistry.domain.vos;

namespace UserRegistry.tests;

public class UserRegistrationShould
{
    
    // Generate random ID
    // Returns the registered user
    // Send welcome message to new user
    
    private readonly IGeneratorIdentifier _generatorIdentifier = Substitute.For<IGeneratorIdentifier>();
    private readonly IUserRepository _repository = Substitute.For<IUserRepository>();
    private readonly INotifierSender _sender = Substitute.For<INotifierSender>();
    
    private readonly UserRegistration _registration;

    private const string PrimitiveEmail = "name@example.net";
    private const string PrimitivePassword = "Valid_Password";
    private readonly Email _email = Email.Of(PrimitiveEmail);
    private readonly Password _password = Password.Of(PrimitivePassword);
    private readonly UserRegister _userRegister = new(PrimitiveEmail, PrimitivePassword);

    public UserRegistrationShould()
    {
        _registration = new UserRegistration(_repository, _generatorIdentifier, _sender);
    }

    [Fact]
    public void Register()
    {
        _generatorIdentifier.Generate().Returns(Guid.NewGuid());
        var id = UserId.From(_generatorIdentifier);
        var expectedUser = new User(id, _email, _password);
        
        var registeredUser = _registration.Register(_userRegister);

        _repository.Received().Save(expectedUser);
        _sender.Received().NotifyWelcome(_email);
        registeredUser.Should().Be(expectedUser);
    }

    [Fact]
    public void CannotRegisterIfEmailIsBeingUsedByAnotherUser()
    {
        _generatorIdentifier.Generate().Returns(Guid.NewGuid());
        var id = UserId.From(_generatorIdentifier);
        var expectedUser = new User(id, _email, _password);
        _repository.Save(expectedUser).Throws(new EmailAlreadyExistsException(PrimitiveEmail));
        
        var registerAction = () => _registration.Register(_userRegister);

        registerAction.Should().Throw<EmailAlreadyExistsException>();
        _repository.Received().Save(expectedUser);
        _sender.DidNotReceive().NotifyWelcome(_email);
    }

}