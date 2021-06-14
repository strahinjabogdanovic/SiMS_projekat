using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Upravnik.ViewModel;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class UpravnikPocetnaStranica : Window
    {
        public UpravnikPocetnaStranicaVM viewModel { get; set; }
        public LekoviPageVM viewM { get; set; }
        public UpravnikPocetnaStranica()
        {

            InitializeComponent();
            this.viewModel = new UpravnikPocetnaStranicaVM(this.PocetnaS.NavigationService, this);
            this.DataContext = this.viewModel;


            /*LekoviFileStorage lfs = new LekoviFileStorage();
            bool imaPogresnihLekova = lfs.proveriPogresneLekove();
            if (imaPogresnihLekova == true)
            {
                PopUpPogresnoUnesenLek pu = new PopUpPogresnoUnesenLek();
                pu.ShowDialog();
            }*/

        }

        private void lekovi_click(object sender, RoutedEventArgs e)
        {
            this.viewM = new LekoviPageVM(this.PocetnaS.NavigationService, this);
            this.DataContext = this.viewM;
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel = new UpravnikPocetnaStranicaVM(this.PocetnaS.NavigationService, this);
            this.DataContext = this.viewModel;
        }
    }
}
