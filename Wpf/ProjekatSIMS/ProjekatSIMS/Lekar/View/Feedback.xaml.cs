using ProjekatSIMS.Package1.Repozitorijum;
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

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Page
    {
        public Feedback()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String kombo = "";
            String feedback = s1.Text;
            String mail = s2.Text;

            if (cb1.Text.Contains("Dobar"))
            {
                kombo = "Dobar";
            }
            else if (cb1.Text.Contains("Neutralan"))
            {
                kombo = "Neutralan";
            }
            else
            {
                kombo = "Los";
            }
            AnketaStorage afs = new AnketaStorage();
            afs.KreirajFeedback(kombo, feedback, mail);
            MessageBox.Show("Feedback poslat upravi");
            this.NavigationService.Navigate(new LekarPocetna());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LekarPocetna());
        }
    }
}
