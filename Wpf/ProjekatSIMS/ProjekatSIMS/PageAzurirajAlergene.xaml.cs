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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PageAzurirajAlergene.xaml
    /// </summary>
    public partial class PageAzurirajAlergene : Page
    {
        int trenutniRed = 0;
        public PageAzurirajAlergene(int currentRowIndex)
        {
            int redovi = 0;
            string karton = "";
            InitializeComponent();
            trenutniRed = currentRowIndex;
            NaloziPacijenataFileStorage p = new NaloziPacijenataFileStorage();
            List<string> sviMedKartoni = p.procitaniMedKartoni();
            foreach (string svi in sviMedKartoni)
            {
                if (redovi == currentRowIndex)
                {
                    karton = svi;
                }
                redovi++;
            }
            string[] infoMedKarton = karton.Split('/');
            textBox.Text = infoMedKarton[1];
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageMedKarton(trenutniRed));
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            int idp = 0;
            string kartoni = "";

            try
            {
                NaloziPacijenataFileStorage p = new NaloziPacijenataFileStorage();
                List<string> sviKartoni = p.procitaniMedKartoni();
                foreach (string sviK in sviKartoni)
                {
                    kartoni = sviK;
                    string[] informacije = kartoni.Split('/');
                    if (idp == trenutniRed)
                    {
                        sviKartoni.RemoveAt(trenutniRed);
                        sviKartoni.Insert(trenutniRed, informacije[0] + "/" + textBox.Text);
                        File.WriteAllLines(@"medKarton.txt", sviKartoni);
                    }
                    idp++;
                }
            }
            catch (Exception exp)
            { }


            /*
            int currentRowIndex = 0;
 
            using (var sr = new StreamReader("redovi.txt"))
            {

                String line = "";

                line = sr.ReadLine();
                currentRowIndex = int.Parse(line);
            }

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("medKarton.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                int idx = 0;

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //id++;
                    if (id == currentRowIndex)
                    {

                        String[] termin = line.Split('/');


                        sw.WriteLine(termin[0] + "/" + textBox.Text);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("medKarton.txt");
            File.Move(tempFile, "medKarton.txt");*/

            this.NavigationService.Navigate(new PageMedKarton(trenutniRed));
        }
    }
}
