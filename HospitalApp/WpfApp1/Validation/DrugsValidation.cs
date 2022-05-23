using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Controller;
using WpfApp1.View.Manager.Drugs;
using WpfApp1.ViewModel.Manager.Drugs;

namespace WpfApp1.Validation
{
        public class DrugNameValidationRule : ValidationRule
        {
            private readonly DrugController drugsController = new DrugController();
            public static bool ValidationHasError { get; set; }
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
                ValidationHasError = false;
                var s = GetBoundValue(value) as string;
                if (drugsController.DrugExists(s))
                {
                    ValidationHasError = true;
                    DrugsCreateViewModel.SaveCommand.RaiseCanExecuteChanged();
                    return new ValidationResult(false, "Taken name.");
                }
                else
                {
                    DrugsCreateViewModel.SaveCommand.RaiseCanExecuteChanged();
                    return new ValidationResult(true, null);
                }
            }

            private object GetBoundValue(object value)
            {
                if (value is BindingExpression)
                {
                    // ValidationStep was UpdatedValue or CommittedValue (Validate after setting)
                    // Need to pull the value out of the BindingExpression.
                    BindingExpression binding = (BindingExpression)value;

                    // Get the bound object and name of the property
                    object dataItem = binding.DataItem;
                    string propertyName = binding.ParentBinding.Path.Path;

                    // Extract the value of the property.
                    object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                    // This is what we want.
                    return propertyValue;
                }
                else
                {
                    // ValidationStep was RawProposedValue or ConvertedProposedValue
                    // The argument is already what we want!
                    return value;
                }
            }
        }

        public class RequiredNameFieldValidationRule : ValidationRule
        {
            public static bool ValidationHasError { get; set; }
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
                ValidationHasError = false;
                var s = GetBoundValue(value) as string;
                if (!Regex.IsMatch(s, @".*[^ ].*"))
                {
                    ValidationHasError = true;
                    DrugsCreateViewModel.SaveCommand.RaiseCanExecuteChanged();
                    return new ValidationResult(false, "Required field");
                }
                else
                {
                    DrugsCreateViewModel.SaveCommand.RaiseCanExecuteChanged();
                    return new ValidationResult(true, null);
                }
            }


            private object GetBoundValue(object value)
            {
                if (value is BindingExpression)
                {
                    // ValidationStep was UpdatedValue or CommittedValue (Validate after setting)
                    // Need to pull the value out of the BindingExpression.
                    BindingExpression binding = (BindingExpression)value;

                    // Get the bound object and name of the property
                    object dataItem = binding.DataItem;
                    string propertyName = binding.ParentBinding.Path.Path;

                    // Extract the value of the property.
                    object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                    // This is what we want.
                    return propertyValue;
                }
                else
                {
                    // ValidationStep was RawProposedValue or ConvertedProposedValue
                    // The argument is already what we want!
                    return value;
                }
            }
        }

    public class RequiredManufacturerFieldValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            var s = GetBoundValue(value) as string;
            if (!Regex.IsMatch(s, @".*[^ ].*"))
            {
                ValidationHasError = true;
                DrugsCreateViewModel.SaveCommand.RaiseCanExecuteChanged();
                return new ValidationResult(false, "Required field");
            }
            else
            {
                DrugsCreateViewModel.SaveCommand.RaiseCanExecuteChanged();
                return new ValidationResult(true, null);
            }
        }


        private object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                // ValidationStep was UpdatedValue or CommittedValue (Validate after setting)
                // Need to pull the value out of the BindingExpression.
                BindingExpression binding = (BindingExpression)value;

                // Get the bound object and name of the property
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;

                // Extract the value of the property.
                object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                // This is what we want.
                return propertyValue;
            }
            else
            {
                // ValidationStep was RawProposedValue or ConvertedProposedValue
                // The argument is already what we want!
                return value;
            }
        }
    }

    public class RequiredIngredientsFieldValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            var s = GetBoundValue(value) as string;
            if (!Regex.IsMatch(s, @".*[^ ].*"))
            {
                ValidationHasError = true;
                DrugsCreateViewModel.SaveCommand.RaiseCanExecuteChanged();
                return new ValidationResult(false, "Required field");
            }
            else
            {
                DrugsCreateViewModel.SaveCommand.RaiseCanExecuteChanged();
                return new ValidationResult(true, null);
            }
        }


        private object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                // ValidationStep was UpdatedValue or CommittedValue (Validate after setting)
                // Need to pull the value out of the BindingExpression.
                BindingExpression binding = (BindingExpression)value;

                // Get the bound object and name of the property
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;

                // Extract the value of the property.
                object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                // This is what we want.
                return propertyValue;
            }
            else
            {
                // ValidationStep was RawProposedValue or ConvertedProposedValue
                // The argument is already what we want!
                return value;
            }
        }
    }

}
