using Package1;
using ProjekatSIMS.Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PageHitnoZakazTermin.xaml
    /// </summary>
    public partial class PageHitnoZakazTermin : Page
    {
        private readonly string filePath;

        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        String oblastL = "";
        public PageHitnoZakazTermin(string oblastLekara)
        {
            
            if (oblastLekara != null)
            {
                if (oblastLekara.Contains("Opsta praksa"))
                {
                    oblastL = "Opsta praksa";

                }
                else if (oblastLekara.Contains("Hirurgija"))
                {
                    oblastL = "Hirurgija";
                }
            }



            DateTime danas = DateTime.Now;
            String[] terminin = danas.ToString().Split(' ');
            String[] termin1 = terminin[0].Split('/');
            //string datum = termin1[1] + "." + termin1[0] + "." + termin1[2] + ".";
            string dan = "";
            string mesec = "";
            if (int.Parse(termin1[1]) < 10)
            {
                dan = "0" + termin1[1];
            }
            else
            {
                dan = termin1[1];
            }
            if (int.Parse(termin1[0]) < 10)
            {
                mesec = "0" + termin1[0];
            }
            else
            {
                mesec = termin1[0];
            }
            string datum = dan + "." + mesec + "." + termin1[2] + ".";

            String[] termin2 = terminin[1].Split(':');
            string vreme = "";
            int v;
            if (terminin[2].Equals("PM") && int.Parse(termin2[0]) != 12)
            {
                v = int.Parse(termin2[0]) + 12;
                vreme = v.ToString() + ":" + termin2[1];
            }else
            {
                v = int.Parse(termin2[0]);
                vreme = v.ToString() + ":" + termin2[1];
            }
            


            String ime = "";
            String oblast = "";
            using (var srr = new StreamReader("doktoriSpec.txt"))
            {
                string lin;

                while ((lin = srr.ReadLine()) != null)
                {
                    String[] termin = lin.Split('/');
                    ime = termin[0];
                    oblast = termin[1];

                    if (oblast.Equals(oblastL))
                    {
                        filePath = "termini.txt";
                        TerminiP = new ObservableCollection<TerminiPacijenata>();
                        List<String> lines = new List<string>();
                        lines = File.ReadAllLines(filePath).ToList();


                        foreach (string linee in lines)
                        {
                            String[] termini = linee.Split('/');
                            var pacijent = new TerminiPacijenata();

                            //Console.WriteLine(datum);
                            //Console.WriteLine(vreme);

                            if (termini[2].Equals(ime) && termini[0].Equals(datum))
                            {
                                String[] sat = termini[1].Split(':');
                                string sati = sat[0] + sat[1];
                                string sadSati = v.ToString() + termin2[1];

                                //termini[5] == ""
                                                            
                                if (int.Parse(sati) >= int.Parse(sadSati))  
                                {
                                    pacijent.datum = termini[0].ToString();
                                    pacijent.vreme = termini[1].ToString();
                                    pacijent.lekar = termini[2].ToString();
                                    pacijent.soba = termini[3].ToString();
                                    pacijent.id = int.Parse(termini[4].ToString());
                                    pacijent.pacijenti = termini[5].ToString();

                                    TerminiP.Add(pacijent);

                                }  
                            }
                        }
                    }
                }

            }

            InitializeComponent();
            this.DataContext = this;

            StreamReader sr = new StreamReader("termini.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageHitnoZakazivanje());
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            TerminiFileStorage t = new TerminiFileStorage();
            t.ZakazivanjeSekretar(dataGridHitnoZakazivanje);
        }

        private void PomeranjeTermina_Click(object sender, RoutedEventArgs e)
        {
            TerminiFileStorage t = new TerminiFileStorage();
            int currentRowIndex = dataGridHitnoZakazivanje.Items.IndexOf(dataGridHitnoZakazivanje.SelectedItem);

            if (currentRowIndex != -1)
            {
                TerminiPacijenata k = TerminiP.ElementAt(currentRowIndex);
                if (TerminiP.Count > 0)
                {
                    TerminiP.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                t.PomeranjeTerminaSekretar(k);
            }

            this.NavigationService.Navigate(new PageHitnoZakazTermin(oblastL));
        }
    }
}
