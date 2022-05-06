using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Validation
{
        public class MinMaxDrugsQuantityValidationRule : ValidationRule
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public static bool ValidationHasError { get; set; }
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
                Min = 1;
               

                ValidationHasError = false;

                if (value is int)
                {
                    int d = (int)value;
                    if (d < Min)
                    {
                        ValidationHasError = true;
                        return new ValidationResult(false, "Enter value\ngreater than 0.");
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
    
}
