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
using ProjekatSIMS.Package1;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for BolnicaAnketa.xaml
    /// </summary>
    public partial class BolnicaAnketa : Window
    {
        public BolnicaAnketa()
        {
            InitializeComponent();
        }

        private void PopuniAnketu()
        {
            string tempFile = System.IO.Path.GetTempFileName();
            AnketaStorage anketaLekar = new AnketaStorage();

            string c = cbLjub.SelectedValue.ToString();
            string usluga = anketaLekar.selektovaniOdgovor(c);

            string cs = cbStr.SelectedValue.ToString();
            string zaposleni = anketaLekar.selektovaniOdgovor(cs);

            string csp = cbStr.SelectedValue.ToString();
            string prostorije = anketaLekar.selektovaniOdgovor(cs);

            string komentar = comm.Text;


            using (var sr = new StreamReader("anketaBolnica.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    sw.WriteLine(line);
                }

                string datum = DateTime.Now.ToString();
                string[] d = datum.Split(' ');
                string[] dat = d[0].Split('/');
                string datum_radjenja_ankete = dat[1] + "." + dat[0] + "." + dat[2] + ".";

                sw.WriteLine(usluga + "|" + zaposleni + "|" + prostorije + "|" + komentar + "|" + datum_radjenja_ankete);

            }
            File.Delete("anketaBolnica.txt");
            File.Move(tempFile, "anketaBolnica.txt");

        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {

            AnketaStorage anketaBolnica = new AnketaStorage();

            if (anketaBolnica.pravo_na_anketu_bolnica())
            {
                PopuniAnketu();
            }
            else
            {
                MessageBox.Show("Anketa je vec popunjena.");
            }

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
