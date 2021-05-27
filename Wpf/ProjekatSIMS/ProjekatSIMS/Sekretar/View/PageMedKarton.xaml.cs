using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageMedKarton : Page
    {
        //int trenutniRed = 0;
        private PageMedKartonVM viewModel;

        public PageMedKarton(int currentRowIndex)
        {
            //int red = 0;
            //int redovi = 0;
            //trenutniRed = currentRowIndex;
            //string nalog = "";
            //string karton = "";
            InitializeComponent();
            this.viewModel = new PageMedKartonVM(this, currentRowIndex);
            this.DataContext = this.viewModel;
            /*
            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();

            List<string> sviNalozi = npk.procitaniNalozi();
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
            t8.Text = infoMedKarton[1];*/
        }
     
        /*
        private void Azuriraj_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageAzurirajAlergene(trenutniRed));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }*/
    }
}
