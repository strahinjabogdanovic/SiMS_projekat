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
    /// Interaction logic for LekarPocetna.xaml
    /// </summary>
    public partial class LekarPocetna : Page
    {
        private LekarPocetnaVM viewModel;

        public LekarPocetna()
        {
            InitializeComponent();

            this.viewModel = new LekarPocetnaVM(this, dataGridLekar);
            this.DataContext = this.viewModel;


        }

        private void logout_KeyUp(object sender, KeyEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }

            mainWindow.ShowDialog();
        }

        private void logout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.ShowDialog();
        }
    }
}
