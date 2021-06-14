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
    /// Interaction logic for IzvestajView.xaml
    /// </summary>
    public partial class IzvestajView : Window
    {
        private IzvestajViewModel viewModel;

        public IzvestajView()
        {
            InitializeComponent();
            viewModel = new IzvestajViewModel();
            this.DataContext = viewModel;
        }
    }
}
