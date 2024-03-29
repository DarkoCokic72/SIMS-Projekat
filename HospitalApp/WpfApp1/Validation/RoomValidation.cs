﻿using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using Controller;
using WpfApp1.ViewModel.Manager.Rooms;

namespace WpfApp1.Validation
{
    public class StringToIntegerValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
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

    public class IdValidationRule : ValidationRule
    {
        private readonly RoomController roomController = new RoomController();
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            var s = GetBoundValue(value) as string;
            if (roomController.RoomIdExists(s.Trim()))
            {
                ValidationHasError = true;
                CreateRoomViewModel.SaveCommand.RaiseCanExecuteChanged();
                return new ValidationResult(false, "Taken id.");
            }
            else if (!Regex.IsMatch(s, @"R[0-9]+"))
            {
                ValidationHasError = true;
                CreateRoomViewModel.SaveCommand.RaiseCanExecuteChanged();
                return new ValidationResult(false, "Wrong format.");
            }
            else
            {
                CreateRoomViewModel.SaveCommand.RaiseCanExecuteChanged();
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
            else
            {
                return value;
            }
        }
    }
}
