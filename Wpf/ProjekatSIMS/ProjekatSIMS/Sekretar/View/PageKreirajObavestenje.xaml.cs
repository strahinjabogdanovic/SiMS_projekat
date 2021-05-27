using System;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageKreirajObavestenje : Page
    {
        private PageKreirajObavestenjeVM viewModel;

        public PageKreirajObavestenje()
        {
            InitializeComponent();
            //this.viewModel = new PageKreirajObavestenjeVM(this);
            //this.DataContext = this.viewModel;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageObavestenjaSekretar());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjaKontroler ok = new ObavestenjaKontroler();

            string naziv = textBox.Text;
            string sadrzaj = textBox1.Text;
            string uloga = textBox3.Text;
            string datum = myDatePicker.ToString();
            String[] termin = datum.Split(' ');
            String[] termin1 = termin[0].Split('-');
            string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";
            string obavestenje = (naziv + "/" + sadrzaj + "/" + datum1 + "/" + uloga);

            ok.Kreiraj(obavestenje);

            this.NavigationService.Navigate(new PageObavestenjaSekretar());
        }
    }
}
