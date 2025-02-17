using FluentAssertions;
using UserRegistry.domain.errors;
using UserRegistry.domain.vos;

namespace UserRegistry.tests;

public class EmailShould
{

    // The email must be valid
    
    [Fact]
    public void NotBeCreatedIfIsInvalid()
    {
        const string invalidEmail = "@invalid.com";
        
        var function = () => Email.Of(invalidEmail);

        function.Should().Throw<InvalidEmailException>();
    }

    [Fact]
    public void CreateANewEmail()
    {
        const string validEmail = "test@example.com";
        
        var createdEmail = Email.Of(validEmail);
        
        createdEmail.Should().BeOfType<Email>();
    }
    
}