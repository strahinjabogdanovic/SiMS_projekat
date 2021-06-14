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
using ProjekatSIMS.Upravnik.ViewModel;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class UpravnikPage : Page
    {
        private UpravnikPageVM viewModel;
        public UpravnikPage()
        {
            InitializeComponent();
            this.viewModel = new UpravnikPageVM(this, dataGridProstorije);
            this.DataContext = this.viewModel;
        }
    }
}
