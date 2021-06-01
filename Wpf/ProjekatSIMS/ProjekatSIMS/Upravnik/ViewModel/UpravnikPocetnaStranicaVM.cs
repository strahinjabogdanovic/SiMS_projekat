using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.View;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class UpravnikPocetnaStranicaVM : BindableBase
    {
        private NavigationService navigationService;
        private Window window { get; set; }

        public UpravnikPocetnaStranicaVM(NavigationService navigationService, Window window)
        {
            this.navigationService = navigationService;
            this.window = window;
            this.navigationService.Navigate(new UpravnikPage());
        }
    }
}
