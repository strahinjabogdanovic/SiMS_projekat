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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PocetnaPacijent.xaml
    /// </summary>
    public partial class PocetnaPacijent : Window
    {
        public PocetnaPacijent()
        {
            InitializeComponent();
        }

        private void Termini_Click_1(object sender, RoutedEventArgs e)
        {
            PacijentPocetnaStranica pps = new PacijentPocetnaStranica();
            pps.ShowDialog();
        }

        private void Anketa_Click(object sender, RoutedEventArgs e)
        {
            Ankete a = new Ankete();
            a.ShowDialog();
        }

        private void Recepti_Click(object sender, RoutedEventArgs e)
        {
            ReceptiPacijent rp = new ReceptiPacijent();
            rp.ShowDialog();
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Izmena_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tutorial_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}