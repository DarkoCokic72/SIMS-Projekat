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
    public class StringToIntegerValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            try
            {
                var s = value as string;
                int r;
                if (int.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                ValidationHasError = true;
                return new ValidationResult(false, "Enter a valid\ninteger value.");
            }
            catch
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Unknown error occured.");
            }

           
        }
    }

    public class MinMaxValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            if (value is int)
            {
                int d = (int)value;
                if (d < 0)
                {
                    ValidationHasError = true;
                    return new ValidationResult(false, "Floors start\nfrom 0.");
                }
                if (d > 5)
                {
                    ValidationHasError = true;
                    return new ValidationResult(false, "Hospital has\n5 floors.");
                }
                return new ValidationResult(true, null);
            }
            else
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public class IdValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            var s = value as string;
            if (!Regex.IsMatch(s, @"R[0-9]+"))
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Wrong format");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
