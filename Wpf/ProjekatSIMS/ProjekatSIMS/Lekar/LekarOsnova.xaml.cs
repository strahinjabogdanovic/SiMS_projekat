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

namespace ProjekatSIMS.Lekar
{
    /// <summary>
    /// Interaction logic for LekarOsnova.xaml
    /// </summary>
    public partial class LekarOsnova : Window
    {
        public LekarOsnovaVM viewModel { get; set; }
        public LekarOsnova()

        {
            InitializeComponent();
            this.viewModel = new LekarOsnovaVM(this.PocetnaS.NavigationService, this);
            this.DataContext = this.viewModel;
        }
       
        public void doThings(string param)
        {
            Title = param;
        }

       
    }
}
