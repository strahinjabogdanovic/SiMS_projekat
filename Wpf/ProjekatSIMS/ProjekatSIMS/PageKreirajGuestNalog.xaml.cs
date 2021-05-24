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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    public partial class PageKreirajGuestNalog : Page
    {
        public ObservableCollection<GuestNalog> Guest
        {
            get;
            set;
        }

        public PageKreirajGuestNalog()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageGuestNalozi());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            GuestFileStorage g = new GuestFileStorage();
            string ime = textBox.Text;
            string prezime = textBox1.Text;
            string jmbg = textBox2.Text;
            string guestNalog = (ime + "/" + prezime + "/" + jmbg);
            g.Kreiraj(guestNalog);

            this.NavigationService.Navigate(new PageGuestNalozi());

        }
    }
}
