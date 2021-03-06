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
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for DatumZakaz.xaml
    /// </summary>
    public partial class DatumZakaz : Window
    {
        string doktor = "";

        public DatumZakaz(String datt)
        {
            InitializeComponent();

            TerminContext tc = new TerminContext();

            tc.setStrategy(new PrioritetZakazivanjaDatum());
            List<string> slobodniTermini = tc.NadjiTermin(datt);
            foreach (string date in slobodniTermini)
            {
                ComboBoxItem item1 = new ComboBoxItem();
                item1.Content = date;
                cb1.Items.Add(item1);
            }
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {


            if (cb1.SelectedValue == null)
            {
                MessageBox.Show("Niste izabrali termin!");
            }
            else
            {
                string c = cb1.SelectedValue.ToString();
                Console.WriteLine(c);
                String[] cc = c.Split(' ');
                String d = cc[1];
                String[] dd = d.Split('/');
                String datum = dd[1] + "." + dd[0] + "." + dd[2] + ".";
                String vr = cc[2];
                String[] vrvr = vr.Split(':');
                String vreme = "";
                if (vrvr[2].Equals("PM"))
                {
                    int t = int.Parse(vrvr[0]) + 12;
                    vreme = t.ToString() + ":" + vrvr[1];
                }
                else
                {
                    vreme = vrvr[0] + ":" + vrvr[1];
                }

                TerminiServis ts = new TerminiServis();
                doktor = ts.SlobodanDoktor(datum);
                PacijentFileStorage pfs = new PacijentFileStorage();
                pfs.Kreiraj(doktor, datum, vreme);
                MessageBox.Show("Uspesno ste zakazali termin.");
                this.Close();
            }
        }
    }
}
