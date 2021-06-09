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
using ProjekatSIMS.Lekar.ViewModel;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for KartonPacijenta.xaml
    /// </summary>
    public partial class KartonPacijenta : Page
    {
        private KartonPacijentaVM viewModel;
        public KartonPacijenta(string jmbg)
        {
            InitializeComponent();

            this.viewModel = new KartonPacijentaVM(this, jmbg);
            this.DataContext = this.viewModel;

        }
    }
}
