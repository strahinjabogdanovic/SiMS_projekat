using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageKreirajGuestNalogVM : ValidationBase
    {
        public ObservableCollection<GuestNalog> Guest { get; set; }

        private RelayCommand potvrdi;
        private RelayCommand odustani;

        private string s1;
        private string s2;
        private string s3;

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

        public string S3
        {
            get { return s3; }
            set
            {
                if (s3 != value)
                {
                    s3 = value;
                    OnPropertyChanged("S3");
                }
            }
        }

        public RelayCommand Potvrdi
        {
            get { return potvrdi; }
            set
            {
                potvrdi = value;
            }
        }

        public RelayCommand Odustani
        {
            get { return odustani; }
            set
            {
                odustani = value;
            }
        }

        private PageKreirajGuestNalog page;

        public PageKreirajGuestNalogVM(PageKreirajGuestNalog page)
        {
            this.page = page;

            this.Potvrdi = new RelayCommand(Executed_Potvrdi);
            this.Odustani = new RelayCommand(Executed_Odustani, CanExecute_NavigateCommand);
        }

        public void Executed_Potvrdi(object obj)
        {
            this.Validate();
            if (this.IsValid)
            {
                GuestKontroler gk = new GuestKontroler();
                string ime = S1;
                string prezime = S2;
                string jmbg = S3;
                string guestNalog = (ime + "/" + prezime + "/" + jmbg);
                gk.Kreiraj(guestNalog);

                page.NavigationService.Navigate(new PageGuestNalozi());
            }

        }

        public void Executed_Odustani(object obj)
        {
            page.NavigationService.Navigate(new PageGuestNalozi());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(S1))
            {
                this.ValidationErrors["ime"] = "Obavezno je uneti ime";
            }
            else if (!Regex.IsMatch(S1, @"^[a-zA-Z]+$"))
            {
                this.ValidationErrors["ime"] = "Ime može da sadrži samo slova";
            }

            if (string.IsNullOrWhiteSpace(S2))
            {
                this.ValidationErrors["prezime"] = "Obavezno je uneti prezime";
            }
            else if (!Regex.IsMatch(S2, @"^[a-zA-Z]+$"))
            {
                this.ValidationErrors["prezime"] = "Prezime može da sadrži samo slova";
            }

            if (string.IsNullOrWhiteSpace(S3))
            {
                this.ValidationErrors["jmbg"] = "Obavezno je uneti JMBG";
            }
            else if (S3.Length != 13)
            {
                this.ValidationErrors["jmbg"] = "JMBG mora da sadrži 13 cifara";
            }
        }
    }
}
