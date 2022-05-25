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
                if (drugsController.DrugExists(s, ""))
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
                    BindingExpression binding = (BindingExpression)value;
                    object dataItem = binding.DataItem;
                    string propertyName = binding.ParentBinding.Path.Path;
                    object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);
                    return propertyValue;
                }
                return value;
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
                    BindingExpression binding = (BindingExpression)value;
                    object dataItem = binding.DataItem;
                    string propertyName = binding.ParentBinding.Path.Path;
                    object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);
                    return propertyValue;
                }
                return value;
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
                BindingExpression binding = (BindingExpression)value;
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;
                object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);
                return propertyValue;
            }
            return value;
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
                BindingExpression binding = (BindingExpression)value;
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;
                object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);
                return propertyValue;
            }
            return value;
            
        }
    }

}
