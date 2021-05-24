using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using Package1;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    public partial class rasporedjivanje : Window
    {
        int izabrani_red = 0;
        ProstorijeFileStorage p = new ProstorijeFileStorage();
        OpremaFileStorage o = new OpremaFileStorage();
        public rasporedjivanje(int currentRowIndex)
        {
            InitializeComponent();

            izabrani_red = currentRowIndex;

            List<string> imena_prostorija = p.prostorije_u_cb(izabrani_red);
            foreach (string imena in imena_prostorija)
            {
                ComboBoxItem newitem = new ComboBoxItem();
                newitem.Content = imena;
                cb1.Items.Add(newitem);
            }
        }

        private int danasnjiDatum()
        {
            DateTime danas = DateTime.Now;
            string[] datumd = danas.ToString().Split(' ');
            string[] dand = datumd[0].Split('-');
            string dan = dand[0];
            int datum_danas = int.Parse(dan);

            return datum_danas;
        }

        private int izabraniDatum()
        {
            string datep = myDatePicker.ToString();
            string[] datump = datep.Split(' ');
            string[] datumpr = datump[0].Split('-');
            string danp = datumpr[0];
            int datum_premestanja = int.Parse(danp);

            return datum_premestanja;
        }

        private int vreme_ren() 
        { 
            return izabraniDatum() - danasnjiDatum();
        }

        public void stoperica()
        {
            int premestanje = vreme_ren();
            Stopwatch stopwatch = Stopwatch.StartNew();
            MessageBox.Show("Oprema ce biti premestana za " + premestanje + " minuta");
            while (true)
            {
                if (stopwatch.ElapsedMilliseconds >= premestanje * 10000)
                {
                    break;
                }
            }
        }

        private void potvrdi_click(object sender, RoutedEventArgs e)
        {
            String naziv_u = t2.Text;
            String kolicina_u = t1.Text;

            Close();
            p.prostorija_iz(naziv_u, kolicina_u, izabrani_red);
            stoperica();
            p.prostorija_u(cb1.SelectedValue.ToString(),naziv_u, kolicina_u);

        }
    }
}