using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for KreirajNalog.xaml
    /// </summary>
    public partial class KreirajNalog : Window
    {
        public ObservableCollection<Korisnik> Korisnici
        {
            get;
            set;
        }

        public KreirajNalog()
        {
            InitializeComponent();
            
        }

        Pol p;
        int ids = 0;
        private void PotvrdiNalog_Click(object sender, RoutedEventArgs e)
        {
        
       Korisnici = new ObservableCollection<Korisnik>();

            string gender = comboBox.SelectedValue.ToString();
            
            if (gender != null)
            {
                
                if (gender == "Muski")
                {
                    p = Pol.Muski;

                }
                else if (gender == "Zenski")
                {
                    p = Pol.Zenski;
                }
            }

            //string iDate = textBox4.Text;
            //DateTime oDate = Convert.ToDateTime(iDate);


            Korisnici.Add(new Korisnik { ime = textBox.Text, prezime = textBox1.Text, jmbg = long.Parse(textBox2.Text), pol = p , datumRodjenja = textBox3.Text, email = textBox5.Text, brojTelefona = textBox6.Text, adresa = textBox7.Text , idKorisnika = ++ids});

            
            Close();
            SekretarPocetnaStrana s = new SekretarPocetnaStrana();
            s.ShowDialog();

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
