using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class DodajOpremuVM : ValidationBase
    {
        private DodavanjeOpremePage page;
        public ObservableCollection<Oprema> Opreme{ get; set;}
        int redStvari = 0;
        private string s1;
        private string s2;
        public MyICommand Potvrdi { get; set; }
        public DodajOpremuVM(DodavanjeOpremePage page, int c)
        {
            this.page = page;
            redStvari = c;
            Potvrdi = new MyICommand(PotvrdiKlik);
        }

        private void PotvrdiKlik()
        {
            this.Validate();
            if (this.IsValid)
            {
                OpremaKontroler ok = new OpremaKontroler();
                ok.Kreiraj(S1, S2, redStvari);
                page.NavigationService.Navigate(new OpremaPage(redStvari));
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(S1))
            {
                this.ValidationErrors["oprema"] = "Obavezno je uneti naziv opreme";
            }
            else if (!Regex.IsMatch(S1, @"^[A-Za-z]"))
            {
                this.ValidationErrors["oprema"] = "Naziv mora da sadrži samo slova";
            }

            if (string.IsNullOrWhiteSpace(S2))
            {
                this.ValidationErrors["kolicina"] = "Obavezno je uneti količinu opreme";
            }
            else if (!Regex.IsMatch(S2, @"^[0-9]"))
            {
                this.ValidationErrors["kolicina"] = "Količina mora da sadrži samo brojeve";
            }
        }

        public string S1
        {
            get { return s1; }
            set
            {
                if (s1 != value)
                {
                    s1 = value;
                    OnPropertyChanged("S1");
                }
            }
        }
        public string S2
        {
            get { return s2; }
            set
            {
                if (s2 != value)
                {
                    s2 = value;
                    OnPropertyChanged("S2");
                }
            }
        }
    }
}
