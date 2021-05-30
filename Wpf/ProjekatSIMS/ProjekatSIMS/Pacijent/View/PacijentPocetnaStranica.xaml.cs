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
using System.Windows.Shapes;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PacijentPocetnaStranica.xaml
    /// </summary>
    public partial class PacijentPocetnaStranica : Window
    {
        private readonly string filePath;

        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }


        public PacijentPocetnaStranica()
        {
            filePath = "termini.txt";
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                if (termin[5].Equals("Ana Markovic")) {
                    var pacijent = new TerminiPacijenata();
                    pacijent.datum = termin[0].ToString();
                    pacijent.vreme = termin[1].ToString();
                    pacijent.lekar = termin[2].ToString();
                    pacijent.soba = termin[3].ToString();
                    pacijent.id = int.Parse(termin[4].ToString());
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

        private void KreirajTermin_Click(object sender, RoutedEventArgs e)
        {
            // KreirajTerminPacijenta k = new KreirajTerminPacijenta();
            // k.ShowDialog();
            antiTrol anti = new antiTrol();
            if (anti.maksimalan_broj_termina())
            {
                BiranjePrioritetaZakazivanja bp = new BiranjePrioritetaZakazivanja();
                bp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Prekoracili ste broj termina koje mozete da zakazete.");
            }
        }

        private void ObrisiTermin_Click(object sender, RoutedEventArgs e)
        {
            PacijentFileStorage p = new PacijentFileStorage();
            int currentRowIndex = dataGridPacijenti.Items.IndexOf(dataGridPacijenti.SelectedItem);
            TerminiPacijenata k = TerminiP.ElementAt(currentRowIndex);
            if (TerminiP.Count > 0)
            {
                TerminiP.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            p.Obrisi(k);
           
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

            PacijentFileStorage p = new PacijentFileStorage();
            p.Update(dataGridPacijenti);

            pomeranjeTermina ps = new pomeranjeTermina();
            ps.ShowDialog();

          
            
        }

    }
}
