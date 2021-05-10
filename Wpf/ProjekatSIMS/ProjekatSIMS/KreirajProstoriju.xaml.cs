using Package1;
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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for KreirajProstoriju.xaml
    /// </summary>
    public partial class KreirajProstoriju : Window
    {
        public ObservableCollection<Prostorije> Prostorije
        {
            get;
            set;
        } 

        public KreirajProstoriju()
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
            ProstorijeFileStorage p = new ProstorijeFileStorage();

            string tb = textBox.Text;
            string tb1 = textBox1.Text;
            string tb2 = textBox2.Text;
            string tb3 = textBox3.Text;
            string tb4 = textBox4.Text;

            p.Kreiraj(tb, tb1, tb2, tb3, tb4);

        }
    }
}
