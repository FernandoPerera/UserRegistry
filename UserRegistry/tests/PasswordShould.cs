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
    public void ItWillNotBeCreatedIfItIsLessThanTheMinimumLength()
    {
        const string password = "123456_";
        
        var function = () => Password.Of(password);

        function.Should().Throw<PasswordTooShortException>();
    }

    [Fact]
    public void ItWillNotBeCreatedIfThereIsNoUnderscore()
    {
        const string password = "1234567890";
        
        var function = () => Password.Of(password);
        
        function.Should().Throw<PasswordRequirementsExceptions>();
    }

}