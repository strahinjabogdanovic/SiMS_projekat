using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PageSKreirajNalog.xaml
    /// </summary>
    public partial class PageSKreirajNalog : Page
    {
        public ObservableCollection<Pacijent> Korisnici
        {
            get;
            set;
        }

        public PageSKreirajNalog()
        {
            InitializeComponent();
        }

        private void PotvrdiNalog_Click(object sender, RoutedEventArgs e)
        {
            //Close();
            //this.NavigationService.Navigate(new PageSekretar());
            NaloziPacijenataFileStorage np = new NaloziPacijenataFileStorage();

            string gender = comboBox.SelectedValue.ToString();
            string tb = textBox.Text;
            string tb1 = textBox1.Text;
            string tb2 = textBox2.Text;
            string tb5 = textBox5.Text;
            string tb6 = textBox6.Text;
            string tb7 = textBox7.Text;
            string datum = myDatePicker.ToString();
            String[] termin = datum.Split(' ');
            String[] termin1 = termin[0].Split('-');
            string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";

            np.Kreiraj(gender, tb, tb1, tb2, datum1, tb5, tb6, tb7);

            this.NavigationService.Navigate(new PageSekretar());
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
            //Close();
        }
    }
}
