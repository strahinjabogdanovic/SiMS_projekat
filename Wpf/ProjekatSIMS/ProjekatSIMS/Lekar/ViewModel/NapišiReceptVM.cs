using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    class NapišiReceptVM : ViewModels, INotifyPropertyChanged
    {
        public Lek lek = new Lek();
        public NaloziPacijenataFileStorage pac = new NaloziPacijenataFileStorage();
        public string TextJmbg { get; set; }

        public string Naziv { get; set; }
        public string Nacin { get; set; }
        public string NaKolikoSati { get; set; }
        public RelayCommand pronadji { get; set; }
        public RelayCommand Izdaj { get; set; }
        public RelayCommand Nazad { get; set; }

        public NapišiRecept nr;

        public NapišiReceptVM(NapišiRecept napRecept, string jmbgPacijenta)
        {
            string jmbg = jmbgPacijenta;
            nr = napRecept;
            TextJmbg = jmbg;
            MetodeNaKomande();
        }
        private void MetodeNaKomande()
        {
            Izdaj = new RelayCommand(Izdaj_Click, CanExecute_NavigateCommand);
            pronadji = new RelayCommand(pronadji_Click, CanExecute_NavigateCommand);
            Nazad = new RelayCommand(nazad_Click, CanExecute_NavigateCommand);
        }
        private void Izdaj_Click(object obj)
        {
            ReceptiFileStorage rfs = new ReceptiFileStorage();
            rfs.Kreiraj(Sifra, Naziv, Nacin, NaKolikoSati, TextJmbg);

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _sifra;
        public string Sifra
        {
            get { return _sifra; }
            set
            {
                if (value != _sifra)
                {
                    _sifra = value;
                    OnPropertyChanged("Sifra");
                }
            }
        }
        private void pronadji_Click(object obj)
        {
            Lek lekicPrazan = new Lek();
            lek = lekicPrazan.dobaviLekPoNazivu(Naziv);
            NaloziPacijenataFileStorage nalozi = new NaloziPacijenataFileStorage();
            int id = nalozi.dobaviIdPacijentaPoJmbgu(TextJmbg);

            Sifra = lek.SifraLeka;
            string alerg = nalozi.DobaviAlergije(id);
            LekarServis ls = new LekarServis();
            string proverenaAlergija = ls.proveriAlergije(lek.sastojci, alerg, lek.sifraleka);
            if (proverenaAlergija != "")
            {
                ZabranaIzdavanjaRecepta zir = new ZabranaIzdavanjaRecepta(proverenaAlergija);
                zir.ShowDialog();
            }

        }
        private void nazad_Click(object obj)
        {
            nr.NavigationService.Navigate(new ReceptiPacijenta(TextJmbg));

        }
        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }

    }
}
