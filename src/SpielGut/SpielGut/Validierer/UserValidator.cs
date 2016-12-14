using KDG.DataObjectHandler.Validators;
using SpielGut.Klassen;

namespace SpielGut.Validierer
{
    class UserValidator : BaseValidator<Benutzer>
    {
        private Benutzer _user;
        public override bool IsValid(Benutzer user)
        {
            this._user = user;
            return this.FirstNameIsValid() &&
                   this.SurnameIsValid() &&
                   this.EmailIsValid() &&
                   this.PasswordIsValid() &&
                   this.AddressIsValid() &&
                   this.PhoneNumberIsValid();

        }

        private bool FirstNameIsValid()
        {
            return this.StringHasValue(this._user.Vorname) &&
                   this.StringIsInMaxLenght(this._user.Vorname, 40);
        }

        private bool SurnameIsValid()
        {
            return this.StringHasValue(this._user.Nachname) &&
                   this.StringIsInMaxLenght(this._user.Nachname, 40);
        }
        private bool EmailIsValid()
        {
           
            return this.StringHasValue(this._user.Email) &&
                   this.StringIsEmail(this._user.Email) &&
                   this.StringIsInMaxLenght(this._user.Email, 100);
        }
        private bool PasswordIsValid()
        {
            return this.StringHasValue(this._user.Passwort) &&
                   this.StringHasValue(this._user.PasswortWiderholen) &&
                   this.StringIsInRange(this._user.Passwort, 8, 64) &&
                   this.StringsAreEqual(this._user.Passwort, this._user.PasswortWiderholen);
        }
        private bool AddressIsValid()
        {
            //TODO: ADDRESS VALIDATE
            return true;
            return this.StringHasValue(this._user.Vorname) &&
                   this.StringIsInMaxLenght(this._user.Vorname, 40);
        }
        private bool PhoneNumberIsValid()
        {
            //TODO: PHONE VALIDATE
            return true;
            return this.StringHasValue(this._user.Vorname) &&
                   this.StringIsInMaxLenght(this._user.Vorname, 40);
        }
    }
}
