using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for KreirajProstoriju.xaml
    /// </summary>
    public partial class KreirajProstoriju : Window
    {
        public ObservableCollection<Prostorije> Prostorije
        {
            get;
            set;
        } 

        public KreirajProstoriju()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Prostorije = new ObservableCollection<Prostorije>();

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("prostorije.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    String[] termin = line.Split('/');
                    var prostorije = new Prostorije();

                    sw.WriteLine(line);

                }
                sw.WriteLine(textBox.Text + "/" + textBox1.Text + "/" + textBox2.Text + "/" + textBox3.Text);


            }
            File.Delete("prostorije.txt");
            File.Move(tempFile, "prostorije.txt");



            Close();
            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }
    }
}
