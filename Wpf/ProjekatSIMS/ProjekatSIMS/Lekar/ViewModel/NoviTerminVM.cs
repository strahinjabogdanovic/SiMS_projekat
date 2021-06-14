using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class NoviTerminVM : ViewModels
    {
        private NoviTermin nt;
        public string TUpo { get; set; }
        public RelayCommand Potvrdi { get; set; }
        public RelayCommand Odustani { get; set; }
        public RelayCommand Nazad { get; set; }
        public string Vrsta { get; set; }
        public string Lekar { get; set; }
        public DateTime Datum { get; set; }
        public string TIme { get; set; }
        public string TPrezime { get; set; }
        public string TVreme { get; set; }
        public string TSoba { get; set; }
        public string TJmbg { get; set; }
        public NoviTerminVM(NoviTermin noviTermin)
        {
            nt = noviTermin;
            Potvrdi = new RelayCommand(Potvrdi_Click);
            Odustani = new RelayCommand(Odustani_Click);
            Nazad = new RelayCommand(Nazad_Click);
        }

        public NoviTerminVM(NoviTermin noviTermin, string jmbg)
        {
            nt = noviTermin;
            LekarFileStorage lfs = new LekarFileStorage();
            String[] podaci = new string[2];
            podaci = lfs.KartonPoJmbgu(jmbg);

            TIme = podaci[0];
            TPrezime = podaci[1];
            TJmbg = jmbg;
            Potvrdi = new RelayCommand(Potvrdi_Click);
            Odustani = new RelayCommand(Odustani_Click);
            Nazad = new RelayCommand(Nazad_Click);

        }

        private void Potvrdi_Click(object obj)
        {
            if (TIme != "" & TPrezime != "" & TSoba != "" & TVreme != "")
            {
                TerminiFileStorage tfs = new TerminiFileStorage();
                tfs.Zakazi(Datum, TVreme, Lekar, TSoba, TIme + " " + TPrezime, " ", Vrsta);
            }
            else
            {
                TUpo = "Morate popuniti sva polja";
            }
        }

        private void Odustani_Click(object obj)
        {
            nt.NavigationService.Navigate(new LekarPocetna());
        }

        private void Nazad_Click(object obj)
        {
            nt.NavigationService.Navigate(new LekarPocetna());
        }
    }
}
