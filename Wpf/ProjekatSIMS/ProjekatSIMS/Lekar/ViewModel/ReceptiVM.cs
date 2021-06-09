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

namespace ProjekatSIMS.Lekar.ViewModel
{
    class ReceptiVM : ViewModels
    {
        public string TJmbg { get; set; }

        private DataGrid tabela = new DataGrid();
        public RelayCommand NoviRecept { get; set; }
        public RelayCommand Nazad { get; set; }
        private ReceptiPacijenta rp;
        public ObservableCollection<Recepti> ReceptiSpisak
        {
            get;
            set;
        }
        public ReceptiVM(ReceptiPacijenta recepti, DataGrid dgl, string jmbg)
        {
            rp = recepti;
            tabela = dgl;
            TJmbg = jmbg;
            ReceptiSpisak = new ObservableCollection<Recepti>();
            LekarKontroler lk = new LekarKontroler();
            ReceptiSpisak = lk.ReceptiOdTogPacijenta(jmbg);

            NoviRecept = new RelayCommand(NoviRecept_Click, CanExecute_NavigateCommand);
            Nazad = new RelayCommand(nazad_Click, CanExecute_NavigateCommand);
        }
        private void NoviRecept_Click(object obj)
        {
            rp.NavigationService.Navigate(new NapišiRecept(TJmbg));
        }

        private void nazad_Click(object obj)
        {
            rp.NavigationService.Navigate(new KartonPacijenta(TJmbg));
        }
        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }

    }
}
