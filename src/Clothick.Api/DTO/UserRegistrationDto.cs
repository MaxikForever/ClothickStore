namespace Clothick.Api.DTO;

public class UserRegistrationDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PasswordConfirmation { get; set; }
}