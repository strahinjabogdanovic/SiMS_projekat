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
    public partial class PageTerminiSekretar : Page
    {
        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        
        public PageTerminiSekretar()
        {
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("termini.txt").ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var pacijent = new TerminiPacijenata();
                pacijent.datum = termin[0].ToString();
                pacijent.vreme = termin[1].ToString();
                pacijent.lekar = termin[2].ToString();
                pacijent.soba = termin[3].ToString();
                pacijent.id = int.Parse(termin[4].ToString());
                pacijent.pacijenti = termin[5].ToString();

                TerminiP.Add(pacijent);

            }

            InitializeComponent();
            this.DataContext = this;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }

        private void ZakazivanjeT_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PagePrioritetZakazivanja());
        }

        private void OtkazivanjeT_Click(object sender, RoutedEventArgs e)
        {
            TerminiKontroler tk = new TerminiKontroler();
            int currentRowIndex = dataGridTerminiSekretar.Items.IndexOf(dataGridTerminiSekretar.SelectedItem);
            if (currentRowIndex != -1)
            {
                if (TerminiP.Count > 0)
                {
                    TerminiP.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                tk.OtkazivanjeSekretar(currentRowIndex);
            }

            this.NavigationService.Navigate(new PageTerminiSekretar());

        }

        private void PromenaT_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridTerminiSekretar.Items.IndexOf(dataGridTerminiSekretar.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridTerminiSekretar.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock pacijent = dataGridTerminiSekretar.Columns[0].GetCellContent(row) as TextBlock;

            TerminiKontroler tk = new TerminiKontroler();
            tk.UpdateSekretar(pacijent.Text, currentRowIndex);
        }
    }
}
