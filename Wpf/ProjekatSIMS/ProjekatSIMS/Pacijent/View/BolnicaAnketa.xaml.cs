using System;
using System.Collections.Generic;
using System.IO;
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
using ProjekatSIMS.Package1;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for BolnicaAnketa.xaml
    /// </summary>
    public partial class BolnicaAnketa : Window
    {
        private BolnicaAnketaViewModel b;

        public BolnicaAnketa()
        {
            InitializeComponent();
            b = new BolnicaAnketaViewModel(this);
            this.DataContext = b;
        }
    }

}
