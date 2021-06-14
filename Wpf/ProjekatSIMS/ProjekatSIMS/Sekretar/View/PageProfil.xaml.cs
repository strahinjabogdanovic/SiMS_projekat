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
    /// Interaction logic for PageProfil.xaml
    /// </summary>
    public partial class PageProfil : Page
    {
        public PageProfil()
        {
            InitializeComponent();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }
    }
}
