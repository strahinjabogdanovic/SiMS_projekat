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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for BiranjePrioritetaZakazivanja.xaml
    /// </summary>
    public partial class BiranjePrioritetaZakazivanja : Window
    {
        public BiranjePrioritetaZakazivanja()
        {
            InitializeComponent();
        }

        private void Date_Checked(object sender, RoutedEventArgs e)
        {
            PrioritetDatum pd = new PrioritetDatum();
            pd.ShowDialog();
        }

        private void Doctor_Checked(object sender, RoutedEventArgs e)
        {
            //PrioritetLekar pl = new PrioritetLekar();
            //pl.ShowDialog();
        }
    }
}
