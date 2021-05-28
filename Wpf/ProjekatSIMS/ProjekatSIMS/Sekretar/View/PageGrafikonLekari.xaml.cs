using ProjekatSIMS.Sekretar.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageGrafikonLekari : Page
    {
        private PageGrafikonLekariVM viewModel;

        public PageGrafikonLekari()
        {
            InitializeComponent();
            this.viewModel = new PageGrafikonLekariVM(this, mainCanvas, detailsItemsControl);
            this.DataContext = this.viewModel;

        }
    }
}
