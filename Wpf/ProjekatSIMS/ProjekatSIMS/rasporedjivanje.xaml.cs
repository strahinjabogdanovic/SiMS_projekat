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

namespace ProjekatSIMS
{
    public partial class rasporedjivanje : Window
    {
        int izabrani_red = 0;
        ProstorijeFileStorage p = new ProstorijeFileStorage();
        public rasporedjivanje()
        {
            InitializeComponent();

            izabrani_red = p.red_prostorije("redzarasp.txt");

            List<string> imena_prostorija = p.prostorije_u_cb(izabrani_red);
            foreach (string imena in imena_prostorija)
            {
                ComboBoxItem newitem = new ComboBoxItem();
                newitem.Content = imena;
                cb1.Items.Add(newitem);
            }
        }

        private int vreme_ren()
        {
            string datep = myDatePicker.ToString();
            string[] datump = datep.Split(' ');
            string[] datumpr = datump[0].Split('-');
            string danp = datumpr[0];
            int datum_premestanja = int.Parse(danp);

            DateTime danas = DateTime.Now;
            string[] datumd = danas.ToString().Split(' ');
            string[] dand = datumd[0].Split('-');
            string dan = dand[0];
            int datum_danas = int.Parse(dan);

            int premestanje = datum_premestanja - datum_danas;
            return premestanje;
        }

        private void potvrdi_click(object sender, RoutedEventArgs e)
        {
            String naziv_u = t2.Text;
            String kolicina_u = t1.Text;
            int intkol = int.Parse(kolicina_u);

            int premestanje = vreme_ren();

            string tempFile = System.IO.Path.GetTempFileName();
            using (var sr = new StreamReader("prostorije.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] informacije = line.Split('/');
                    string naziv = informacije[0];
                    string oznaka = informacije[1];
                    string namena = informacije[2];
                    string ren = informacije[5];

                    if (idp == izabrani_red)
                    {
                        string oprema_kol = "";
                        List<string> prostorije = p.prostorija_iz(informacije[3], informacije[4], naziv_u, intkol);
                        foreach(string o_k in prostorije) {
                            oprema_kol = o_k;
                        }
                        sw.WriteLine(naziv + "/" + oznaka + "/" + namena + "/" + oprema_kol + "/" + ren);
                    }
                    else if (cb1.SelectedValue.ToString().Contains(informacije[0]))
                    {
                        string oprema_kol = "";
                        
                        List<string> prostorije = p.prostorija_u(informacije[3], informacije[4], naziv_u, intkol);
                        foreach (string o_k in prostorije)
                        {
                            oprema_kol = o_k;
                        }
                        sw.WriteLine(naziv + "/" + oznaka + "/" + namena + "/" + oprema_kol + "/" + ren);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    idp++;
                }
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            MessageBox.Show("Oprema ce biti premestana za " + premestanje + " minuta");
            while (true)
            {
                if (stopwatch.ElapsedMilliseconds >= premestanje* 10000)
                {
                    break;
                }
            }

            File.Delete("prostorije.txt");
            File.Move(tempFile, "prostorije.txt");
            Close();
        }
    }
}