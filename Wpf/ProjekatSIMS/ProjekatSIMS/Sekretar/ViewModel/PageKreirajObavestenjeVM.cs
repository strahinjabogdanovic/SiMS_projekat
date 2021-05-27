using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageKreirajObavestenjeVM : ViewModels
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

        public PageKreirajObavestenjeVM(PageKreirajObavestenje page)
        {
            this.page = page;

            this.Potvrdi = new RelayCommand(Executed_Potvrdi, CanExecute_NavigateCommand);
            this.Odustani = new RelayCommand(Executed_Odustani, CanExecute_NavigateCommand);
        }

        public void Executed_Potvrdi(object obj)
        {
            ObavestenjaKontroler ok = new ObavestenjaKontroler();

            string naziv = S1;
            string sadrzaj = S2;
            string uloga = S3;
            //string datum = myDatePicker.ToString();
            //String[] termin = datum.Split(' ');
            //String[] termin1 = termin[0].Split('-');
            //string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";
            //string obavestenje = (naziv + "/" + sadrzaj + "/" + datum1 + "/" + uloga);

            //ok.Kreiraj(obavestenje);

            page.NavigationService.Navigate(new PageObavestenjaSekretar());
        }

        public void Executed_Odustani(object obj)
        {
            page.NavigationService.Navigate(new PageObavestenjaSekretar());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
