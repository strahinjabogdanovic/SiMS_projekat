using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class KartonPacijentaVM : ViewModels, INotifyPropertyChanged
    {
        public string TIme { get; set; }
        public string TPrezime { get; set; }
        public string TJmbg { get; set; }
        public string TPol { get; set; }
        public string TDatum { get; set; }
        public string TAdresa { get; set; }
        public string TBroj { get; set; }
        public string TEmail { get; set; }
        private KartonPacijenta kp { get; set; }
        public RelayCommand Nazad { get; set; }
        public RelayCommand NapisiIzvestaj { get; set; }
        public RelayCommand Recepti { get; set; }
        public RelayCommand Izvestaji { get; set; }
        public RelayCommand Uput { get; set; }
        public RelayCommand UputiZaBolnicu { get; set; }

        public KartonPacijentaVM(KartonPacijenta page, string jmbgPacijenta)
        {
            kp = page;
            LekarFileStorage lfs = new LekarFileStorage();
            String[] podaci = new string[8];
            podaci = lfs.KartonPoJmbgu(jmbgPacijenta);

            TIme = podaci[0];
            TPrezime = podaci[1];
            TJmbg = podaci[2];
            TPol = podaci[3];
            TBroj = podaci[6];
            TDatum = podaci[4];
            TEmail = podaci[5];
            TAdresa = podaci[7];
            PovezivanjeKomandiSaMetodom();

        }
        private void PovezivanjeKomandiSaMetodom()
        {
            NapisiIzvestaj = new RelayCommand(Napisi_izvestaj, CanExecute_NavigateCommand);
            Nazad = new RelayCommand(Nazad_Click, CanExecute_NavigateCommand);
            Recepti = new RelayCommand(Recepti_Click, CanExecute_NavigateCommand);
            Izvestaji = new RelayCommand(Izvest_Click, CanExecute_NavigateCommand);
            Uput = new RelayCommand(UputLekaruSpecijalisti_Click, CanExecute_NavigateCommand);
            UputiZaBolnicu = new RelayCommand(UputZaBolnicu_Click, CanExecute_NavigateCommand);
        }
        private void Recepti_Click(object obj)
        {
            kp.NavigationService.Navigate(new ReceptiPacijenta(TJmbg));

        }

        private void Napisi_izvestaj(object obj)
        {
            kp.NavigationService.Navigate(new NapišiIzveštaj(TIme, TPrezime, TJmbg));

        }


        private void Izvest_Click(object obj)
        {
            kp.NavigationService.Navigate(new Izveštaji(TJmbg));

        }

        private void UputLekaruSpecijalisti_Click(object obj)
        {
            kp.NavigationService.Navigate(new UputZaSpecijalistu(TIme + " " + TPrezime, TJmbg));

        }

        private void UputZaBolnicu_Click(object obj)
        {
            kp.NavigationService.Navigate(new UputBolnicko(TIme, TPrezime, TJmbg));
        }

        private void Nazad_Click(object obj)
        {
            kp.NavigationService.Navigate(new LekarPocetna());

        }
        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
