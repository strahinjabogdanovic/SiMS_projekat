using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageAzurirajAlergene : Page
    {
        private PageAzurirajAlergeneVM viewModel;
        //int trenutniRed = 0;
        public PageAzurirajAlergene(int currentRowIndex)
        {
            //int redovi = 0;
            //string karton = "";
            InitializeComponent();
            this.viewModel = new PageAzurirajAlergeneVM(this, currentRowIndex);
            this.DataContext = this.viewModel;
            /*trenutniRed = currentRowIndex;
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
            textBox.Text = infoMedKarton[1];*/
        }

        /*
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
        }*/
    }
}
