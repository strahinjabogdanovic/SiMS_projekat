using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageSekretarZakazTerminaVM : ViewModels
    {
        private PageSekretarZakazTermina page;

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

        public PageSekretarZakazTerminaVM(PageSekretarZakazTermina page)
        {
            this.page = page;

            this.Potvrdi = new RelayCommand(Executed_Potvrdi, CanExecute_NavigateCommand);
            this.Odustani = new RelayCommand(Executed_Odustani, CanExecute_NavigateCommand);
        }

        public void Executed_Potvrdi(object obj)
        {
            PacijentFileStorage p = new PacijentFileStorage();

            //string lekar = comboBox.SelectedValue.ToString();
            string tb = S1;
            string tb1 = S2;
            string tb2 = S3;

            //p.KreirajSekretar(lekar, tb, tb1, tb2);

            page.NavigationService.Navigate(new PageTerminiSekretar());
        }

        public void Executed_Odustani(object obj)
        {
            page.NavigationService.Navigate(new PageTerminiSekretar());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
