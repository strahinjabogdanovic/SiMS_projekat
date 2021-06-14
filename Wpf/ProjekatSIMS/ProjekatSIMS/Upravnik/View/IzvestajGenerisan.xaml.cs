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

namespace ProjekatSIMS.Upravnik.View
{
    /// <summary>
    /// Interaction logic for IzvestajGenerisan.xaml
    /// </summary>
    public partial class IzvestajGenerisan : Page
    {
        public IzvestajGenerisan(String text1, String text2)
        {
            InitializeComponent();
            s1.Text = text1;
            s2.Text = text2;
        }

        private void ButtonBase_OnClickutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "stampaj");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

    }
}
