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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for IzmenaProfila.xaml
    /// </summary>
    public partial class IzmenaProfila : Window
    {
        private IzmenaProfilaViewModel viewModel;

        public IzmenaProfila()
        {
            InitializeComponent();
            viewModel = new IzmenaProfilaViewModel(this);
            this.DataContext = viewModel;
        }
    }
}

