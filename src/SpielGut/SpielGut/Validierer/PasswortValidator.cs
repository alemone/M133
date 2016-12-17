using System.Collections.Generic;
using KDG.DataObjectHandler.Validators;
using SpielGut.Klassen;

namespace SpielGut.Validierer
{
    public static class PasswortValidator
    {
        public static List<string> IsValid(string passwortA, string passwortB)
        {
            var messages = new List<string>();
            if (BaseValidator.StringHasValue(passwortA))
            {
                messages.Add("Das Feld 'Passwort' muss ausgefüllt sein.");
            }
            if (BaseValidator.StringHasValue(passwortB))
            {
                messages.Add("Das Feld 'Passwort Wiederholen' muss ausgefüllt sein.");
            }
            if (messages.Count == 0)
            {
                if (BaseValidator.StringIsInRange(passwortA, 8, 64))
                {
                    messages.Add("Das Passwort muss zwischen 8 und 64 Zeichen lang sein.");
                }
                if (BaseValidator.StringsAreEqual(passwortA, passwortB))
                {
                    messages.Add("Die Passwörter stimmen nicht überein.");
                }
            }
            return messages;
        }
    }
}
