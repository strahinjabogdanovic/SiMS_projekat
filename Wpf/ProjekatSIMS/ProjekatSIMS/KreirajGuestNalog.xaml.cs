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
    /// Interaction logic for KreirajGuestNalog.xaml
    /// </summary>
    public partial class KreirajGuestNalog : Window
    {
        public ObservableCollection<GuestNalog> Guest
        {
            get;
            set;
        }

        public KreirajGuestNalog()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Guest = new ObservableCollection<GuestNalog>();
           

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("guestnalozi.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                //int id = 0;
                while ((line = sr.ReadLine()) != null)
                {

                    String[] termin = line.Split(' ');
                    var guest = new GuestNalog();
                    //id = int.Parse(termin[8]);
                    //id++;

                    sw.WriteLine(line);

                }
                sw.WriteLine(textBox.Text + " " + textBox1.Text + " " + textBox2.Text);


            }
            File.Delete("guestnalozi.txt");
            File.Move(tempFile, "guestnalozi.txt");



            Close();
            GuestNalozi s = new GuestNalozi();
            s.ShowDialog();
        }
    }
}
