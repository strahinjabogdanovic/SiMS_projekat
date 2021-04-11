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
    /// Interaction logic for KreirajNalog.xaml
    /// </summary>
    public partial class KreirajNalog : Window
    {
        public ObservableCollection<Pacijent> Korisnici
        {
            get;
            set;
        }

        public KreirajNalog()
        {
            InitializeComponent();
            
        }

        Pol p;
        int ids = 0;

        private void PotvrdiNalog_Click(object sender, RoutedEventArgs e)
        {
            Close();
            NaloziPacijenataFileStorage np = new NaloziPacijenataFileStorage();

            string gender = comboBox.SelectedValue.ToString();
            string tb = textBox.Text;
            string tb1 = textBox1.Text;
            string tb2 = textBox2.Text;
            string tb3 = textBox3.Text;
            string tb5 = textBox5.Text;
            string tb6 = textBox6.Text;
            string tb7 = textBox7.Text;

            np.Kreiraj(gender, tb, tb1, tb2, tb3, tb5, tb6, tb7);


        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
