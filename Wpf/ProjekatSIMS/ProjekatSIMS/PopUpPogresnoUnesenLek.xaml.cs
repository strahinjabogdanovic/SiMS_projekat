using Package1;
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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS
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
