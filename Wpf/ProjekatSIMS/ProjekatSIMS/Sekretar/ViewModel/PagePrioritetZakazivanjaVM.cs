using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PagePrioritetZakazivanjaVM : ViewModels
    {
        private PagePrioritetZakazivanja page;

        private RelayCommand nazad;
        private RelayCommand datum;
        private RelayCommand lekar;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        public RelayCommand Datum
        {
            get { return datum; }
            set
            {
                datum = value;
            }
        }

        public RelayCommand Lekar
        {
            get { return lekar; }
            set
            {
                lekar = value;
            }
        }

        public PagePrioritetZakazivanjaVM(PagePrioritetZakazivanja page)
        {
            this.page = page;

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Datum = new RelayCommand(Executed_Datum, CanExecute_NavigateCommand);
            this.Lekar = new RelayCommand(Executed_Lekar, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageTerminiSekretar());
        }

        public void Executed_Datum(object obj)
        {
            page.NavigationService.Navigate(new PageDatum());
        }

        public void Executed_Lekar(object obj)
        {
            page.NavigationService.Navigate(new PageLekar());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
