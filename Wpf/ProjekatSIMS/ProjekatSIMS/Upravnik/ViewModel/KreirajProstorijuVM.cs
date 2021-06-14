using ProjekatSIMS.Package1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Upravnik.View;
using System.Windows;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class KreirajProstorijuVM : ValidationBase
    {
        private DodavanjeProstorijePage page;
        public ObservableCollection<Prostorije> Prostorije { get; set; }
        public MyICommand Potvrdi { get; set; }
        private string s1;
        private string s2;
        private string s3;
        private string s4;
        private string s5;

        public KreirajProstorijuVM(DodavanjeProstorijePage page)
        {
            Potvrdi = new MyICommand(PotvrdiKlik);
            this.page = page;
        }
        private void PotvrdiKlik()
        {
            this.Validate();
            if (this.IsValid)
            {
                ProstorijeKontroler pk = new ProstorijeKontroler();
                pk.Kreiraj(S1, S2, S3, S4, S5);
                page.NavigationService.Navigate(new UpravnikPage());
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(S1))
            {
                this.ValidationErrors["ime"] = "Obavezno je uneti ime prostorije";
            }
            else if (!Regex.IsMatch(S1, @"^[A-Z][a-z]+[0-9]*"))
            {
                this.ValidationErrors["ime"] = "Ime more biti oblika: Sala nn (n - broj)";
            }

            if (string.IsNullOrWhiteSpace(S2))
            {
                this.ValidationErrors["oznaka"] = "Obavezno je uneti oznaku prostorije";
            }
            else if (!Regex.IsMatch(S2, @"^[A-Z][0-9]"))
            {
                this.ValidationErrors["oznaka"] = "Oznaka mora biti oblika: Xn (X - slovo, n - broj)";
            }

            if (string.IsNullOrWhiteSpace(S3))
            {
                this.ValidationErrors["namena"] = "Obavezno je uneti namenu prostorije";
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



    }
}
