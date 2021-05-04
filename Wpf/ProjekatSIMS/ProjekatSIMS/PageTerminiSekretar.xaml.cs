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
    /// Interaction logic for PageTerminiSekretar.xaml
    /// </summary>
    public partial class PageTerminiSekretar : Page
    {
        private readonly string filePath;       

        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        
        public PageTerminiSekretar()
        {
            filePath = "termini.txt";
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var pacijent = new TerminiPacijenata();
                pacijent.datum = termin[0].ToString();
                pacijent.vreme = termin[1].ToString();
                pacijent.lekar = termin[2].ToString();
                pacijent.soba = termin[3].ToString();
                pacijent.id = int.Parse(termin[4].ToString());
                pacijent.pacijenti = termin[5].ToString();

                TerminiP.Add(pacijent);

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
            this.NavigationService.Navigate(new PageSekretar());
        }

        private void ZakazivanjeT_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PagePrioritetZakazivanja());
        }

        private void OtkazivanjeT_Click(object sender, RoutedEventArgs e)
        {
            TerminiFileStorage t = new TerminiFileStorage();
            int currentRowIndex = dataGridTerminiSekretar.Items.IndexOf(dataGridTerminiSekretar.SelectedItem);

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

                t.OtkazivanjeSekretar(k);
            }

            this.NavigationService.Navigate(new PageTerminiSekretar());

        }

        private void PromenaT_Click(object sender, RoutedEventArgs e)
        {
            TerminiFileStorage t = new TerminiFileStorage();
            t.UpdateSekretar(dataGridTerminiSekretar);
        }
    }
}
