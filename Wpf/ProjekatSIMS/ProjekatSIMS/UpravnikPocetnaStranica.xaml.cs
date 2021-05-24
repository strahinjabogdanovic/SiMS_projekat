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
    public partial class UpravnikPocetnaStranica : Window
    {
        public ObservableCollection<Prostorije> Prostorije
        {
            get;
            set;
        }

        public UpravnikPocetnaStranica()
        {
            Prostorije = new ObservableCollection<Prostorije>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("prostorije.txt").ToList();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var prostorije = new Prostorije();
                prostorije.ime = termin[0].ToString();
                prostorije.oznaka = termin[1].ToString();
                prostorije.namena = termin[2].ToString();
                prostorije.oprema = termin[3].ToString();
                prostorije.renoviranje = termin[5].ToString();

                Prostorije.Add(prostorije);
            }

            InitializeComponent();

            this.DataContext = this;

            /*LekoviFileStorage lfs = new LekoviFileStorage();
            bool imaPogresnihLekova = lfs.proveriPogresneLekove();
            if (imaPogresnihLekova == true)
            {
                PopUpPogresnoUnesenLek pu = new PopUpPogresnoUnesenLek();
                pu.ShowDialog();
            }*/
        }

        private void KreirajProstoriju_Click(object sender, RoutedEventArgs e)
        {
            Close();
            KreirajProstoriju kp = new KreirajProstoriju();
            kp.ShowDialog();
            
        }

        private void ObrisiProstoriju_Click(object sender, RoutedEventArgs e)
        {
            ProstorijeFileStorage p = new ProstorijeFileStorage();
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);
            if (Prostorije.Count > 0)
            {
                Prostorije.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            p.Obrisi(currentRowIndex);

        }

        private void IzmeniProstoriju_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridProstorije.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock t1 = dataGridProstorije.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock t2 = dataGridProstorije.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock t3 = dataGridProstorije.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock t4 = dataGridProstorije.Columns[3].GetCellContent(row) as TextBlock;
            string update = (t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/");

            ProstorijeFileStorage p = new ProstorijeFileStorage();
            p.Update(update, currentRowIndex);
        }

        private void PrikaziSveInfo_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);
            ProstorijeFileStorage p = new ProstorijeFileStorage();
            p.Prikazi(currentRowIndex);
        }

        private void oprema_click(object sender, RoutedEventArgs e)
        { 
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);
            ProstorijeFileStorage p = new ProstorijeFileStorage();
            p.stvari(currentRowIndex);
        }

        private void rasporedjivanje_click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);
            rasporedjivanje r = new rasporedjivanje(currentRowIndex);
            r.ShowDialog();
        }

        private void lekovi_click(object sender, RoutedEventArgs e)
        {
            Lekovi_U lu = new Lekovi_U();
            lu.ShowDialog();
        }

        private void pretrazi(object sender, RoutedEventArgs e)
        {
            String o = tb1.Text;
            FiltriranaOprema fo = new FiltriranaOprema(o);
            fo.ShowDialog();
        }

        private void renoviranje_click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridProstorije.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock t1 = dataGridProstorije.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock t2 = dataGridProstorije.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock t3 = dataGridProstorije.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock t4 = dataGridProstorije.Columns[3].GetCellContent(row) as TextBlock;
            TextBlock t5 = dataGridProstorije.Columns[6].GetCellContent(row) as TextBlock;
            string update = (t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/");

            ProstorijeFileStorage p = new ProstorijeFileStorage();
            p.renoviranje(update, currentRowIndex, t5.Text);
        }
    }
}
