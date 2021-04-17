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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for UpravnikPocetnaStranica.xaml
    /// </summary>
    public partial class UpravnikPocetnaStranica : Window
    {
        private readonly string filePath;

        public ObservableCollection<Prostorije> Prostorije
        {
            get;
            set;
        }

        public UpravnikPocetnaStranica()
        {
            filePath = "prostorije.txt";
            Prostorije = new ObservableCollection<Prostorije>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var prostorije = new Prostorije();
                prostorije.ime = termin[0].ToString();
                prostorije.oznaka = termin[1].ToString();
                prostorije.namena = termin[2].ToString();
                prostorije.oprema = termin[3].ToString();


                Prostorije.Add(prostorije);


            }

            InitializeComponent();

            this.DataContext = this;

            StreamReader sr = new StreamReader("prostorije.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();


        }

        private void KreirajProstoriju_Click(object sender, RoutedEventArgs e)
        {
            KreirajProstoriju kp = new KreirajProstoriju();
            kp.ShowDialog();
        }

        private void ObrisiProstoriju_Click(object sender, RoutedEventArgs e)
        {
            ProstorijeFileStorage p = new ProstorijeFileStorage();
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);
            Prostorije k = Prostorije.ElementAt(currentRowIndex);
            if (Prostorije.Count > 0)
            {
                Prostorije.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            p.Obrisi(k);

        }

        private void IzmeniProstoriju_Click(object sender, RoutedEventArgs e)
        {
            ProstorijeFileStorage p = new ProstorijeFileStorage();
            p.Update(dataGridProstorije);

        }

        private void PrikaziSveInfo_Click(object sender, RoutedEventArgs e)
        {
            ProstorijeFileStorage p = new ProstorijeFileStorage();
            p.Prikazi(dataGridProstorije);
            
        }

        private void oprema_click(object sender, RoutedEventArgs e)
        {
            ProstorijeFileStorage p = new ProstorijeFileStorage();
            p.stvari(dataGridProstorije);
        }

        private void rasporedjivanje_click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);

            using (var sw = new StreamWriter("redzarasp.txt"))
            {
                sw.WriteLine(currentRowIndex);
            }
            rasporedjivanje r = new rasporedjivanje();
            r.ShowDialog();
        }
    }
}
