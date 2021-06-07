using ProjekatSIMS.Package1.Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Sekretar.ViewModel;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class DodavanjeLekaVM : ValidationBase
    {
        private DodavanjeLekaPage page;
        private DataGrid tabela = new DataGrid();
        public MyICommand Potvrdi { get; set; }
        private string s1;
        private string s2;
        private string s3;
        private string s4;
        public DodavanjeLekaVM(DodavanjeLekaPage page)
        {
            Potvrdi = new MyICommand(PotvrdiKlik);
            this.page = page;
        }

        private void PotvrdiKlik()
        {
            this.Validate();
            if (this.IsValid)
            {
                LekoviKontroler lk = new LekoviKontroler();
                MessageBox.Show("Lek poslat na validaciju kod lekara");
                lk.Kreiraj(S1, S2, S3, S4);
                page.NavigationService.Navigate(new LekoviPage());
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(S1))
            {
                this.ValidationErrors["sifra"] = "Obavezno je uneti šifru leka";
            }
            else if (!Regex.IsMatch(S1, @"^[A-Z][0-9]{3}"))
            {
                this.ValidationErrors["sifra"] = "Šifra mora biti oblika: Xnnn (n - broj)";
            }

            if (string.IsNullOrWhiteSpace(S2))
            {
                this.ValidationErrors["naziv"] = "Obavezno je uneti naziv leka";
            }
            else if (!Regex.IsMatch(S2, @"^[A-Z][a-z]+"))
            {
                this.ValidationErrors["naziv"] = "Naziv mora da sadrži samo slova";
            }

            if (string.IsNullOrWhiteSpace(S3))
            {
                this.ValidationErrors["sastojci"] = "Obavezno je uneti sastojke leka";
            }

            if (string.IsNullOrWhiteSpace(S4))
            {
                this.ValidationErrors["zamena"] = "Obavezno je uneti zamenu za lek";
            }
            else if (!Regex.IsMatch(S4, @"^[A-Z][a-z]+"))
            {
                this.ValidationErrors["zamena"] = "Zamena mora da sadrži samo slova";
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
    }
}
