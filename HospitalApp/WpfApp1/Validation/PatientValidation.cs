using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Validation
{

    public class UPNValidation : ValidationRule
    {
        public static bool ValidationError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationError = false;
            var s = value as string;

            if (s.Length != 13) 
            {
                ValidationError = true;
                return new ValidationResult(false, "UPN must have 13 characters");
            }

            if (!Regex.IsMatch(s, @"[0-9]+"))
            {
                ValidationError = true;
                return new ValidationResult(false, "Wrong format\nof UPN");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
