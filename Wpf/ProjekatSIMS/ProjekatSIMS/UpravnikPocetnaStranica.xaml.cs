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
    /// Interaction logic for UpravnikPocetnaStranica.xaml
    /// </summary>
    public partial class UpravnikPocetnaStranica : Window
    {
        private readonly string filePath;

        public ObservableCollection<Prostorije> Prostorije
        {
            get;
            set;
        }

        public UpravnikPocetnaStranica()
        {
            filePath = "prostorije.txt";
            Prostorije = new ObservableCollection<Prostorije>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var prostorije = new Prostorije();
                prostorije.ime = termin[0].ToString();
                prostorije.oznaka = termin[1].ToString();
                prostorije.namena = termin[2].ToString();
                prostorije.oprema = termin[3].ToString();


                Prostorije.Add(prostorije);


            }

            InitializeComponent();

            this.DataContext = this;

            StreamReader sr = new StreamReader("prostorije.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();


        }

        private void KreirajProstoriju_Click(object sender, RoutedEventArgs e)
        {
            KreirajProstoriju kp = new KreirajProstoriju();
            kp.ShowDialog();
        }

        private void ObrisiProstoriju_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);
            Prostorije k = Prostorije.ElementAt(currentRowIndex);
            if (Prostorije.Count > 0)
            {
                Prostorije.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("prostorije.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Prostorije = new ObservableCollection<Prostorije>();

                    var priv = new Prostorije();

                    String[] termin = line.Split('/');

                    priv.oznaka = termin[1].ToString();

                    if (priv.oznaka != k.oznaka)
                        sw.WriteLine(line);
                }
            }

            File.Delete("prostorije.txt");
            File.Move(tempFile, "prostorije.txt");
        }

        private void IzmeniProstoriju_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("prostorije.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

               

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //id++;
                    if (id == currentRowIndex)
                    {
                        
                        String[] termin = line.Split('/');
                        var prostorija = new Prostorije();
                        



                        DataGridRow row = (DataGridRow)dataGridProstorije.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = dataGridProstorije.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = dataGridProstorije.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = dataGridProstorije.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = dataGridProstorije.Columns[3].GetCellContent(row) as TextBlock;
                        

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("prostorije.txt");
            File.Move(tempFile, "prostorije.txt");

        }

        private void PrikaziSveInfo_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);

            using (var sw = new StreamWriter("redovi1.txt"))
            {
                sw.WriteLine(currentRowIndex);
            }
            SveInfoUpravnik svu = new SveInfoUpravnik();
            svu.ShowDialog();
        }
    }
}
