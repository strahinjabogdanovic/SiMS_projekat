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
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageZakazivanjeDatumVM : ViewModels
    {
        public ObservableCollection<TerminiPacijenata> TerminiP { get; set; }

        private PageZakazivanjeDatum page;

        private RelayCommand nazad;
        private RelayCommand zakazi;
        private RelayCommand nazadTermini;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        public RelayCommand Zakazi
        {
            get { return zakazi; }
            set
            {
                zakazi = value;
            }
        }

        public RelayCommand NazadTermini
        {
            get { return nazadTermini; }
            set
            {
                nazadTermini = value;
            }
        }

        private DataGrid tabela = new DataGrid();

        public PageZakazivanjeDatumVM(PageZakazivanjeDatum page, string tb, DataGrid dataGridTerminiDatum)
        {
            this.page = page;
            tabela = dataGridTerminiDatum;

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

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Zakazi = new RelayCommand(Executed_Zakazi, CanExecute_NavigateCommand);
            this.NazadTermini = new RelayCommand(Executed_NazadTermini, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageDatum());
        }

        public void Executed_Zakazi(object obj)
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            if (currentRowIndex != -1)
            {
                DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                TextBlock tbPacijent = tabela.Columns[0].GetCellContent(row) as TextBlock;
                TextBlock tbDatum = tabela.Columns[1].GetCellContent(row) as TextBlock;
                TextBlock tbVreme = tabela.Columns[2].GetCellContent(row) as TextBlock;
                TextBlock tbLekar = tabela.Columns[3].GetCellContent(row) as TextBlock;
                TextBlock tbSoba = tabela.Columns[4].GetCellContent(row) as TextBlock;
                string update = (tbPacijent.Text.Trim() + "/" + tbDatum.Text + "/" + tbVreme.Text + "/" + tbLekar.Text + "/" + tbSoba.Text);

                TerminiKontroler tk = new TerminiKontroler();
                tk.ZakazivanjeSekretar(update);
            }

        }

        public void Executed_NazadTermini(object obj)
        {
            page.NavigationService.Navigate(new PageTerminiSekretar());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
