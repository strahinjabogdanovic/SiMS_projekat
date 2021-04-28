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
    /// Interaction logic for PageMedKarton.xaml
    /// </summary>
    public partial class PageMedKarton : Page
    {
        public PageMedKarton()
        {
            int currentRowIndex = 0;
            InitializeComponent();

            using (var sr = new StreamReader("redovi.txt"))
            {

                String line = "";

                line = sr.ReadLine();
                currentRowIndex = int.Parse(line);
            }

            String ime = "";
            String prezime = "";
            String jmbg = "";
            String pol = "";
            String datumr = "";
            String mail = "";
            String broj = "";
            String adresa = "";
            String idd = "";

            using (var sr = new StreamReader("podaci.txt"))
            {

                string line;
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (idp == currentRowIndex)
                    {
                        

                        String[] termin = line.Split('/');
                         ime = termin[0];
                         prezime = termin[1];
                         jmbg = termin[2];
                         pol = termin[3];
                         datumr = termin[4];
                         mail = termin[5];
                         broj = termin[6];
                         adresa = termin[7];
                         idd = termin[8];
  

                    }
                    idp++;

                }     

            }

            using (var sars = new StreamReader("medKarton.txt"))
            {

                string liness;
                int idps = 0;
                while ((liness = sars.ReadLine()) != null)
                {
                    //if (idps == currentRowIndex)
                    //{
                        

                        String[] termini = liness.Split('/');
                        String idK = termini[0];
                        String alerg = termini[1];


                    if (idd != "")
                    {
                        if (int.Parse(idK) == int.Parse(idd))
                        {

                            t.Text = ime;
                            t1.Text = prezime;
                            t2.Text = jmbg;
                            t3.Text = pol;
                            t4.Text = datumr;
                            t5.Text = mail;
                            t6.Text = broj;
                            t7.Text = adresa;
                            t8.Text = alerg;
                        }
                    }
                    //}
                    idps++;

                }
            }
        }
     

        private void Azuriraj_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageAzurirajAlergene());
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }
    }
}
