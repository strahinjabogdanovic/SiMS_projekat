using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class ValidirajLekVM : ViewModels
    {
        private ValidirajLek page;
        public string TNaziv { get; set; }
        public string TSifra { get; set; }
        public Lek lekNevalidiran;
        public RelayCommand Sacuvaj { get; set; }
        public RelayCommand Nazad { get; set; }

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
        public ValidirajLekVM(ValidirajLek vm, Lek lek)
        {
            lekNevalidiran = lek;
            page = vm;
            TNaziv = lek.NazivLeka;
            TSifra = lek.SifraLeka;
            Sacuvaj = new RelayCommand(Sacuvaj_Click);
            Nazad = new RelayCommand(Nazad_Click);

        }

        private void Sacuvaj_Click(object obj)
        {
            if (Prvi == true)
            {
                lekNevalidiran.Validiran = "da";
            }
            else
            {
                lekNevalidiran.Validiran = "ne";
            }

            LekoviFileStorage lfs = new LekoviFileStorage();
            lfs.Validiraj(lekNevalidiran);
        }

        private void Nazad_Click(object obj)
        {
            page.NavigationService.Navigate(new ValidacijaLekova());
        }
    }
}
