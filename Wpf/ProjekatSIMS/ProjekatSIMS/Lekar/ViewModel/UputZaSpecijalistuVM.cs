using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class UputZaSpecijalistuVM : ViewModels, INotifyPropertyChanged
    {
        public string Kome { get; set; }
        public string BrojKartona { get; set; }
        public string Specijalnost { get; set; }
        public string ImeIPrezime { get; set; }
        public string Jmbg { get; set; }
        public string Zbog { get; set; }
        public RelayCommand Sacuvaj { get; set; }
        public RelayCommand Nazad { get; set; }
        public RelayCommand Zakazi { get; set; }
        public UputZaSpecijalistu uzs;
        public UputZaSpecijalistuVM(UputZaSpecijalistu uput, string jmbg)
        {
            uzs = uput;
            LekarFileStorage lfs = new LekarFileStorage();
            String[] podaci = new string[8];
            podaci = lfs.KartonPoJmbgu(jmbg);

            string TIme = podaci[0];
            string TPrezime = podaci[1];
            ImeIPrezime = TIme + " " + TPrezime;
            Jmbg = jmbg;
            Sacuvaj = new RelayCommand(Sacuvaj_Click);
            Nazad = new RelayCommand(Nazad_Click);
            Zakazi = new RelayCommand(Zakazi_Click);
        }

        public UputZaSpecijalistuVM(UputZaSpecijalistu uput, string imeiPrezime, string jmbg)
        {
            uzs = uput;
            ImeIPrezime = imeiPrezime;
            Jmbg = jmbg;
            Sacuvaj = new RelayCommand(Sacuvaj_Click);
            Nazad = new RelayCommand(Nazad_Click);
            Zakazi = new RelayCommand(Zakazi_Click);
        }

        private void Sacuvaj_Click(object obj)
        {
            UputiFileStorage uput = new UputiFileStorage(Jmbg, Kome, BrojKartona, Specijalnost, Zbog);
            uput.Kreiraj();
        }

        private void Nazad_Click(object obj)
        {
            uzs.NavigationService.Navigate(new KartonPacijenta(Jmbg));
        }

        private void Zakazi_Click(object obj)
        {
            uzs.NavigationService.Navigate(new ZakazivanjeKodSpecijaliste(Jmbg, Specijalnost));

        }
    }
}
