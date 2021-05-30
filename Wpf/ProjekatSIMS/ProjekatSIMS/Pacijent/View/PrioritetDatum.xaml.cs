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
    /// Interaction logic for PrioritetDatum.xaml
    /// </summary>
    public partial class PrioritetDatum : Window
    {
        public PrioritetDatum()
        {
            InitializeComponent();

           
        }


        private void DatumZakaz_Click(object sender, RoutedEventArgs e)
        {
            DatumZakaz dz = new DatumZakaz(tb1.Text);
            dz.ShowDialog();
        }

    }
}
