using HospitalManagement.ViewModel;
using System.Windows.Controls;

namespace HospitalManagement.View
{
    public partial class EmployeesView : UserControl
    {
        HospitalViewModel employeeViewModel;
        public EmployeesView()
        {
            InitializeComponent();
            employeeViewModel = new HospitalViewModel();
            DataContext = employeeViewModel;
        }
    }
}
