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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for Anamneza.xaml
    /// </summary>
    public partial class Anamneza : Window
    {
        public Anamneza(String tJmbg)
        {
            InitializeComponent();
           // this.DataContext = new ProjekatSIMS.Lekar.ViewModel.Izvestaji_o_pregledu_stanjaVM(tJmbg, Anamneze);
        }

        private void Beleska_Click(object sender, RoutedEventArgs e)
        {
            StareBeleske sb = new StareBeleske();
            sb.ShowDialog();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("beleske.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {

                    sw.WriteLine(line);

                }

                sw.WriteLine(tb.Text);


            }
            File.Delete("beleske.txt");
            File.Move(tempFile, "beleske.txt");

            this.Close();
        }

        private void Podsetnik_Click(object sender, RoutedEventArgs e)
        {
            Podsetnik p = new Podsetnik();
            p.ShowDialog();
        }
    }
}
