using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageSKreirajNalogVM : ValidationBase
    {
        private PageSKreirajNalog page;

        private RelayCommand potvrdi;
        private RelayCommand odustani;

        private string s1;
        private string s2;
        private string s3;
        private string s4;
        private string s5;
        private string s6;

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

        public string S4
        {
            get { return s4; }
            set
            {
                if (s4 != value)
                {
                    s4 = value;
                    OnPropertyChanged("S4");
                }
            }
        }

        public string S5
        {
            get { return s5; }
            set
            {
                if (s5 != value)
                {
                    s5 = value;
                    OnPropertyChanged("S5");
                }
            }
        }

        public string S6
        {
            get { return s6; }
            set
            {
                if (s6 != value)
                {
                    s6 = value;
                    OnPropertyChanged("S6");
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

        private ComboBox c = new ComboBox();
        private DatePicker d = new DatePicker();

        public PageSKreirajNalogVM(PageSKreirajNalog page, ComboBox pol, DatePicker datum)
        {
            this.page = page;
            c = pol;
            d = datum;

            this.Potvrdi = new RelayCommand(Executed_Potvrdi);
            this.Odustani = new RelayCommand(Executed_Odustani, CanExecute_NavigateCommand);
        }

        public void Executed_Potvrdi(object obj)
        {
            this.Validate();
            if (this.IsValid)
            {
                NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();

                string ime = S1;
                string prezime = S2;
                string jmbg = S3;
                string mail = S4;
                string brojTel = S5;
                string adresa = S6;

                string pol = c.SelectedValue.ToString();
                string datum = d.ToString();
                String[] termin = datum.Split(' ');
                String[] termin1 = termin[0].Split('-');
                string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";

                string nalog = (ime + "/" + prezime + "/" + jmbg);
                string nalogNastavak = (datum1 + "/" + mail + "/" + brojTel + "/" + adresa);

                npk.Kreiraj(nalog, pol, nalogNastavak);


                page.NavigationService.Navigate(new PageSekretar());
            }

        }

        public void Executed_Odustani(object obj)
        {
            page.NavigationService.Navigate(new PageSekretar());
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
                this.ValidationErrors["ime"] = "Ime mora da sadrži samo slova";
            }

            if (string.IsNullOrWhiteSpace(S2))
            {
                this.ValidationErrors["prezime"] = "Obavezno je uneti prezime";
            }
            else if (!Regex.IsMatch(S2, @"^[a-zA-Z]+$"))
            {
                this.ValidationErrors["prezime"] = "Prezime mora da sadrži samo slova";
            }

            if (string.IsNullOrWhiteSpace(S3))
            {
                this.ValidationErrors["jmbg"] = "Obavezno je uneti JMBG";
            }
            else if (S3.Length != 13)
            {
                this.ValidationErrors["jmbg"] = "JMBG mora da sadrži 13 cifara";
            }

            if (string.IsNullOrWhiteSpace(S4))
            {
                this.ValidationErrors["email"] = "Obavezno je uneti email";
            }
            else if (!Regex.IsMatch(S4, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                this.ValidationErrors["email"] = "Pogrešno unet email";
            }

            if (string.IsNullOrWhiteSpace(S5))
            {
                this.ValidationErrors["brTel"] = "Obavezno je uneti broj telefona";
            }
            else if (!Regex.IsMatch(S5, @"[0-9]+"))
            {
                this.ValidationErrors["brTel"] = "Broj telefona mora da sadrži samo cifre";
            }

            if (string.IsNullOrWhiteSpace(S6))
            {
                this.ValidationErrors["adresa"] = "Obavezno je uneti adresu";
            }
        }
    }
}
