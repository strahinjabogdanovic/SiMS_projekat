using System.Collections.Generic;
using System.Windows;
using ProjekatSIMS.Package1.Kontroler;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class SveInfoUpravnik : Window
    {
        public SveInfoUpravnik(int currentRowIndex)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Upravnik.ViewModel.SveInfoUpravnikVM(currentRowIndex);
        }
    }
}
