using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS
{
    public partial class SekretarPocetnaStrana : Window
    {
        public SekretarPocetnaStranaVM viewModel { get; set; }
        public PageProfilVM viewM { get; set; }

        public SekretarPocetnaStrana()
        {
            InitializeComponent();
            this.viewModel = new SekretarPocetnaStranaVM(this.PocetnaS.NavigationService, this);
            this.DataContext = this.viewModel;
        }

        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            this.viewM = new PageProfilVM(this.PocetnaS.NavigationService, this);
            this.DataContext = this.viewM;
        }
    }
}
