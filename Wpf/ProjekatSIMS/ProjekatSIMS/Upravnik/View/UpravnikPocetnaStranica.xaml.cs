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
        public UpravnikPocetnaStranica()
        {

            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Upravnik.ViewModel.UpravnikPocetnaStranicaVM(dataGridProstorije);


            /*LekoviFileStorage lfs = new LekoviFileStorage();
            bool imaPogresnihLekova = lfs.proveriPogresneLekove();
            if (imaPogresnihLekova == true)
            {
                PopUpPogresnoUnesenLek pu = new PopUpPogresnoUnesenLek();
                pu.ShowDialog();
            }*/

        }
    }
}
