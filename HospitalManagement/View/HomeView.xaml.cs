using HospitalManagement.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace HospitalManagement.View
{
    public partial class HomeView : UserControl
    {
        HospitalViewModel hospitalViewModel;
        public HomeView()
        {
            InitializeComponent();
            LoadContent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadContent();
        }

        public void LoadContent()
        {
            hospitalViewModel = new HospitalViewModel();
            DataContext = hospitalViewModel;
        }
    }
}
