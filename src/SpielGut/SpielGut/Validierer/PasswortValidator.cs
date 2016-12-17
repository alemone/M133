using KDG.DataObjectHandler.Validators;
using SpielGut.Klassen;

namespace SpielGut.Validierer
{
    public static class PasswortValidator
    {
        public static bool IsValid(string passwortA, string passwortB)
        {
            return BaseValidator.StringHasValue(passwortA) &&
                   BaseValidator.StringHasValue(passwortB) &&
                   BaseValidator.StringIsInRange(passwortA, 8, 64) &&
                   BaseValidator.StringsAreEqual(passwortA, passwortB);
        }
    }
}
