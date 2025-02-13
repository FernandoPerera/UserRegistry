namespace UserRegistry.domain.errors;

public class EmailAlreadyExistsException(string email) : Exception($"Email {email} already exists.");