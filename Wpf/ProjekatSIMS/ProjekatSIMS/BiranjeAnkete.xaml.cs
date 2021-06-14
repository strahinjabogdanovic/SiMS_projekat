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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for BiranjeAnkete.xaml
    /// </summary>
    public partial class BiranjeAnkete : Page
    {
        public BiranjeAnkete()
        {
            InitializeComponent();
        }

        private void AnketaLekar_Click(object sender, RoutedEventArgs e)
        {
            LekarAnketa la = new LekarAnketa();
            la.ShowDialog();
        }

        private void AnketaBolnica_Click(object sender, RoutedEventArgs e)
        {
            BolnicaAnketa ba = new BolnicaAnketa();
            ba.ShowDialog();
        }
    }
}
