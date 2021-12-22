using HospitalManagement.ViewModel;
using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace HospitalManagement.View
{
    public partial class EmployeesView : UserControl
    {
        private DispatcherTimer dispatcherTimer;

        HospitalViewModel employeeViewModel;
        public EmployeesView()
        {
            InitializeComponent();

            employeeViewModel = new HospitalViewModel();
            DataContext = employeeViewModel;

            cmbxSpecialty.Items.Add("Belgyógyász");
            cmbxSpecialty.Items.Add("Endokrinológus");
            cmbxSpecialty.Items.Add("Gasztroenterológus");
            cmbxSpecialty.Items.Add("Sebész");
            cmbxSpecialty.Items.Add("Szülész-nőgyógyász");
            cmbxSpecialty.Items.Add("Fül-orr-gégész");
            cmbxSpecialty.Items.Add("Szemész");
            cmbxSpecialty.Items.Add("Urológus");

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }

        private void btnSaveEmp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Visible;
            dispatcherTimer.Start();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Visible;
            dispatcherTimer.Start();
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Visible;
            dispatcherTimer.Start();
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Visible;
            dispatcherTimer.Start();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")).IsMatch(txtEmail.Text))
            {
                txtEmail.Background = Brushes.White;
            }
            else
            {
                txtEmail.Background = Brushes.IndianRed;
            }
        }

       

        private void TxtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((new Regex(@"^[0-9]{9}$")).IsMatch(txtPhone.Text))
            {
                txtPhone.Background = Brushes.White;
            }
            else
            {
                txtPhone.Background = Brushes.IndianRed;
            }

        }
    }
}
