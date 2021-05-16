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
    public partial class PageZakazivanjeLekar : Page
    {
        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        public PageZakazivanjeLekar(string lekar)
        {
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("termini.txt").ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var pacijent = new TerminiPacijenata();

                string dr = "";

                if (lekar != null)
                {

                    if (lekar.Contains("Jova Jovic"))
                    {                       
                        dr = "Jova Jovic";

                    }
                    else if (lekar.Contains("Jovan Jovanovic"))
                    {
                        dr = "Jovan Jovanovic";
                    }
                }

                if (termin[2].Equals(dr))
                {
                    pacijent.datum = termin[0].ToString();
                    pacijent.vreme = termin[1].ToString();
                    pacijent.lekar = termin[2].ToString();
                    pacijent.soba = termin[3].ToString();
                    pacijent.id = int.Parse(termin[4].ToString());
                    pacijent.pacijenti = termin[5].ToString();

                    TerminiP.Add(pacijent);
                }
            }

            InitializeComponent();
            this.DataContext = this;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageLekar());
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            TerminiFileStorage t = new TerminiFileStorage();
            t.ZakazivanjeSekretar(dataGridTerminiLekar);
        }

        private void NazadTermini_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTerminiSekretar());
        }
    }
}
