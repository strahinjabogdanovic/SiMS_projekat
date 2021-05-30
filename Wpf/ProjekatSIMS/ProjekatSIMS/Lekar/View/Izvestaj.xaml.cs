using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for Izvestaj.xaml
    /// </summary>
    public partial class Izvestaj : Window
    {
        private string tIme;
        private string tPrezime;
        private string tJmbg;

        public Izvestaj()
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.IzvestajVM();
        }

        public Izvestaj(TextBlock td, TextBlock td1, TextBlock td2)
        {
            InitializeComponent();

            string ime = td.Text;
            t.Text = ime;
            string prezime = td1.Text;
            t1.Text = prezime;
            string jmbg = td2.Text;
            t2.Text = jmbg;
            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.IzvestajVM(ime, prezime, jmbg);
        }

        public Izvestaj(string ime, string prezime, string jmbg)
        {
            InitializeComponent();

            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.IzvestajVM(ime, prezime, jmbg);

        }
    }
}