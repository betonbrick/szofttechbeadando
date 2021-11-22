using System;
using System.Windows;
using System.Windows.Controls;

using HospitalManagement.View;

namespace HospitalManagement.ViewModel
{
    public class DataPrinting
    {
        PatientsView patientsView = new PatientsView();
        public void OnDataGridPrinting( )
        {
            string title = "Lista";
            PrintDialog Printdlg = new PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
               

                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);

                patientsView.dgvPatients.Measure(pageSize);

                Printdlg.PrintVisual(patientsView.dgvPatients, title);
            }
        }


    }
}
