using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageKreirajObavestenjeVM : ValidationBase
    {
        private PageKreirajObavestenje page;

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

        private DateTime date { get; set; }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        private DatePicker d = new DatePicker();

        public PageKreirajObavestenjeVM(PageKreirajObavestenje page)
        {
            this.page = page;
            //d = myDatePicker;
            DateTime p = DateTime.Now;
            Date = p;
            

            this.Potvrdi = new RelayCommand(Executed_Potvrdi);
            this.Odustani = new RelayCommand(Executed_Odustani, CanExecute_NavigateCommand);
        }

        public void Executed_Potvrdi(object obj)
        {
            this.Validate();
            if (this.IsValid)
            {
                ObavestenjaKontroler ok = new ObavestenjaKontroler();

                string naziv = S1;
                string sadrzaj = S2;
                string uloga = S3;
                string datum = Date.ToString();
                String[] termin = datum.Split(' ');
                String[] termin1 = termin[0].Split('/');
                string dan = "";
                string mesec = "";
                if (int.Parse(termin1[1]) < 10)
                {
                    dan = "0" + termin1[1];
                }
                else
                {
                    dan = termin1[1];
                }
                if (int.Parse(termin1[0]) < 10)
                {
                    mesec = "0" + termin1[0];
                }
                else
                {
                    mesec = termin1[0];
                }
                string datum1 = dan + "." + mesec + "." + termin1[2] + ".";
                string obavestenje = (naziv + "/" + sadrzaj + "/" + datum1 + "/" + uloga);

                ok.Kreiraj(obavestenje);

                page.NavigationService.Navigate(new PageObavestenjaSekretar());
            }

        }

        public void Executed_Odustani(object obj)
        {
            page.NavigationService.Navigate(new PageObavestenjaSekretar());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(S1))
            {
                this.ValidationErrors["naziv"] = "Obavezno je uneti naziv obaveštenja";
            }
            if (string.IsNullOrWhiteSpace(S2))
            {
                this.ValidationErrors["sadrzaj"] = "Obavezno je uneti sadržaj obaveštenja";
            }
            if (string.IsNullOrWhiteSpace(S3))
            {
                this.ValidationErrors["vidljivost"] = "Obavezno je uneti ko vidi obaveštenje";
            }
        }
    }
}
