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

namespace ProjekatSIMS
{
    public partial class PageMedKarton : Page
    {
        int trenutniRed = 0;
        public PageMedKarton(int currentRowIndex)
        {
            int red = 0;
            int redovi = 0;
            trenutniRed = currentRowIndex;
            string nalog = "";
            string karton = "";
            InitializeComponent();

            NaloziPacijenataFileStorage p = new NaloziPacijenataFileStorage();

            List<string> sviNalozi = p.procitaniNalozi();
            foreach (string sviN in sviNalozi)
            {
                if (red == currentRowIndex)
                {
                    nalog = sviN;
                }
                red++;
            }
            string[] informacije = nalog.Split('/');
            t.Text = informacije[0];
            t1.Text = informacije[1];
            t2.Text = informacije[2];
            t3.Text = informacije[3];
            t4.Text = informacije[4];
            t5.Text = informacije[5];
            t6.Text = informacije[6];
            t7.Text = informacije[7];

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
            t8.Text = infoMedKarton[1];
        }
     

        private void Azuriraj_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageAzurirajAlergene(trenutniRed));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }
    }
}
