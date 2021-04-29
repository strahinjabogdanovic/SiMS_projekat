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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PagePrioritetZakazivanja.xaml
    /// </summary>
    public partial class PagePrioritetZakazivanja : Page
    {
        public PagePrioritetZakazivanja()
        {
            InitializeComponent();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTerminiSekretar());
        }

        private void Datum_Checked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageDatum());
        }

        private void Lekar_Checked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageLekar());
        }
    }
}
