using UserRegistry.domain.vos;

namespace UserRegistry.domain.errors;

public class EmailAlreadyExistsException(Email email) : Exception($"Email {email} already exists.");