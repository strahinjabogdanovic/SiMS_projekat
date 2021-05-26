using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using ProjekatSIMS.Sekretar.View;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS
{
    public class SekretarPocetnaStranaVM : ViewModels
    {
        private NavigationService navigationService;
        private Window window { get; set; }

        public MyICommand Odjava { get; set; }

        public SekretarPocetnaStranaVM(NavigationService navigationService, Window window)
        {
            this.navigationService = navigationService;
            this.window = window;
            this.navigationService.Navigate(new PageSekretar());
        }

    }
}
