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
    public partial class Lekovi_U : Window
    {
        private readonly string filePath;

        public ObservableCollection<Lek> Lek
        {
            get;
            set;
        } 

        public Lekovi_U()
        {
            filePath = "lekovi.txt";
            Lek = new ObservableCollection<Lek>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var lekovi = new Lek();
                lekovi.sifraleka = termin[0].ToString();
                lekovi.nazivleka = termin[1].ToString();
                lekovi.sastojci = termin[2].ToString();
                lekovi.zamena = termin[3].ToString();


                Lek.Add(lekovi);
            }

            InitializeComponent();

            this.DataContext = this;

            StreamReader sr = new StreamReader("lekovi.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }

        private void dodaj_lek(object sender, RoutedEventArgs e)
        {
            DodavanjeLeka dl = new DodavanjeLeka();
            dl.ShowDialog();
        }

        private void obrisi_lek(object sender, RoutedEventArgs e)
        {
            LekoviFileStorage l = new LekoviFileStorage();
            int currentRowIndex = dataGridLekovi.Items.IndexOf(dataGridLekovi.SelectedItem);
            Lek k = Lek.ElementAt(currentRowIndex);
            if (Lek.Count > 0)
            {
                Lek.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            l.Obrisi(k);
        }

        private void izmeni_lek(object sender, RoutedEventArgs e)
        {
            LekoviFileStorage p = new LekoviFileStorage();
            p.Izmeni(dataGridLekovi);
        }
    }
}
