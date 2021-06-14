using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageProfilVM : ViewModels
    {
        private NavigationService navigationService;
        private Window window { get; set; }

        public PageProfilVM(NavigationService navigationService, Window window)
        {
            this.navigationService = navigationService;
            this.window = window;
            this.navigationService.Navigate(new PageProfil());
        }
    }
}
