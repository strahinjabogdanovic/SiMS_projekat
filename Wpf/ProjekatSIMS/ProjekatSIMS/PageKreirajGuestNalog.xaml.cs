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
    /// Interaction logic for PageKreirajGuestNalog.xaml
    /// </summary>
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
            string tb = textBox.Text;
            string tb1 = textBox1.Text;
            string tb2 = textBox2.Text;
            g.Kreiraj(tb, tb1, tb2);

            this.NavigationService.Navigate(new PageGuestNalozi());

        }
    }
}
