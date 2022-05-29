using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using WpfApp1.Model;
using WpfApp1.Service;

namespace WpfApp1.Controller
{
    public class RenovationController
    {
        public void SchedulingRenovation(Renovation renovation)
        {
            renovationService.SchedulingRenovation(renovation);
        }

        public void SchedulingAdvancedRenovation(AdvancedRenovation renovation)
        {
            renovationService.SchedulingAdvancedRenovation(renovation);
        }

        public void Renovate()
        {
            renovationService.Renovate();
        }

        public RenovationService renovationService = new RenovationService();
    }
}
