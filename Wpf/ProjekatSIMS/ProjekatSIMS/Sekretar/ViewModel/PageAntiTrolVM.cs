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
    public class PageAntiTrolVM : ViewModels
    {
        public ObservableCollection<TerminiPacijenata> TerminiP { get; set; }

        private PageAntiTrol page;

        private RelayCommand nazad;
        private RelayCommand odblokiraj;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        public RelayCommand Odblokiraj
        {
            get { return odblokiraj; }
            set
            {
                odblokiraj = value;
            }
        }

        private DataGrid tabela = new DataGrid();

        public PageAntiTrolVM(PageAntiTrol page, DataGrid dataGridAntiTrol)
        {
            this.page = page;
            tabela = dataGridAntiTrol;

            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("termini.txt").ToList();

            foreach (string linee in lines)
            {
                String[] termini = linee.Split('/');
                var pacijent = new TerminiPacijenata();

                if (termini[6].Equals("x"))
                {
                    pacijent.pacijenti = termini[5].ToString();
                    TerminiP.Add(pacijent);
                }
            }

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Odblokiraj = new RelayCommand(Executed_Odblokiraj, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageSekretar());
        }

        public void Executed_Odblokiraj(object obj)
        {
            TerminiKontroler tk = new TerminiKontroler();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);

            if (currentRowIndex != -1)
            {
                TerminiPacijenata k = TerminiP.ElementAt(currentRowIndex);
                if (TerminiP.Count > 0)
                {
                    TerminiP.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                tk.AntiTrolSekretar(k);
            }

            page.NavigationService.Navigate(new PageAntiTrol());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
