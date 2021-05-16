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
    public partial class PageLekar : Page
    {
        public PageLekar()
        {
            InitializeComponent();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PagePrioritetZakazivanja());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string lekar = comboBox.SelectedValue.ToString();
            this.NavigationService.Navigate(new PageZakazivanjeLekar(lekar));
        }
    }
}
