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
    class NapišiIzveštajVM : ViewModels, INotifyPropertyChanged
    {
        public string TextIme { get; set; }
        public string TextPrezime { get; set; }
        public string TextJmbg { get; set; }

        public string TextOdeljenje { get; set; }

        public string TextSoba { get; set; }
        public string TextNalaz { get; set; }

        public string TextTerapija { get; set; }
        public string TextKontrola { get; set; }
        public DateTime Datum { get; set; }

        public RelayCommand Button { get; set; }
        public RelayCommand Sacuvaj { get; set; }
        public RelayCommand Nazad { get; set; }
        private NapišiIzveštaj kp { get; set; }

        private bool _optionA;
        public bool Prvi
        {
            get { return _optionA; }
            set
            {
                _optionA = value;
                if (_optionA)
                {
                    this.Drugi = false;
                }
            }
        }

        private bool _optionB;
        public bool Drugi
        {
            get { return _optionB; }
            set
            {
                _optionB = value;
                if (_optionB)
                {
                    this.Prvi = false;
                }
            }
        }

        public NapišiIzveštajVM(NapišiIzveštaj page, string imePacijenta, string prezimePacijenta, string jmbgPacijenta)
        {
            kp = page;
            TextIme = imePacijenta;
            TextPrezime = prezimePacijenta;
            TextJmbg = jmbgPacijenta;
            Sacuvaj = new RelayCommand(Sacuvaj_Click, CanExecute_NavigateCommand);
            Nazad = new RelayCommand(Nazad_Click, CanExecute_NavigateCommand);
            Button = new RelayCommand(Button_Click, CanExecute_NavigateCommand);

        }

        private void Sacuvaj_Click(object obj)
        {
            IzvestajiFileStorage ifs = new IzvestajiFileStorage();
            string vrsta = "";
            if (Prvi == true)
            {
                vrsta = "Izvestaj o pregledu";
            }
            else
            {
                vrsta = "Izvestaj o hospitalizaciji";
            }
            ifs.Kreiraj(vrsta, TextOdeljenje, TextSoba, TextNalaz, TextKontrola, TextTerapija, TextJmbg, Datum);

        }

        private void Nazad_Click(object obj)
        {
            kp.NavigationService.Navigate(new KartonPacijenta(TextJmbg));
        }

        private void Button_Click(object obj)
        {
            kp.NavigationService.Navigate(new KartonPacijenta(TextJmbg));

        }
        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
