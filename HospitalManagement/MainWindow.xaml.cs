using HospitalManagement.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HospitalManagement
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetActiveUserControl(HomeView);
        }

        public void SetActiveUserControl(UserControl userControl)
        {
            HomeView.Visibility = Visibility.Collapsed;
            PatientsView.Visibility = Visibility.Collapsed;
            EmployeesView.Visibility = Visibility.Collapsed;

            userControl.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(HomeView);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(PatientsView);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(EmployeesView);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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
