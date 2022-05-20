using System.Threading;
using System.Windows;
using Controller;
using FileHandler;
using Model;
using Repo;
using Service;
using WpfApp1.Model;
using WpfApp1.View;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static EquipmentController equipmentController = new EquipmentController();
        public static Thread RelocationThread = new Thread(() =>
        {
            while (true)
            {
                equipmentController.Relocate();
            }
        });
        private static RoomController roomController = new RoomController();
        private static AppointmentFileHandler handler = new AppointmentFileHandler();
        private static AppointmentRepository appointmentRepository = new AppointmentRepository(handler);
        private static AppointmentService appointmentService = new AppointmentService(appointmentRepository);
        private static AppointmentController appointmentController = new AppointmentController(appointmentService);
        public static Thread RenovationThread = new Thread(() =>
        {
            while (true)
            {
                roomController.Renovate();
            }
        });

        public static bool CheckNotification = false;

        public static Thread AppointmentEdited = new Thread(() =>
        {
            while (true) 
            {
                Thread.Sleep(1000);
                if (Login.userAccount == null) 
                {
                    continue;
                }

                if (typeof(Secretary) == Login.userAccount.GetType() || typeof(Manager) == Login.userAccount.GetType()) 
                {
                    continue;
                }

                if (!CheckNotification) 
                {
                    continue;
                }

                foreach (Appointment appointment in appointmentController.GetAll()) 
                {
                    if (!appointment.Changed) 
                    {
                        continue;
                    }

                    if (appointment.Patient.UniquePersonalNumber == Login.userAccount.UniquePersonalNumber || appointment.Physician.UniquePersonalNumber == Login.userAccount.UniquePersonalNumber) 
                    {
                        MessageBox.Show("Vas pregled je promenjen");
                        appointment.Changed = false;
                        appointmentController.Update(appointment);
                    }

                    
                }

                
            }
        });
    }
}
