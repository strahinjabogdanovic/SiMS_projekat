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
    public partial class PageGuestNalozi : Page
    {
        public ObservableCollection<GuestNalog> Guest
        {
            get;
            set;
        }

        public PageGuestNalozi()
        {
            Guest = new ObservableCollection<GuestNalog>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("naloziGuest.txt").ToList();


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
        }

        private void KreirajGuestNalog_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageKreirajGuestNalog());
        }

        private void ObrisiGuestNalog_Click(object sender, RoutedEventArgs e)
        {
            GuestFileStorage g = new GuestFileStorage();
            int currentRowIndex = dataGridGuestNalozi.Items.IndexOf(dataGridGuestNalozi.SelectedItem);
            if (currentRowIndex != -1)
            {
                if (Guest.Count > 0)
                {
                    Guest.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                g.Obrisi(currentRowIndex);
            }

        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }
    }
}
