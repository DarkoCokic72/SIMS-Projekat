using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Controller;
using WpfApp1.View.Manager.Equipment;
using WpfApp1.View.Rooms;

namespace WpfApp1.Validation
{

    public class MinMaxQuantityValidationRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public static bool ValidationHasError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            Min = 1;
            EquipmentController equipmentController = new EquipmentController();
            Max = equipmentController.MaxQuantityToRelocate(RoomsEquipment.SelectedEquipment);
   
            ValidationHasError = false;
            
            if (value is int)
            {
                int d = (int)value;
                if (d < Min)
                {
                    ValidationHasError = true;
                    return new ValidationResult(false, "Enter value\ngreater than 0.");
                }
                if (d > Max)
                {
                    ValidationHasError = true;
                    return new ValidationResult(false, "Max quantity\nis " + Max);
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
