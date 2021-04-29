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
    /// Interaction logic for PageZakazivanjeDatum.xaml
    /// </summary>
    public partial class PageZakazivanjeDatum : Page
    {
        private readonly string filePath;

        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        public PageZakazivanjeDatum(string tb)
        {
            filePath = "termini.txt";
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var pacijent = new TerminiPacijenata();

                if (termin[0].Equals(tb))
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
            this.NavigationService.Navigate(new PageDatum());
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            PacijentFileStorage p = new PacijentFileStorage();
            p.ZakazivanjeSekretar(dataGridTerminiDatum);
        }

        private void NazadTermini_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTerminiSekretar());
        }
    }
}
