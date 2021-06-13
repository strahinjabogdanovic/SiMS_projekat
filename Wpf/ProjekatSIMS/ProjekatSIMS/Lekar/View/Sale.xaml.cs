using ProjekatSIMS.Lekar.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for Sale.xaml
    /// </summary>
    public partial class Sale : Page
    {
        private SaleVM viewModel;
        public Sale(string ime, string prezime, string jmbg)
        {
            InitializeComponent();
            this.viewModel = new SaleVM(this, dataGridProstorije, ime, prezime, jmbg);
            DataContext = viewModel;
        }
    }
}
