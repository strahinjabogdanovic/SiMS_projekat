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
    /// Interaction logic for ValidacijaLeka.xaml
    /// </summary>
    public partial class ValidacijaLeka : Window
    {
        public Lek lekic;
        public ValidacijaLeka(Lek lekzaValidaciju )
        {
            InitializeComponent();
            lekic = lekzaValidaciju;
            t1.Text = lekic.nazivleka;
            t2.Text = lekic.sifraleka;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}