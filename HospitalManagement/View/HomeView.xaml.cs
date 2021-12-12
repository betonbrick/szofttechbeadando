﻿using HospitalManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
