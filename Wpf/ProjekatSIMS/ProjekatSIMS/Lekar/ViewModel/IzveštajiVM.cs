using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class IzveštajiVM : ViewModels
    {
        public ObservableCollection<MedIzvestaj> Izvopr { get; set; }

        private DataGrid tabela = new DataGrid();
        public string TJmbg { get; set; }
        public RelayCommand Izmeni { get; set; }
        public RelayCommand Nazad { get; set; }
        private Izveštaji page;
        public RelayCommand PDF { get; set; }


        public IzveštajiVM(Izveštaji izv, DataGrid dg, string jmbg)
        {
            tabela = dg;
            TJmbg = jmbg;
            page = izv;
            Izvopr = new ObservableCollection<MedIzvestaj>();
            LekarServis ifs = new LekarServis();
            Izvopr = ifs.NadjiIzvestaje(jmbg);

            PridruzivanjeMetodaKomandama();
        }
        private void PridruzivanjeMetodaKomandama()
        {
            Izmeni = new RelayCommand(Izmeni_Click, CanExecute_NavigateCommand);
            Nazad = new RelayCommand(Nazad_Click, CanExecute_NavigateCommand);
            PDF = new RelayCommand(PDF_Click);
        }
        private void Izmeni_Click(object obj)
        {

            if (tabela.SelectedItem == null)
            {
                //Prikazi tooltip
            }

            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            IzvestajiFileStorage ifs = new IzvestajiFileStorage();
            ifs.Izmeni(currentRowIndex, tabela);
        }
        private void Nazad_Click(object obj)
        {
            page.NavigationService.Navigate(new KartonPacijenta(TJmbg));
        }
        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }

        private void PDF_Click(object obj)
        {

        }
    }
}
