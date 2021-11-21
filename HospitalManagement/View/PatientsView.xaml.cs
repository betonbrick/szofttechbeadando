using HospitalManagement.ViewModel;
using System.Windows.Controls;

namespace HospitalManagement.View
{
    public partial class PatientsView : UserControl
    {
        HospitalViewModel patientViewModel;
        public PatientsView()
        {
            InitializeComponent();
            patientViewModel = new HospitalViewModel();
            DataContext = patientViewModel;
        }
    }
}
