using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageTerminiSekretarVM : ViewModels
    {
        public ObservableCollection<TerminiPacijenata> TerminiP { get; set; }

        private PageTerminiSekretar page;

        private RelayCommand nazad;
        private RelayCommand zakazivanje;
        private RelayCommand otkazivanje;
        private RelayCommand promena;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        public RelayCommand Zakazivanje
        {
            get { return zakazivanje; }
            set
            {
                zakazivanje = value;
            }
        }

        public RelayCommand Otkazivanje
        {
            get { return otkazivanje; }
            set
            {
                otkazivanje = value;
            }
        }

        public RelayCommand Promena
        {
            get { return promena; }
            set
            {
                promena = value;
            }
        }

        private DataGrid tabela = new DataGrid();

        public PageTerminiSekretarVM(PageTerminiSekretar page, DataGrid dataGridTerminiSekretar)
        {
            this.page = page;
            tabela = dataGridTerminiSekretar;

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

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Zakazivanje = new RelayCommand(Executed_Zakazivanje, CanExecute_NavigateCommand);
            this.Otkazivanje = new RelayCommand(Executed_Otkazivanje, CanExecute_NavigateCommand);
            this.Promena = new RelayCommand(Executed_Promena, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageSekretar());
        }

        public void Executed_Zakazivanje(object obj)
        {
            page.NavigationService.Navigate(new PagePrioritetZakazivanja());
        }

        public void Executed_Otkazivanje(object obj)
        {
            TerminiKontroler tk = new TerminiKontroler();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
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

            page.NavigationService.Navigate(new PageTerminiSekretar());
        }

        public void Executed_Promena(object obj)
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock pacijent = tabela.Columns[0].GetCellContent(row) as TextBlock;

            TerminiKontroler tk = new TerminiKontroler();
            tk.UpdateSekretar(pacijent.Text, currentRowIndex);
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
