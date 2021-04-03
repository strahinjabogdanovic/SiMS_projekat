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
    /// Interaction logic for GuestNalozi.xaml
    /// </summary>
    public partial class GuestNalozi : Window
    {
        private readonly string filePath;
        public ObservableCollection<GuestNalog> Guest
        {
            get;
            set;
        }

        public GuestNalozi()
        {
            
            filePath = "naloziGuest.txt";
            Guest = new ObservableCollection<GuestNalog>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var guest = new GuestNalog();
                guest.ime = termin[0].ToString();
                guest.prezime = termin[1].ToString();
                guest.jmbg = long.Parse(termin[2].ToString());

 
               

                Guest.Add(guest);


            }

            

            
            InitializeComponent();

            this.DataContext = this;

            StreamReader sr = new StreamReader("naloziGuest.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();

        }

        private void KreirajGuestNalog_Click(object sender, RoutedEventArgs e)
        {
            KreirajGuestNalog kr = new KreirajGuestNalog();
            kr.ShowDialog();
        }

        private void ObrisiGuestNalog_Click(object sender, RoutedEventArgs e)
        {
            GuestFileStorage g = new GuestFileStorage();
            int currentRowIndex = dataGridGuestNalozi.Items.IndexOf(dataGridGuestNalozi.SelectedItem);
            GuestNalog k = Guest.ElementAt(currentRowIndex);
            if (Guest.Count > 0)
            {
                Guest.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            g.Obrisi(k);

        }
    }
}
