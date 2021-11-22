using System;
using System.Printing;
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
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog()==true)
            {
                Size pageSize = new Size(3508, 2480);

                patientsView.dgvPatients.Measure(pageSize);

              printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
              printDialog.PrintVisual(patientsView.dgvPatients, title);
            }
        }


    }
}
