using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageLekarVM : ViewModels
    {
        private RelayCommand nazad;
        private RelayCommand potvrdi;

        private ComboBox kombo;

        public ComboBox Kombo
        {
            get { return kombo; }
            set
            {
                if (kombo != value)
                {
                    kombo = value;
                    OnPropertyChanged("Kombo");
                }
            }
        }

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

        private PageLekar page;
        string doktor = "";

        public PageLekarVM(PageLekar page, string lekar)
        {
            this.page = page;
            doktor = lekar;

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Potvrdi = new RelayCommand(Executed_Potvrdi, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PagePrioritetZakazivanja());
        }

        public void Executed_Potvrdi(object obj)
        {
            //string lekar = comboBox.SelectedValue.ToString();
            page.NavigationService.Navigate(new PageZakazivanjeLekar(doktor));
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
