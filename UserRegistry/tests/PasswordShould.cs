using FluentAssertions;
using UserRegistry.domain.errors;
using UserRegistry.domain.vos;

namespace UserRegistry.tests;

public class PasswordShould
{
    
    // The password must :
    //   - Have more than 8 characters
    //   - Contains an underscore
    
    private const int MinimumPasswordLength = 8;

    [Fact]
    public void NotBeCreatedIfItIsLessThanTheMinimumLength()
    {
        const string password = "123456_";
        
        var function = () => Password.From(password);

        function.Should().Throw<PasswordTooShortException>();
    }

    [Fact]
    public void NotBeCreatedIfThereIsNoUnderscore()
    {
        const string password = "1234567890";
        
        var function = () => Password.From(password);
        
        function.Should().Throw<PasswordRequirementsExceptions>();
    }

    [Fact]
    public void BeCreated()
    {
        const string password = "1234567890_";

        var createdPassword = Password.From(password);
        
        createdPassword.Should().BeOfType<Password>();
    }

}