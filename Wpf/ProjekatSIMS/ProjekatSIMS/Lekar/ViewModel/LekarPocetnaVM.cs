using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    public class LekarPocetnaVM : ViewModels
    {
        public ObservableCollection<TerminiPacijenata> ZakazTermina
        {
            get;
            set;
        }

        public RelayCommand Kreiraj { get; set; }
        public RelayCommand Izmeni { get; set; }
        public RelayCommand Obrisi { get; set; }
        public RelayCommand Karton { get; set; }
        public RelayCommand Validacija { get; set; }
        public RelayCommand Feedback { get; set; }

        public string tJmbg;
        public DataGrid tabela = new DataGrid();
        private LekarPocetna page;
        public string TMora { get; set; }
        public LekarPocetnaVM(LekarPocetna lp, DataGrid dgp)
        {
            tabela = dgp;
            page = lp;
            ZakazTermina = new ObservableCollection<TerminiPacijenata>();
            LekarKontroler lk = new LekarKontroler();
            ZakazTermina = lk.NadjiTermine();
            Kreiraj = new RelayCommand(Executed_Kreiraj, CanExecute_NavigateCommand);
            Izmeni = new RelayCommand(Executed_Izmeni, CanExecute_NavigateCommand);
            Karton = new RelayCommand(Executed_Karton, CanExecute_NavigateCommand);
            Obrisi = new RelayCommand(Executed_Obrisi, CanExecute_NavigateCommand);
            Validacija = new RelayCommand(Executed_Validacija, CanExecute_NavigateCommand);
            Feedback = new RelayCommand(Executed_Feedback, CanExecute_NavigateCommand);


        }
        public void Executed_Kreiraj(object obj)
        {
            if (tabela.SelectedItem == null)
            {
                NoviTermin k = new NoviTermin();

                page.NavigationService.Navigate(k);


            }

            if (tabela.SelectedItem != null)
            {
                int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
                DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                TextBlock t5 = tabela.Columns[5].GetCellContent(row) as TextBlock;
                string jmbg = t5.Text;
                Console.WriteLine(jmbg);

                page.NavigationService.Navigate(new NoviTermin(jmbg));

            }

        }
        public void Executed_Izmeni(object obj)
        {
            TerminiFileStorage t = new TerminiFileStorage();
            t.Update(tabela);
        }
        public void Executed_Karton(object obj)
        {
            if (tabela.SelectedItem != null)
            {
                DataGridRow row =
                    (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(
                        tabela.Items.IndexOf(tabela.SelectedItem));
                TextBlock t5 = tabela.Columns[5].GetCellContent(row) as TextBlock;
                string jmbg = t5.Text;
                page.NavigationService.Navigate(new KartonPacijenta(jmbg));

            }
            else
            {
                TMora = "Morate izabrati termin pacijenta /n da biste videli njegov karton";
            }


        }

        public void Executed_Obrisi(object obj)
        {
            TerminiFileStorage tf = new TerminiFileStorage();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            TerminiPacijenata k = ZakazTermina.ElementAt(currentRowIndex);
            if (ZakazTermina.Count > 0)
            {
                ZakazTermina.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            tf.Obrisi(k);
        }

        public void Executed_Validacija(object obj)
        {
            page.NavigationService.Navigate(new ValidacijaLekova());
        }
        public void Executed_Feedback(object obj)
        {
            page.NavigationService.Navigate(new Feedback());
        }
        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
        public void logout(object obj)
        {
            MainWindow mainWindow = new MainWindow();

            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }

            mainWindow.ShowDialog();

        }
    }
}
