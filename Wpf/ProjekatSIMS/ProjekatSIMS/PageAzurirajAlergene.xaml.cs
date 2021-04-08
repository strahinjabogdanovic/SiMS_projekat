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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PageAzurirajAlergene.xaml
    /// </summary>
    public partial class PageAzurirajAlergene : Page
    {
        public PageAzurirajAlergene()
        {
            InitializeComponent();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageMedKarton());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = 0;
 
            using (var sr = new StreamReader("redovi.txt"))
            {

                String line = "";

                line = sr.ReadLine();
                currentRowIndex = int.Parse(line);
            }

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("medKarton.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                int idx = 0;

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //id++;
                    if (id == currentRowIndex)
                    {

                        String[] termin = line.Split('/');


                        sw.WriteLine(termin[0] + "/" + textBox.Text);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("medKarton.txt");
            File.Move(tempFile, "medKarton.txt");

            this.NavigationService.Navigate(new PageMedKarton());
        }
    }
}
