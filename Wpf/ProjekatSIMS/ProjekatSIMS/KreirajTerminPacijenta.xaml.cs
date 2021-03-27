using ProjekatSIMS.Package1;
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
    /// Interaction logic for KreirajTerminPacijenta.xaml
    /// </summary>
    public partial class KreirajTerminPacijenta : Window
    {
        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        public KreirajTerminPacijenta()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            string slj = "";

            string lekar = comboBox.SelectedValue.ToString();
            
            if (lekar != null)
            {

                if (lekar.Contains("Jova Jovic"))
                { 
                    slj = "Jova Jovic";

                }
                else if (lekar.Contains("Jovan Jovanovic"))
                {
                    slj = "Jovan Jovanovic";
                }
            }


            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    var pacijent = new TerminiPacijenata();
                    id = int.Parse(termin[4]);
                    id++;

                    sw.WriteLine(line);

                }
                string doktor = "";
                using (var sars = new StreamReader("doktori.txt"))
                {
                    string lines;
                    while ((line = sars.ReadLine()) != null)
                    {
                        String[] termin = line.Split('/');
                        lines = termin[0];
                        if (lines == slj)
                        {
                            doktor = termin[1];
                        }

                    }
                }
                    sw.WriteLine(textBox.Text + "/" + textBox1.Text + "/" + slj + "/" + doktor + "/" + id);
                

            }
            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");



            Close();
            PacijentPocetnaStranica s = new PacijentPocetnaStranica();
            s.ShowDialog();

        }
    }
}
