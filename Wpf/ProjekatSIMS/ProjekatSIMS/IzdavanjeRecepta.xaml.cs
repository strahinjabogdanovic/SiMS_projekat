using ProjekatSIMS.Package1;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for IzdavanjeRecepta.xaml
    /// </summary>
    public partial class IzdavanjeRecepta : Window
    {

        public IzdavanjeRecepta(TextBlock tb)
        {
            InitializeComponent();
            string jmbg = tb.Text;
            textBlock.Text = jmbg;

        }

        private void Izdaj_Click(object sender, RoutedEventArgs e)
        {
            string sifra = t.Text;
            string naziv = t2.Text;
            string nacin = t3.Text;
            string naKolikoSati = t4.Text;
            using (var sw = new StreamWriter("recepti.txt", true))
            {
                int id = 0;

                sw.WriteLine(sifra + "/" + naziv + "/" + nacin + "/" + naKolikoSati + "/" + textBlock.Text);
                sw.Close();



            }
        }
    }
}
