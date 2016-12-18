using System.Collections.Generic;
using KDG.DataObjectHandler.Validators;
using SpielGut.Klassen;

namespace SpielGut.Validierer
{
    public static class BenutzerValidator
    {
        private static Benutzer user;

        private static List<string> errorMessages;

        public static List<string> Validate(Benutzer userToValidate)
        {
            user = userToValidate;
            errorMessages = new List<string>();
            errorMessages.AddRange(FirstNameIsValid());
            errorMessages.AddRange(SurnameIsValid());
            errorMessages.AddRange(EmailIsValid());
            errorMessages.AddRange(PasswordIsValid());
            errorMessages.AddRange(AddressIsValid());
            errorMessages.AddRange(PhoneNumberIsValid());
            return errorMessages;
        }

        private static List<string> FirstNameIsValid()
        {
            var messages = new List<string>();
            if (!BaseValidator.StringHasValue(user.Vorname))
            {
                messages.Add("Das Feld Vorname muss ausgefüllt sein.");
            }
            if (!BaseValidator.StringIsInMaxLenght(user.Vorname, 40))
            {
                messages.Add("Das Feld Vorname darf maximal 40 Zeichen beinhalten.");
            }
            return messages;
        }

        private static List<string> SurnameIsValid()
        {
            var messages = new List<string>();
            if (!BaseValidator.StringHasValue(user.Nachname))
            {
                messages.Add("Das Feld Nachname muss ausgefüllt sein.");
            }
            if (!BaseValidator.StringIsInMaxLenght(user.Nachname, 40))
            {
                messages.Add("Das Feld Nachname darf maximal 40 Zeichen beinhalten.");
            }
            return messages;
        }
        private static List<string> EmailIsValid()
        {
            var messages = new List<string>();
            if (!BaseValidator.StringHasValue(user.Email))
            {
                messages.Add("Das Feld Email muss ausgefüllt sein.");
                if (!BaseValidator.StringIsEmail(user.Email))
                {
                    messages.Add("Das Feld Email beinhaltet keine gültige Email.");
                }
            }
            if (!BaseValidator.StringIsInMaxLenght(user.Email, 100))
            {
                messages.Add("Das Feld Email darf maximal 100 Zeichen beinhalten.");
            }
            return messages;
        }
        private static List<string> PasswordIsValid()
        {
            var messages = new List<string>();
            if (!BaseValidator.StringHasValue(user.Passwort))
            {
                messages.Add("Das Feld Nachname muss ausgefüllt sein.");
            }
            return messages;
        }
        private static List<string> AddressIsValid()
        {
            var messages = new List<string>();
            if (!BaseValidator.StringHasValue(user.Address.Strasse))
            {
                messages.Add("Das Feld Strasse muss ausgefüllt sein.");
            }
            if (!BaseValidator.StringHasValue(user.Address.Ort))
            {
                messages.Add("Das Feld Ort muss ausgefüllt sein.");
            }
            if (!BaseValidator.StringHasValue(user.Address.Postleitzahl))
            {
                messages.Add("Das Feld Postleitzahl muss ausgefüllt sein.");
            }
            if (!BaseValidator.StringIsInMaxLenght(user.Address.Strasse, 40))
            {
                messages.Add("Das Feld Strasse darf maximal 40 Zeichen beinhalten.");
            }
            if (!BaseValidator.StringIsInMaxLenght(user.Address.Ort, 40))
            {
                messages.Add("Das Feld Ort darf maximal 40 Zeichen beinhalten.");
            }
            if (!BaseValidator.StringIsInMaxLenght(user.Address.Postleitzahl, 4))
            {
                messages.Add("Das Feld Postleitzahl darf maximal 4 Zeichen beinhalten.");
            }
            if (!BaseValidator.StringIsNumeric(user.Address.Postleitzahl))
            {
                messages.Add("Das Feld Postleitzahl darf nur Zahlen beinhalten.");
            }
            return messages;
        }
        private static List<string> PhoneNumberIsValid()
        {
            var messages = new List<string>();
            if (!BaseValidator.StringHasValue(user.Telefonnummer))
            {
                messages.Add("Das Feld Telefonnummer muss ausgefüllt sein.");
            }
            if (!BaseValidator.StringIsInMaxLenght(user.Telefonnummer, 40))
            {
                messages.Add("Das Feld Telefonnummer darf maximal 40 Zeichen beinhalten.");
            }
            return messages;
        }
    }
}
