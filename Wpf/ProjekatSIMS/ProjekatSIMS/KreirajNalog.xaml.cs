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
    /// Interaction logic for KreirajNalog.xaml
    /// </summary>
    public partial class KreirajNalog : Window
    {
        public ObservableCollection<Korisnik> Korisnici
        {
            get;
            set;
        }

        public KreirajNalog()
        {
            InitializeComponent();
            
        }

        Pol p;
        int ids = 0;
        private void PotvrdiNalog_Click(object sender, RoutedEventArgs e)
        {
        
       Korisnici = new ObservableCollection<Korisnik>();
            string slj = "";

            string gender = comboBox.SelectedValue.ToString();

            if (gender != null)
            {

                if (gender.Contains("Muski"))
                {
                    p = Pol.Muski;
                    slj = "Muski";

                }
                else if (gender.Contains("Zenski"))
                {
                    p = Pol.Zenski;
                    slj = "Zenski";
                }
            }


            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("podaci.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {

                    //var lastLine = File.ReadLines("podaci.txt").Last();
                    String[] termin = line.Split(' ');
                    var korisnik = new Korisnik();
                    id = int.Parse(termin[8]);
                    id++;

                    sw.WriteLine(line);

                }
                sw.WriteLine(textBox.Text + " " + textBox1.Text + " " + textBox2.Text + " " + slj + " " + textBox3.Text + " " + textBox5.Text + " " + textBox6.Text + " " + textBox7.Text + " " + id);

                
            }
            File.Delete("podaci.txt");
            File.Move(tempFile, "podaci.txt");



            Close();
            SekretarPocetnaStrana s = new SekretarPocetnaStrana();
            s.ShowDialog();

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
