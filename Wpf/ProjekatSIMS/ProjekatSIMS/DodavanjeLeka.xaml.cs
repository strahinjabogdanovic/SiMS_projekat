﻿using Package1;
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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for DodavanjeLeka.xaml
    /// </summary>
    public partial class DodavanjeLeka : Window
    {
        public DodavanjeLeka()
        {
            InitializeComponent();
        }

        private void potvrdi_click(object sender, RoutedEventArgs e)
        {
            Close();
            LekoviFileStorage l = new LekoviFileStorage();

            string t1 = tb1.Text;
            string t2 = tb2.Text;
            string t3 = tb3.Text;
            string t4 = tb4.Text;

            MessageBox.Show("Lek poslat na validaciju kod lekara");

            l.Kreiraj(t1, t2, t3, t4);

        }
    }
}
