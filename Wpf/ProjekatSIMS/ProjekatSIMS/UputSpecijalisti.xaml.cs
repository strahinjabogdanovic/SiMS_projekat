using ProjekatSIMS.Package1;
using System;
using System.Collections.Generic;
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
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for UputSpecijalisti.xaml
    /// </summary>
    public partial class UputSpecijalisti : Window
    {
        string jmbgP;
        string kome;
        string brKartona;
        string spec;
        string opisUputa;
        public UputSpecijalisti(string jmbg,string ime,string prezime)
        {
            InitializeComponent();

            tBlock1.Text = ime + ' ' + prezime;
            tBlock2.Text = jmbg;
            jmbgP = jmbg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            kome = tBox1.Text;
            brKartona = tBox2.Text;
            spec = tBox3.Text;
            opisUputa = tBox4.Text;
            jmbgP = tBlock2.Text;
            UputiFileStorage uput = new UputiFileStorage(jmbgP, kome, brKartona, spec, opisUputa);

            uput.Kreiraj();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            jmbgP = tBlock2.Text;
            KartonLekar karton = new KartonLekar(jmbgP);
            this.Close();
            karton.ShowDialog();
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            jmbgP = tBlock2.Text;
            spec = tBox3.Text;
            SlobodniTerminiSpecijaliste termin = new SlobodniTerminiSpecijaliste(jmbgP, spec);
            this.Close();
            termin.ShowDialog();
        }

    }
}
