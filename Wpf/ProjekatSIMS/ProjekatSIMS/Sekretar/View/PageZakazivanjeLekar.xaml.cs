using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageZakazivanjeLekar : Page
    {
        /*
        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }*/
        private PageZakazivanjeLekarVM viewModel;

        public PageZakazivanjeLekar(string lekar)
        {
            /*
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("termini.txt").ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var pacijent = new TerminiPacijenata();

                string dr = "";

                if (lekar != null)
                {

                    if (lekar.Contains("Jova Jovic"))
                    {                       
                        dr = "Jova Jovic";

                    }
                    else if (lekar.Contains("Jovan Jovanovic"))
                    {
                        dr = "Jovan Jovanovic";
                    }
                }

                if (termin[2].Equals(dr))
                {
                    pacijent.datum = termin[0].ToString();
                    pacijent.vreme = termin[1].ToString();
                    pacijent.lekar = termin[2].ToString();
                    pacijent.soba = termin[3].ToString();
                    pacijent.id = int.Parse(termin[4].ToString());
                    pacijent.pacijenti = termin[5].ToString();

                    TerminiP.Add(pacijent);
                }
            }*/

            InitializeComponent();
            this.viewModel = new PageZakazivanjeLekarVM(this, lekar, dataGridTerminiLekar);
            this.DataContext = this.viewModel;
        }

        /*
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageLekar());
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridTerminiLekar.Items.IndexOf(dataGridTerminiLekar.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridTerminiLekar.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock tbPacijent = dataGridTerminiLekar.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock tbDatum = dataGridTerminiLekar.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock tbVreme = dataGridTerminiLekar.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock tbLekar = dataGridTerminiLekar.Columns[3].GetCellContent(row) as TextBlock;
            TextBlock tbSoba = dataGridTerminiLekar.Columns[4].GetCellContent(row) as TextBlock;
            string update = (tbPacijent.Text + "/" + tbDatum.Text + "/" + tbVreme.Text + "/" + tbLekar.Text + "/" + tbSoba.Text);

            TerminiKontroler tk = new TerminiKontroler();
            tk.ZakazivanjeSekretar(update);
        }

        private void NazadTermini_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTerminiSekretar());
        }*/
    }
}
