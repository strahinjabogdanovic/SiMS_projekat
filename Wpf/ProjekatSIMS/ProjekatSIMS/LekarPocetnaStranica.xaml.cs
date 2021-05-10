using Package1;
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
    /// Interaction logic for LekarPocetnaStranica.xaml
    /// </summary>
    public partial class LekarPocetnaStranica : Window
    {
        private readonly string filePath;

        public ObservableCollection<TerminiPacijenata> ZakazTermina
        {
            get;
            set;
        }

        public LekarPocetnaStranica()
        {
            filePath = "lekar.txt";
            ZakazTermina = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var lekar = new TerminiPacijenata();
                if (termin[0].ToString() != null)
                {

                    if (termin[0].ToString() == "Pregled")
                    {
                        lekar.vrstaTermina = Termin.Pregled;

                    }
                    else if (termin[0].ToString() == "Operacija")
                    {
                        lekar.vrstaTermina = Termin.Operacija;
                    }
                }

                lekar.datum = termin[1].ToString();
                lekar.vreme = termin[2].ToString();
                lekar.soba = termin[3].ToString();
                lekar.lekar = termin[4].ToString();
                lekar.id = int.Parse(termin[5].ToString());
                lekar.jmbg = termin[6].ToString();
                ZakazTermina.Add(lekar);


            }


            InitializeComponent();
            this.DataContext = this;

            StreamReader sr = new StreamReader("lekar.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            KreirajTerminLekar k = new KreirajTerminLekar();
            if (dataGridLekar.SelectedItem != null)
            {
                int currentRowIndex = dataGridLekar.Items.IndexOf(dataGridLekar.SelectedItem);

                DataGridRow row = (DataGridRow)dataGridLekar.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                TextBlock t5 = dataGridLekar.Columns[5].GetCellContent(row) as TextBlock;
                string jmbg = t5.Text;

                k = new KreirajTerminLekar(jmbg);
            }
                k.ShowDialog();
        }


        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            TerminiFileStorage t = new TerminiFileStorage();
            t.Update(dataGridLekar);
            //int currentRowIndex = dataGridLekar.Items.IndexOf(dataGridLekar.SelectedItem);

            /*
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekar.txt"))
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
                        var lekar = new TerminiPacijenata();


                        DataGridRow row = (DataGridRow)dataGridLekar.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = dataGridLekar.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = dataGridLekar.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = dataGridLekar.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = dataGridLekar.Columns[3].GetCellContent(row) as TextBlock;
                        TextBlock t5 = dataGridLekar.Columns[4].GetCellContent(row) as TextBlock;

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/" + t5.Text + "/" + id);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("lekar.txt");
            File.Move(tempFile, "lekar.txt");
            */
        }

        private void Karton_Click(object sender, RoutedEventArgs e)
        {
            KartonLekar kl = new KartonLekar(dataGridLekar);
            this.Close();
            kl.ShowDialog();
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            ZahteviZaValidaciju z = new ZahteviZaValidaciju();
            this.Close();
            z.ShowDialog();
        }
        private void logout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TerminiFileStorage tf = new TerminiFileStorage();
            int currentRowIndex = dataGridLekar.Items.IndexOf(dataGridLekar.SelectedItem);
            TerminiPacijenata k = ZakazTermina.ElementAt(currentRowIndex);
            if (ZakazTermina.Count > 0)
            {
                ZakazTermina.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            tf.Obrisi(k);

        }

        private void button3_MouseEnter(object sender, MouseEventArgs e)
        {
            klikni.Visibility = Visibility.Visible;
            klikniLab.Visibility = Visibility.Visible;
        }

        private void button3_MouseLeave(object sender, MouseEventArgs e)
        {
            klikni.Visibility = Visibility.Hidden;
            klikniLab.Visibility = Visibility.Hidden;
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            izaberi.Visibility = Visibility.Visible;
            izaberiLab.Visibility = Visibility.Visible;
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            izaberi.Visibility = Visibility.Hidden;
            izaberiLab.Visibility = Visibility.Hidden;
        }
    }
}
