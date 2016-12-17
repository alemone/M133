using KDG.DataObjectHandler.Validators;
using SpielGut.Klassen;

namespace SpielGut.Validierer
{
    public static class BenutzerValidator
    {
        private static Benutzer user;

        public static bool IsValid(Benutzer userToValidate)
        {
            user = userToValidate;
            return FirstNameIsValid() &&
                   SurnameIsValid() &&
                   EmailIsValid() &&
                   PasswordIsValid() &&
                   AddressIsValid() &&
                   PhoneNumberIsValid();
        }

        private static bool FirstNameIsValid()
        {
            return BaseValidator.StringHasValue(user.Vorname) &&
                   BaseValidator.StringIsInMaxLenght(user.Vorname, 40);
        }

        private static bool SurnameIsValid()
        {
            return BaseValidator.StringHasValue(user.Nachname) &&
                   BaseValidator.StringIsInMaxLenght(user.Nachname, 40);
        }
        private static bool EmailIsValid()
        {
           
            return BaseValidator.StringHasValue(user.Email) &&
                   BaseValidator.StringIsEmail(user.Email) &&
                   BaseValidator.StringIsInMaxLenght(user.Email, 100);
        }
        private static bool PasswordIsValid()
        {
            return BaseValidator.StringHasValue(user.Passwort);
        }
        private static bool AddressIsValid()
        {
            //TODO: ADDRESS VALIDATE
            return true;
            return BaseValidator.StringHasValue(user.Vorname) &&
                   BaseValidator.StringIsInMaxLenght(user.Vorname, 40);
        }
        private static bool PhoneNumberIsValid()
        {
            //TODO: PHONE VALIDATE
            return true;
            return BaseValidator.StringHasValue(user.Vorname) &&
                   BaseValidator.StringIsInMaxLenght(user.Vorname, 40);
        }
    }
}
