using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ProjekatSIMS.Lekar.ViewModel;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for ZakazivanjeKodSpecijaliste.xaml
    /// </summary>
    public partial class ZakazivanjeKodSpecijaliste : Page
    {
        private ZakazivanjeKodSpecijaliste page;
        public string Jmbg { get; set; }
        public ZakazivanjeKodSpecijaliste(string jmbg, string specijalnost)
        {
            InitializeComponent();
            page = this;
            tBlock1.Text = specijalnost;
            Jmbg = jmbg;
            Zakazivanje(jmbg, specijalnost);
            vrsta.Items.Add("Pregled");
            vrsta.Items.Add("Operacija");



        }

        private void Zakazivanje(string jmbg, string specijalnost)
        {
            LekarFileStorage lekari = new LekarFileStorage();
            List<string> lekaripospec = lekari.dobaviLekarePoSpecijalizaciji(specijalnost);
            PopuniLekare(lekaripospec);
        }
        public void PopuniLekare(List<string> lista)
        {
            foreach (string lekar in lista)
            {
                string vrednost = lekar;
                combo.Items.Add(lekar);
            }

        }

        private void PrikaziTermine(string lekar)
        {
            TerminiFileStorage tfs = new TerminiFileStorage();
            List<String> listaTermina = tfs.DobaviTerminePoLekaru(lekar);
            string prosliTermin = listaTermina[0];
            foreach (string termin in listaTermina)
            {
                string[] deoDatuma = termin.Split(' ');
                int pogresanDatum = DateTime.Now.CompareTo(Convert.ToDateTime(deoDatuma[0]));
                bool bio = false;
                if (pogresanDatum <= 0)
                {
                    foreach (string vecBioTermin in slobcombo.Items)
                    {
                        if (termin == vecBioTermin)
                        {
                            bio = true;
                        }
                    }

                    if (bio == false)
                    {
                        slobcombo.Items.Add(termin);
                        prosliTermin = termin;
                    }
                }

            }
        }


        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            page.NavigationService.Navigate(new UputZaSpecijalistu(Jmbg));
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrikaziTermine(combo.SelectedItem.ToString());
            combo.Text = combo.SelectedItem.ToString();
        }

        private void zakazi_Click(object sender, RoutedEventArgs e)
        {
            string[] datumTermina = FormatirajDatum(slobcombo.Text);
            PacijentFileStorage pfs = new PacijentFileStorage();
            pfs.Kreiraj(combo.SelectedItem.ToString(), datumTermina[0], datumTermina[1], Jmbg, vrsta.SelectedItem.ToString());
        }

        private string[] FormatirajDatum(string datumf)
        {
            String[] cc = datumf.Split(' ');
            String d = cc[0];
            String[] dd = d.Split('/');
            String datum = dd[1] + "." + dd[0] + "." + dd[2] + ".";
            String vr = cc[1];
            String[] vrvr = vr.Split(':');
            String vreme = "";
            if (cc[2].Equals("PM"))
            {
                int t = int.Parse(vrvr[0]) + 12;
                vreme = t.ToString() + ":" + vrvr[1];
            }
            else
            {
                vreme = vrvr[0] + ":" + vrvr[1];
            }
            String[] tajming = { datum, vreme };
            return tajming;

        }
    }
}
