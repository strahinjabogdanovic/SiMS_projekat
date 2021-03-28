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
    /// Interaction logic for PacijentPocetnaStranica.xaml
    /// </summary>
    public partial class PacijentPocetnaStranica : Window
    {
        private readonly string filePath;

        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }


        public PacijentPocetnaStranica()
        {
            filePath = "termini.txt";
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var pacijent = new TerminiPacijenata();
                pacijent.datum = termin[0].ToString();
                pacijent.vreme = termin[1].ToString();
                pacijent.lekar = termin[2].ToString();
                pacijent.soba = termin[3].ToString();
                pacijent.id = int.Parse(termin[4].ToString());
                TerminiP.Add(pacijent);


            }


            InitializeComponent();
            this.DataContext = this;

            StreamReader sr = new StreamReader("termini.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }

        private void KreirajTermin_Click(object sender, RoutedEventArgs e)
        {
            KreirajTerminPacijenta k = new KreirajTerminPacijenta();
            k.ShowDialog();
        }

        private void ObrisiTermin_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridPacijenti.Items.IndexOf(dataGridPacijenti.SelectedItem);
            TerminiPacijenata k = TerminiP.ElementAt(currentRowIndex);
            if (TerminiP.Count > 0)
            {
                TerminiP.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    TerminiP = new ObservableCollection<TerminiPacijenata>();

                    var priv = new TerminiPacijenata();

                    String[] termin = line.Split('/');
                    priv.id = int.Parse(termin[4].ToString());


                    if (priv.id != k.id)
                        sw.WriteLine(line);
                }
            }

            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridPacijenti.Items.IndexOf(dataGridPacijenti.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("termini.txt"))
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
                        var pacijent = new TerminiPacijenata();
                        idx = int.Parse(termin[4]);

                        DataGridRow row = (DataGridRow)dataGridPacijenti.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = dataGridPacijenti.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = dataGridPacijenti.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = dataGridPacijenti.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = dataGridPacijenti.Columns[3].GetCellContent(row) as TextBlock;
                        

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/" + idx);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");
        }
    }
}
