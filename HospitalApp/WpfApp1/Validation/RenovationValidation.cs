﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.View.Manager.Rooms;

namespace WpfApp1.Validation
{
    public class MaxDurationValidationRule: ValidationRule
    { 
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        { 
            ValidationHasError = false;

            if (value is int)
            {
                int d = (int)value;
                if (d <= 0)
                {
                    ValidationHasError = true;
                    return new ValidationResult(false, "Min duration\nis 1 day.");
                }

                DateTime endDate = BasicRenovation.startDate.AddDays(d);
                DateTime firstBusyDate = DateTime.MaxValue;
                foreach(DateTime date in BasicRenovation.busyDates) 
                {

                    if(date > BasicRenovation.startDate) 
                    {
                        firstBusyDate = date;
                        break;
                    }

                }

                if (endDate.Date > firstBusyDate.Date)
                {
                    ValidationHasError = true;
                    return new ValidationResult(false, "Busy day\nis included.");
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

