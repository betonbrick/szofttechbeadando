using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HospitalManagement.View;

namespace HospitalManagement.ViewModel
{
    public class DataPrinting
    {
        PatientsView patientsView = new PatientsView();
        public void OnDataGridPrinting()
        {
            string title = "Lista";
            PrintDialog Printdlg = new PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
              patientsView.dgvPatients.Measure(pageSize);

                patientsView.dgvPatients.Arrange(new Rect(20, 20, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(patientsView.dgvPatients,title);
            }
        }
    }
}
