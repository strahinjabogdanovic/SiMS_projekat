using ProjekatSIMS.Sekretar.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageLekar : Page
    {
        private PageLekarVM viewModel;

        public PageLekar()
        {
            InitializeComponent();
            //this.viewModel = new PageLekarVM(this, lekar);
            //this.DataContext = this.viewModel;
        }

        
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PagePrioritetZakazivanja());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string lekar = comboBox.SelectedValue.ToString();
            this.NavigationService.Navigate(new PageZakazivanjeLekar(lekar));
        }
    }
}
