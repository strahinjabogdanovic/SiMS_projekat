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
    /// Interaction logic for Ankete.xaml
    /// </summary>
    public partial class Ankete : Window
    {
        public Ankete()
        {
            InitializeComponent();
        }

        private void LekarAnketa_Click(object sender, RoutedEventArgs e)
        {
            LekarAnketa la = new LekarAnketa();
            la.ShowDialog();
        }

        private void BolnicaAnketa_Click(object sender, RoutedEventArgs e)
        {
            BolnicaAnketa ba = new BolnicaAnketa();
            ba.ShowDialog();
        }
    }
}

