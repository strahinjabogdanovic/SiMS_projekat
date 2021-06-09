using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Lekar.ViewModel;

namespace ProjekatSIMS.Lekar
{
    public class LekarOsnovaVM : ViewModels
    {
        public NavigationService navigationService;
        public Window window { get; set; }

        public LekarOsnovaVM(NavigationService navigationService, Window window)
        {
            this.navigationService = navigationService;
            this.window = window;
            this.navigationService.Navigate(new LekarPocetna());
        }

    }
}
