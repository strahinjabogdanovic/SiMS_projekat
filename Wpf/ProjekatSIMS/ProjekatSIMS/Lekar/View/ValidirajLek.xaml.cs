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
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for ValidirajLek.xaml
    /// </summary>
    public partial class ValidirajLek : Page
    {
        private ValidirajLekVM viewModel;

        public ValidirajLek(Lek lek)
        {
            InitializeComponent();

            viewModel = new ValidirajLekVM(this, lek);
            DataContext = viewModel;
        }
    }
}
