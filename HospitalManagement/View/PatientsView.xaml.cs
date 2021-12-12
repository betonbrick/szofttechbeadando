using HospitalManagement.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HospitalManagement.View
{
    public partial class PatientsView : UserControl
    {
        private DispatcherTimer dispatcherTimer;

        HospitalViewModel patientViewModel;
        public PatientsView()
        {
            InitializeComponent();
            patientViewModel = new HospitalViewModel();
            DataContext = patientViewModel;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
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

        private void Button_Click_3(object sender, System.Windows.RoutedEventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Visible;
            dispatcherTimer.Start();
        }
    }
}
