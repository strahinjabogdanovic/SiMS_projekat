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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjekatSIMS.Lekar;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Upravnik;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ILogin loginInterface;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginServis lg = new LoginServis(loginInterface);
            lg.log(textBox.Text, textBox1.Text);
        }
    }
}
