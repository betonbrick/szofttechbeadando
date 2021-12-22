using HospitalManagement.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HospitalManagement
{
    public partial class LoginWindow : Window
    {
        private DispatcherTimer dispatcherTimer;

        LoginViewModel loginViewModel;

        public LoginWindow()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            messageBlock.Visibility = System.Windows.Visibility.Visible;
            dispatcherTimer.Start();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
