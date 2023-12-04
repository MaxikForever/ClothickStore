namespace Clothick.Api.Constants;

public class AuthentificationValidationErrorMessages
{
        // FirstName error messages
        public const string FirstNameInvalidLength = "First name must be between 3 and 30 characters.";
        public const string FirstNameInvalidCharacters = "Only alphabetic characters, spaces, '-', and ''' are allowed.";

        // LastName error messages
        public const string LastNameRequired = "Last name is required.";
        public const string LastNameInvalidLength = "Last name must be between 3 and 30 characters.";
        public const string LastNameInvalidCharacters = "Only alphabetic characters, spaces, '-', and ''' are allowed.";

        // UserName error messages
        public const string UserNameRequired = "Username is required.";
        public const string UserNameInvalidLength = "Username must be between 3 and 30 characters.";
        public const string UserNameInvalidCharacters = "Only alphabetic characters, spaces, '-', and ''' are allowed.";

        // Email error messages
        public const string EmailRequired = "Email is required.";
        public const string EmailInvalidFormat = "Invalid email format. Please enter a valid email address.";

        // Password error messages
        public const string PasswordRequired = "Password is required.";
        public const string PasswordInvalidLength = "Password must be between 4 and 30 characters long.";
        public const string PasswordRequiresUppercase = "Password must contain at least one uppercase letter.";
        public const string PasswordRequiresLowercase = "Password must contain at least one lowercase letter.";
        public const string PasswordRequiresDigit = "Password must contain at least one digit.";
        public const string PasswordRequiresSpecialCharacter = "Password must contain at least one special character.";
        public const string PasswordCannotBeUserName = "Password cannot be the same as the username.";

        // PasswordConfirmation error messages
        public const string PasswordConfirmationRequired = "Password confirmation is required.";
        public const string PasswordConfirmationMustMatch = "Password and its confirmation do not match.";
}