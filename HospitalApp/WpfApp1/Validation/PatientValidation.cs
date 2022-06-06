using Controller;
using FileHandler;
using Repo;
using Service;
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
        /*
        PatientFileHandler patientFileHandler = new PatientFileHandler();
        PatientRepository patientRepository = new PatientRepository(patientFileHandler);
        PatientService patientService = new PatientService(patientRepository);
        PatientController patientController = new PatientController(patientService);
        */
        public static bool ValidationError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationError = false;
            var s = value as string;

            if (s.Length != 13) 
            {
                ValidationError = true;
                return new ValidationResult(false, "UPN must have\n13 characters");
            }

            else if (!Regex.IsMatch(s, @"[0-9]+"))
            {
                ValidationError = true;
                return new ValidationResult(false, "Wrong\nformat\nof UPN");
            }
            /*
            else if (patientController.PatientUPNExists(s))
            {
                ValidationError = true;
                return new ValidationResult(false, "Taken UPN.\nYou must have \nmade a mistake");
            }
            */
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
