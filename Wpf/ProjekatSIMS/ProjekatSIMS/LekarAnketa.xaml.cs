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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for LekarAnketa.xaml
    /// </summary>
    public partial class LekarAnketa : Window
    {

        public LekarAnketa()
        {
            InitializeComponent();

            AnketaStorage anketaLekar = new AnketaStorage();
            List<String> doktori = anketaLekar.Doktori();
            int i = 0;

            foreach (String s in doktori)
            {
                ComboBoxItem newitem = new ComboBoxItem();
                newitem.Content = doktori[i];
                cb.Items.Add(newitem);
                ++i;
            }

        }

        private void PopuniAnketu(String s)
        {
            string tempFile = System.IO.Path.GetTempFileName();
            AnketaStorage anketaLekar = new AnketaStorage();

            string c = cbLjub.SelectedValue.ToString();
            string ljubaznost = anketaLekar.selektovaniOdgovor(c);

            string cs = cbStr.SelectedValue.ToString();
            string strucnost = anketaLekar.selektovaniOdgovor(cs);

            string komentar = comm.Text;


            using (var sr = new StreamReader("anketaLekar.txt"))
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

                sw.WriteLine(s + "|" + ljubaznost + "|" + strucnost + "|" + komentar + "|" + datum_radjenja_ankete);

            }
            File.Delete("anketaLekar.txt");
            File.Move(tempFile, "anketaLekar.txt");

        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string c = cb.SelectedValue.ToString();
            string[] doktor = c.Split(' ');
            string lekar = doktor[1] + " " + doktor[2];

            AnketaStorage anketaLekar = new AnketaStorage();
            if (anketaLekar.pravo_na_anketu_lekar(lekar))
            {
                PopuniAnketu(lekar);
            }
            else
                MessageBox.Show("Vec ste popunili anketu u proslih 40 dana.");

            Close();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
