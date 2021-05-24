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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    public partial class DodajOpremu : Window
    {
        int redStvari = 0;
        public ObservableCollection<Oprema> Opreme
        {
            get;
            set;
        }
        public DodajOpremu(int c)
        {
            redStvari = c;
            InitializeComponent();
        }
        private void odustani_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void potvrdi_click(object sender, RoutedEventArgs e)
        {
            Close();
            OpremaFileStorage p = new OpremaFileStorage();

            string tb = tb2.Text;
            string tb1 = tb3.Text;

            p.Kreiraj(tb, tb1, redStvari);
        }
    }
}
