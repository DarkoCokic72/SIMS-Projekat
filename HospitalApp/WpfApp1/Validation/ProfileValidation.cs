using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Controller;
using WpfApp1.View;


namespace WpfApp1.Validation
{
    public class EmailValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        private UserAccountController userController = new UserAccountController();
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            var s = value as string;
            if (userController.EmailAlreadyExists(s))
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Taken email.");
            }
            else if (Regex.IsMatch(s, @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"))
            {
                return new ValidationResult(true, null);

            }
            else
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Wrong format.");
            }
        }
    }

    public class PhoneNumberValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            var s = value as string;
            if (Regex.IsMatch(s, @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{3,4}$"))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Wrong format.");
            }
        }
    }
}
