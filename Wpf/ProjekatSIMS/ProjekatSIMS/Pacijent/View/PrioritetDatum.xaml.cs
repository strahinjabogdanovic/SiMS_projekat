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

            if (tb1.SelectedDate != null)
            {

                string s = tb1.SelectedDate.ToString();
                string[] ss = s.Split(' ');
                string m = ss[0];
                string[] sss = m.Split('/');
                string datum = sss[1] + "." + sss[0] + "." + sss[2] + ".";


                DatumZakaz dz = new DatumZakaz(datum);
                this.Close();
                dz.ShowDialog();
            }
            else MessageBox.Show("Niste izabrali datum!");
        }

    }
}

