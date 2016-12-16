using System;
using KDG.DataObjectHandler.Validators;

namespace SpielGut.Validierer
{
    public class PasswordValidator : BaseValidator<string>
    {
        public override bool Validate(string objectToValid)
        {
            return this.StringHasValue(objectToValid) && this.StringIsInRange(objectToValid, 8, 64);
        }
    }
}