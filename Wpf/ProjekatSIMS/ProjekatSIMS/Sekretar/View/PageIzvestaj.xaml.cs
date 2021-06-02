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

namespace ProjekatSIMS.Sekretar.View
{
    /// <summary>
    /// Interaction logic for PageIzvestaj.xaml
    /// </summary>
    public partial class PageIzvestaj : Page
    {
        public PageIzvestaj()
        {
            InitializeComponent();
        }

        private void generisi_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(myDatePicker.ToString()) && !string.IsNullOrEmpty(myDatePicker1.ToString()))
            {
                string datum = myDatePicker.ToString();
                String[] termin = datum.Split(' ');
                String[] termin1 = termin[0].Split('-');
                string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";

                string datum2 = myDatePicker1.ToString();
                String[] termin2 = datum2.Split(' ');
                String[] termin12 = termin2[0].Split('-');
                string datum12 = termin12[0] + "." + termin12[1] + "." + termin12[2] + ".";

                this.NavigationService.Navigate(new PageGenerisanIzvestaj(datum1, datum12));
            }
        }

        private void nazad_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }
    }
}
