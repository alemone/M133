using System.Linq;
using System.Text.RegularExpressions;
using Helpers.BaseTypes;


namespace Helpers.Validators
{
    public abstract class BaseValidator<T>
        where T : DataObject
    {
        public abstract bool IsValid(T objectToValid);

        protected bool StringHasValue(string toValidate)
        {
            return !string.IsNullOrWhiteSpace(toValidate);
        }

        protected bool StringIsInMaxLenght(string toValidate, int max)
        {
            return this.StringIsInRange(toValidate, 0, max);
        }

        protected bool StringIsInRange(string toValidate, int min, int max)
        {
            return toValidate.Length >= min && toValidate.Length <= max;
        }

        protected bool StringIsEmail(string toValidate)
        {
            string emailRegex = "^(?:(?:[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/]+(?:(?:\\.(?:\"(?:\\\\?[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/\\.()<>\\[\\] @]|\\\\\"|\\\\\\\\)*\"|[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/]+))*\\.[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/]+)?)|(?:\"(?:\\\\?[\\w`~!#$%^&*\\-=+;:{}\'|,?\\/\\.()<>\\[\\] @]|\\\\\"|\\\\\\\\)+\"))@(?:[a-zA-Z\\d\\-]+(?:\\.[a-zA-Z\\d\\-]+)*|\\[\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\])$";
            return this.StringMatchesRegEx(toValidate, emailRegex);
        }

        protected bool StringMatchesRegEx(string toValidate, string regex)
        {
            return Regex.IsMatch(toValidate, regex);
        }

        protected bool StringsAreEqual(string stringA, string stringB)
        {
            return stringA == stringB;
        }

        protected bool StringIsNumeric(string toValidate)
        {
            return toValidate.All(char.IsDigit);
        }

    }
}
