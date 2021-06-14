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
    /// Interaction logic for PageGenerisanIzvestaj.xaml
    /// </summary>
    public partial class PageGenerisanIzvestaj : Page
    {
        public PageGenerisanIzvestaj(string s1, string s2)
        {
            InitializeComponent();
            textBox.Text = s1;
            textBox1.Text = s2;
        }

        private void Stampaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "PageGenerisanIzvestaj");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageIzvestaj());
        }
    }
}
