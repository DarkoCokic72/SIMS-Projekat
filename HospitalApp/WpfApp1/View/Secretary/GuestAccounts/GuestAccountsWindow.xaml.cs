using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;
using FileHandler;
using Model;
using Repo;
using Service;
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class GuestAccountsWindow : Window
    {
        public static GuestAccountsWindow guestAccountsWindowInstance;
        public GuestAccountController guestAccountsController;
        public ObservableCollection<GuestAccount> GuestAccounts { get; set; }

        public GuestAccountsWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            GuestAccountFileHandler fileHandler = new GuestAccountFileHandler();
            GuestAccountRepository repository = new GuestAccountRepository(fileHandler);
            GuestAccountService service = new GuestAccountService(repository);
            guestAccountsController = new GuestAccountController(service);

            GuestAccounts = new ObservableCollection<GuestAccount>(guestAccountsController.GetAll());
        }

        public static GuestAccountsWindow GetGuestAccountsWindow()
        {
            if (guestAccountsWindowInstance == null)
            {
                guestAccountsWindowInstance = new GuestAccountsWindow();
            }
            return guestAccountsWindowInstance;
        }

        public void refreshContentOfGrid()
        {
            dgGuestAccounts.ItemsSource = null;
            dgGuestAccounts.ItemsSource = guestAccountsController.GetAll();
        }

        public GuestAccount getSelectedGuestAccount()
        {
            return (GuestAccount)dgGuestAccounts.SelectedItem; ;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            GuestAccount guestAccount = getSelectedGuestAccount();
            if (!btn.Content.Equals("Create") && guestAccount == null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return;
            }


            if (btn.Content.Equals("Create"))
            {
                CreateGuestAccount createGuestAccount = new CreateGuestAccount();
                createGuestAccount.Show();
            }
            else if (btn.Content.Equals("Edit"))
            {

                GuestAccountsEdit guestAccountsEdit = new GuestAccountsEdit();
                guestAccountsEdit.Show();

            }
            else if (btn.Content.Equals("Delete"))
            {

                GuestAccountsDelete guestAccountsDelete = new GuestAccountsDelete();
                guestAccountsDelete.Show();
            }

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            guestAccountsWindowInstance = null;
        }

    }
}