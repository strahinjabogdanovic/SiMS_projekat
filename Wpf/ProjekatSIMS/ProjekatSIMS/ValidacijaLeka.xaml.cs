using Package1;
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
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for ValidacijaLeka.xaml
    /// </summary>
    public partial class ValidacijaLeka : Window
    {
        public Lek lekic;
        public ValidacijaLeka(Lek lekzaValidaciju )
        {
            InitializeComponent();
            lekic = lekzaValidaciju;
            t1.Text = lekic.nazivleka;
            t2.Text = lekic.sifraleka;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lekic.validiran = "ne";
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            lekic.validiran = "da";
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekovi.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                        String[] jedanLek = line.Split('/');
                    if (jedanLek[0].Equals(lekic.sifraleka)) {
                        lekic.sastojci = jedanLek[2];
                        lekic.zamena = jedanLek[3];
                        sw.WriteLine(lekic.sifraleka + "/" + lekic.nazivleka + "/" + lekic.sastojci + "/" + lekic.zamena + "/" + lekic.validiran);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("lekovi.txt");
            File.Move(tempFile, "lekovi.txt");
        }

        private void nazad_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LekarPocetnaStranica lekarPocetnaStranica = new LekarPocetnaStranica();
            this.Close();
            lekarPocetnaStranica.ShowDialog();
        }
    }

}
