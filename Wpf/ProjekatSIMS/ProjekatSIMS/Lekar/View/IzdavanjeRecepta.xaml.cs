using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for IzdavanjeRecepta.xaml
    /// </summary>
    public partial class IzdavanjeRecepta : Window
    {

        public IzdavanjeRecepta(string tb)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.IzdavanjeReceptaVM(tb);
        }

    }
}