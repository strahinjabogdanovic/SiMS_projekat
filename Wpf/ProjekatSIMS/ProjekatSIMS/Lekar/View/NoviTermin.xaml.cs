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

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for NoviTermin.xaml
    /// </summary>
    public partial class NoviTermin : Page
    {
        private NoviTerminVM viewModel;

        public NoviTermin()
        {
            InitializeComponent();
            this.viewModel = new NoviTerminVM(this);
            this.DataContext = this.viewModel;
        }
        public NoviTermin(string jmbg)
        {
            InitializeComponent();
            this.viewModel = new NoviTerminVM(this, jmbg);
            this.DataContext = this.viewModel;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string vreme = textBox1.Text;
            if (vreme.Contains(':'))
            {
                string[] deo = vreme.Split(':');
                int n;
                int b;
                bool isNumeric = int.TryParse(deo[0], out n) & int.TryParse(deo[1], out b);
                if (isNumeric == true)
                {
                    upozorenje.Text = "";
                }
            }
            else
            {
                upozorenje.Text = "Vreme mora biti u formatu 00:00";
            }
        }
    }
}
