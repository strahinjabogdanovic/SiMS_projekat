using ProjekatSIMS.Sekretar.ViewModel;
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

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageAntiTrol : Page
    {
        private PageAntiTrolVM viewModel;

        public PageAntiTrol()
        {
            InitializeComponent();
            this.viewModel = new PageAntiTrolVM(this, dataGridAntiTrol);
            this.DataContext = this.viewModel;
        }
    }
}
