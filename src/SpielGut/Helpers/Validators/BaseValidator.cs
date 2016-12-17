using System.Linq;
using System.Text.RegularExpressions;
using KDG.DataObjectHandler.BaseTypes;

namespace KDG.DataObjectHandler.Validators
{
    public static class BaseValidator
    {
        public static bool StringHasValue(string toValidate)
        {
            return !string.IsNullOrWhiteSpace(toValidate);
        }

        public static bool StringIsInMaxLenght(string toValidate, int max)
        {
            return StringIsInRange(toValidate, 0, max);
        }

        public static bool StringIsInRange(string toValidate, int min, int max)
        {
            return toValidate.Length >= min && toValidate.Length <= max;
        }

        public static bool StringIsEmail(string toValidate)
        {
            string emailRegex = "^(?:(?:[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/]+(?:(?:\\.(?:\"(?:\\\\?[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/\\.()<>\\[\\] @]|\\\\\"|\\\\\\\\)*\"|[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/]+))*\\.[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/]+)?)|(?:\"(?:\\\\?[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/\\.()<>\\[\\] @]|\\\\\"|\\\\\\\\)+\"))@(?:[a-zA-Z\\d\\-]+(?:\\.[a-zA-Z\\d\\-]+)*|\\[\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\])$";
            return StringMatchesRegEx(toValidate, emailRegex);
        }

        public static bool StringMatchesRegEx(string toValidate, string regex)
        {
            return Regex.IsMatch(toValidate, regex);
        }

        public static bool StringsAreEqual(string stringA, string stringB)
        {
            return stringA == stringB;
        }

        public static bool StringIsNumeric(string toValidate)
        {
            return toValidate.All(char.IsDigit);
        }

    }
}
