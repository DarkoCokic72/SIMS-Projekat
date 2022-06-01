using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using Controller;
using WpfApp1.View.Manager.Rooms;

namespace WpfApp1.Validation
{
    public class MaxDurationRoomsMergeValidationRule : ValidationRule
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

                DateTime endDate = MergeRooms2.startDate.AddDays(d);
                DateTime firstBusyDate = DateTime.MaxValue;
                foreach (DateTime date in MergeRooms2.busyDates)
                {

                    if (date > MergeRooms2.startDate)
                    {
                        firstBusyDate = date;
                        break;
                    }

                }

                if (endDate >= firstBusyDate)
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

    public class MaxDurationRoomSplitValidationRule : ValidationRule
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

                DateTime endDate = SplitRoom2.startDate.AddDays(d);
                DateTime firstBusyDate = DateTime.MaxValue;
                foreach (DateTime date in SplitRoom2.busyDates)
                {

                    if (date > SplitRoom2.startDate)
                    {
                        firstBusyDate = date;
                        break;
                    }

                }

                if (endDate >= firstBusyDate)
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

    public class RoomIdMergeSplitValidationRule : ValidationRule
    {
        private RoomController roomController = new RoomController();
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            var s = value as string;
            if (string.IsNullOrEmpty(s)) return new ValidationResult(true, null);
            if (roomController.RoomIdExists(s.Trim()))
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Taken id.");
            }
            else if (!Regex.IsMatch(s, @"R[0-9]+"))
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Wrong format.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }

    public class RoomIdMergeSplitValidationRule2 : ValidationRule
    {
        private RoomController roomController = new RoomController();
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            var s = value as string;
            if (string.IsNullOrEmpty(s)) return new ValidationResult(true, null);
            if (roomController.RoomIdExists(s.Trim()))
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Taken id.");
            }
            else if (!Regex.IsMatch(s, @"R[0-9]+"))
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Wrong format.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }

    public class SameIdMergeSplitValidationRule : ValidationRule
    {
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationHasError = false;
            if (string.IsNullOrEmpty(SplitRooms1.idBinding) || string.IsNullOrEmpty(SplitRooms1.id2Binding)) return new ValidationResult(true, null);
            if (SplitRooms1.idBinding == SplitRooms1.id2Binding)
            {
                ValidationHasError = true;
                return new ValidationResult(false, "Same id.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }

}
