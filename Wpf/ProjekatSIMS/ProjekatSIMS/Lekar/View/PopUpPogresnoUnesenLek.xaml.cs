using System.Windows;
using System.Windows.Input;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for PopUpPogresnoUnesenLek.xaml
    /// </summary>
    public partial class PopUpPogresnoUnesenLek : Window
    {

        Lek lekic = new Lek();
        public PopUpPogresnoUnesenLek()
        {
            InitializeComponent();
            LekoviFileStorage lekovi = new LekoviFileStorage();
            lekic=lekovi.nadjiPogresanLek();
            tBlock.Text = "Pogrešno je unesen lek " +lekic.nazivleka;

        }

        private void tBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Lekovi_U noviProzor = new Lekovi_U();
            noviProzor.ShowDialog();
        }
    }
}
