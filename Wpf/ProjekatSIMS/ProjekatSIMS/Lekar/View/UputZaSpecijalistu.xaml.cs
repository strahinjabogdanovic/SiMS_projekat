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
    /// Interaction logic for UputZaSpecijalistu.xaml
    /// </summary>
    public partial class UputZaSpecijalistu : Page
    {
        private UputZaSpecijalistuVM viewModel;
        public UputZaSpecijalistu(string jmbg)
        {
            InitializeComponent();
            viewModel = new UputZaSpecijalistuVM(this, jmbg);
            DataContext = viewModel;
        }
        public UputZaSpecijalistu(string imeIprezime, string jmbg)
        {
            InitializeComponent();
            viewModel = new UputZaSpecijalistuVM(this, imeIprezime, jmbg);
            DataContext = viewModel;
        }
    }
}
