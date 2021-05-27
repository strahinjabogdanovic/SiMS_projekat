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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.View;

namespace ProjekatSIMS
{
    public partial class PageZakazivanjeDatum : Page
    {
        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        public PageZakazivanjeDatum(string tb)
        {
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("termini.txt").ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var pacijent = new TerminiPacijenata();

                if (termin[0].Equals(tb))
                {
                    pacijent.datum = termin[0].ToString();
                    pacijent.vreme = termin[1].ToString();
                    pacijent.lekar = termin[2].ToString();
                    pacijent.soba = termin[3].ToString();
                    pacijent.id = int.Parse(termin[4].ToString());
                    pacijent.pacijenti = termin[5].ToString();

                    TerminiP.Add(pacijent);
                }             
            }

            InitializeComponent();
            this.DataContext = this;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageDatum());
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridTerminiDatum.Items.IndexOf(dataGridTerminiDatum.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridTerminiDatum.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock tbPacijent = dataGridTerminiDatum.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock tbDatum = dataGridTerminiDatum.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock tbVreme = dataGridTerminiDatum.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock tbLekar = dataGridTerminiDatum.Columns[3].GetCellContent(row) as TextBlock;
            TextBlock tbSoba = dataGridTerminiDatum.Columns[4].GetCellContent(row) as TextBlock;
            string update = (tbPacijent.Text + "/" + tbDatum.Text + "/" + tbVreme.Text + "/" + tbLekar.Text + "/" + tbSoba.Text);

            TerminiKontroler tk = new TerminiKontroler();
            tk.ZakazivanjeSekretar(update);
        }

        private void NazadTermini_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTerminiSekretar());
        }
    }
}
