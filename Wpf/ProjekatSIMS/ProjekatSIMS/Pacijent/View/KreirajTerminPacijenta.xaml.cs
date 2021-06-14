using ProjekatSIMS.Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for KreirajTerminPacijenta.xaml
    /// </summary>
    public partial class KreirajTerminPacijenta : Window
    {
        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        public KreirajTerminPacijenta()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Close();
            PacijentFileStorage p = new PacijentFileStorage();

            string lekar = comboBox.SelectedValue.ToString();
            string tb = textBox.Text;
            string tb1 = textBox1.Text;

            p.Kreiraj(lekar, tb, tb1);


        }
    }
}