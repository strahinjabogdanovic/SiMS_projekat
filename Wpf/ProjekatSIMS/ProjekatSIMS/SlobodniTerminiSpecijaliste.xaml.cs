using Package1;
using ProjekatSIMS.Package1;
using System;
using System.Collections.Generic;
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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for SlobodniTerminiSpecijaliste.xaml
    /// </summary>
    public partial class SlobodniTerminiSpecijaliste : Window
    {
        string Jmbg { get; set; }
        string LekarImePr { get; set; }
        public SlobodniTerminiSpecijaliste(string jmbgPacijenta,string specijalizacija)
        {
            InitializeComponent();
            tBlock1.Text = specijalizacija;
            Jmbg = jmbgPacijenta;
            LekarFileStorage lekari = new LekarFileStorage();
            List<string> lekaripospec = lekari.dobaviLekarePoSpecijalizaciji(specijalizacija);
            PopuniLekare(lekaripospec);

        }
        public void PopuniLekare(List<string> lista)
        {
            foreach (string lekar in lista)
            {
                ComboBoxItem dodatLekar = new ComboBoxItem();
                dodatLekar.Content = lekar;
                combo.Items.Add(dodatLekar);
            }
        }
        public void PopuniSlobodneTermine(string lekar)
        {
            List<string> terminiSlobodni = new List<string>();
            TerminiFileStorage terminF = new TerminiFileStorage();
            terminiSlobodni=terminF.DobaviTerminePoLekaru(lekar);
            foreach(string ter in terminiSlobodni)
            {
                ComboBoxItem kombo = new ComboBoxItem();
                kombo.Content = ter;
                slobcombo.Items.Add(kombo);
            }

        }

        private void combo_DropDownClosed(object sender, EventArgs e)
        {
            LekarImePr = combo.SelectedItem.ToString();
            PopuniSlobodneTermine(LekarImePr);
            Labela.Visibility = Visibility.Visible;
            slobcombo.Visibility = Visibility.Visible;
            zakazi.Visibility = Visibility.Visible;
        }

        private void zakazi_Click(object sender, RoutedEventArgs e)
        {
            string[] datumTermina=FormatirajDatum(slobcombo.Text);
            PacijentFileStorage pfs = new PacijentFileStorage();
            pfs.Kreiraj(LekarImePr, datumTermina[0], datumTermina[1],Jmbg);
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
