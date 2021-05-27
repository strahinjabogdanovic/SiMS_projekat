using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for ZahteviZaValidaciju.xaml
    /// </summary>
    public partial class ZahteviZaValidaciju : Window
    {
        public Lek lekKojiValidiramo;
        public ZahteviZaValidaciju()
        {
            InitializeComponent();
            lekKojiValidiramo=PrikaziZahteve();
        }
        public Lek PrikaziZahteve() {
            string zahtevi;
            Lek zaValidaciju = new Lek();
            using (var sr = new StreamReader("lekovi.txt")){
                int id = 0;
                List<String> lines = new List<string>();
                lines = File.ReadAllLines("lekovi.txt").ToList();
                var lekPrazan = new Lek();

                foreach (string linee in lines)
                {
                    String[] deo = linee.Split('/');
                    var lek = new Lek();

                    lek.sifraleka = deo[0].ToString();
                    lek.nazivleka = deo[1].ToString();
                    lek.sastojci = deo[2].ToString();
                    lek.zamena = deo[3].ToString();
                    lek.validiran = deo[4].ToString();
                    if (lek.validiran != "da")
                    {
                        zahtevi = "Zahtev za validaciju leka " + lek.nazivleka;
                        t.Text = zahtevi;
                        return lek;
                    }
                    id++;
            }
                return lekPrazan;
            }
        }

        private void Zahtev_Click(object sender, MouseButtonEventArgs e)
        {
            ValidacijaLeka validacija = new ValidacijaLeka(lekKojiValidiramo);
            validacija.ShowDialog();
        }

        private void LekoviRU_Click(object sender, RoutedEventArgs e)
        {
            SpisakLekova spisakLekova = new SpisakLekova();
            spisakLekova.ShowDialog();

        }

        private void t_MouseEnter(object sender, MouseEventArgs e)
        {
            tooltip.Visibility = Visibility.Visible;
            tooltipRct.Visibility = Visibility.Visible;
        }

        private void t_MouseLeave(object sender, MouseEventArgs e)
        {
            tooltip.Visibility = Visibility.Hidden;
            tooltipRct.Visibility = Visibility.Hidden;
        }
    }
}
