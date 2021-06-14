using ProjekatSIMS.Sekretar.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageDatum : Page
    {
        private PageDatumVM viewModel;

        public PageDatum()
        {
            InitializeComponent();
            //this.viewModel = new PageDatumVM(this);
            //this.DataContext = this.viewModel;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PagePrioritetZakazivanja());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string datum = myDatePicker.ToString();
            String[] termin = datum.Split(' ');
            String[] termin1 = termin[0].Split('-');
            string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";
            this.NavigationService.Navigate(new PageZakazivanjeDatum(datum1));
        }
    }  
}
