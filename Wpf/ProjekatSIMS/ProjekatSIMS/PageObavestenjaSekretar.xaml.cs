using Package1;
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
    /// Interaction logic for PageObavestenjaSekretar.xaml
    /// </summary>
    public partial class PageObavestenjaSekretar : Page
    {
        private readonly string filePath;

        public ObservableCollection<Obavestenja> Obavesti
        {
            get;
            set;
        }

        public PageObavestenjaSekretar()
        {
            filePath = "obavestenja.txt";
            Obavesti = new ObservableCollection<Obavestenja>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var obavestenja = new Obavestenja();
                obavestenja.naziv = termin[0].ToString();
                obavestenja.sadrzaj = termin[1].ToString();
                obavestenja.datum = termin[2].ToString();
                obavestenja.uloga = termin[3].ToString();

                Obavesti.Add(obavestenja);

            }


            InitializeComponent();
            this.DataContext = this;

            StreamReader sr = new StreamReader("obavestenja.txt");
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


        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjaFileStorage n = new ObavestenjaFileStorage();
            
            int currentRowIndex = dataGridObavestenja.Items.IndexOf(dataGridObavestenja.SelectedItem);

            if (currentRowIndex != -1)
            {
                Obavestenja k = Obavesti.ElementAt(currentRowIndex);
                if (Obavesti.Count > 0)
                {
                    Obavesti.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                n.Obrisi(k);
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjaFileStorage n = new ObavestenjaFileStorage();
            n.Update(dataGridObavestenja);
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageKreirajObavestenje());
        }
    }
}
