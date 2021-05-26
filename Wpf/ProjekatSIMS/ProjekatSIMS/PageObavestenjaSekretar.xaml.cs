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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.View;

namespace ProjekatSIMS
{
    public partial class PageObavestenjaSekretar : Page
    {
        public ObservableCollection<Obavestenja> Obavesti
        {
            get;
            set;
        }

        public PageObavestenjaSekretar()
        {
            Obavesti = new ObservableCollection<Obavestenja>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("obavestenja.txt").ToList();


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

        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }


        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjaKontroler ok = new ObavestenjaKontroler();          
            int currentRowIndex = dataGridObavestenja.Items.IndexOf(dataGridObavestenja.SelectedItem);
            if (currentRowIndex != -1)
            {
                if (Obavesti.Count > 0)
                {
                    Obavesti.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                ok.Obrisi(currentRowIndex);
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridObavestenja.Items.IndexOf(dataGridObavestenja.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridObavestenja.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock uloga = dataGridObavestenja.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock naziv = dataGridObavestenja.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock sadraj = dataGridObavestenja.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock datum = dataGridObavestenja.Columns[3].GetCellContent(row) as TextBlock;
            string update = (naziv.Text + "/" + sadraj.Text + "/" + datum.Text + "/" + uloga.Text);

            ObavestenjaKontroler ok = new ObavestenjaKontroler();
            ok.Update(update, currentRowIndex);
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageKreirajObavestenje());
        }
    }
}
