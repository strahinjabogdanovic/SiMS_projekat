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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    public partial class Lekovi_U : Window
    {
        public ObservableCollection<Lek> Lek
        {
            get;
            set;
        } 

        public Lekovi_U()
        {
            Lek = new ObservableCollection<Lek>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("lekovi.txt").ToList();

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
            if (Lek.Count > 0)
            {
                Lek.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            l.Obrisi(currentRowIndex);
        }

        private void izmeni_lek(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridLekovi.Items.IndexOf(dataGridLekovi.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridLekovi.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock t1 = dataGridLekovi.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock t2 = dataGridLekovi.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock t3 = dataGridLekovi.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock t4 = dataGridLekovi.Columns[3].GetCellContent(row) as TextBlock;
            string update = (t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/");

            LekoviFileStorage p = new LekoviFileStorage();
            p.Izmeni(update, currentRowIndex);
        }
    }
}
