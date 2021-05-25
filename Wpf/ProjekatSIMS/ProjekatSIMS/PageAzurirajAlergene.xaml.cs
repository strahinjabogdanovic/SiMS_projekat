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
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Package1.Kontroler;

namespace ProjekatSIMS
{
    public partial class PageAzurirajAlergene : Page
    {
        int trenutniRed = 0;
        public PageAzurirajAlergene(int currentRowIndex)
        {
            int redovi = 0;
            string karton = "";
            InitializeComponent();
            trenutniRed = currentRowIndex;
            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();
            List<string> sviMedKartoni = npk.procitaniMedKartoni();
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
                NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();
                List<string> sviKartoni = npk.procitaniMedKartoni();
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

            this.NavigationService.Navigate(new PageMedKarton(trenutniRed));
        }
    }
}
