using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageDatumVM : ViewModels
    {
        private PageDatum page;

        private RelayCommand nazad;
        private RelayCommand potvrdi;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
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

        public PageDatumVM(PageDatum page)
        {
            this.page = page;

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Potvrdi = new RelayCommand(Executed_Potvrdi, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PagePrioritetZakazivanja());
        }

        public void Executed_Potvrdi(object obj)
        {
            /*
            string datum = myDatePicker.ToString();
            String[] termin = datum.Split(' ');
            String[] termin1 = termin[0].Split('-');
            string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";
            page.NavigationService.Navigate(new PageZakazivanjeDatum(datum1));
            */
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
