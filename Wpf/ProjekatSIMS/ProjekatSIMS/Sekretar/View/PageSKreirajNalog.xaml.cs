using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageSKreirajNalog : Page
    {
        /*
        public ObservableCollection<Pacijent> Korisnici
        {
            get;
            set;
        }*/
        private PageSKreirajNalogVM viewModel;

        public PageSKreirajNalog()
        {
            InitializeComponent();
            //this.viewModel = new PageSKreirajNalogVM(this);
            //this.DataContext = this.viewModel;
        }

        private void PotvrdiNalog_Click(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();

            string pol = comboBox.SelectedValue.ToString();
            string ime = textBox.Text;
            string prezime = textBox1.Text;
            string jmbg = textBox2.Text;
            string mail = textBox5.Text;
            string brojTel = textBox6.Text;
            string adresa = textBox7.Text;
            string datum = myDatePicker.ToString();
            String[] termin = datum.Split(' ');
            String[] termin1 = termin[0].Split('-');
            string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";
            string nalog = (ime + "/" + prezime + "/" + jmbg);
            string nalogNastavak = (datum1 + "/" + mail + "/" + brojTel + "/" + adresa);

            npk.Kreiraj(nalog, pol, nalogNastavak);

            this.NavigationService.Navigate(new PageSekretar());
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }
    }
}
