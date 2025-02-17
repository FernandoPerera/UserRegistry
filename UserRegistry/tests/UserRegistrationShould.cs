using FluentAssertions;
using NSubstitute;
using UserRegistry.application.dtos;
using UserRegistry.application.usecases;
using UserRegistry.domain.errors;
using UserRegistry.domain.models;
using UserRegistry.domain.ports;

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

    private const string GivenEmail = "name@example.net";
    private const string GivenPassword = "Valid_Password";
    private readonly Email _email = Email.From(GivenEmail);
    private readonly Password _password = Password.From(GivenPassword);
    private readonly UserRegisterRequest _userRegisterRequest = new(GivenEmail, GivenPassword);

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
        _repository.ExistsByEmail(_email).Returns(false);
        
        var registeredUser = _registration.Register(_userRegisterRequest);

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
        _repository.ExistsByEmail(_email).Returns(true);
        
        var registerAction = () => _registration.Register(_userRegisterRequest);

        registerAction.Should().Throw<EmailAlreadyExistsException>();
        _repository.DidNotReceive().Save(expectedUser);
        _sender.DidNotReceive().NotifyWelcome(_email);
    }

}