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
    /// Interaction logic for Izvestaji_o_pregledu_stanja.xaml
    /// </summary>
    public partial class Izvestaji_o_pregledu_stanja : Window
    {
        private readonly string filePath;

        public ObservableCollection<MedIzvestaj> Izvopr
        {
            get;
            set;
        }
        public Izvestaji_o_pregledu_stanja(TextBlock t2)
        {
            InitializeComponent();

            filePath = "izvestaji.txt";
            Izvopr = new ObservableCollection<MedIzvestaj>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] deo = linee.Split('/');
                var izvestaj = new MedIzvestaj();

                izvestaj.vrsta = deo[0].ToString();
                izvestaj.odeljenje = deo[1].ToString();
                izvestaj.sala = deo[2].ToString();
                izvestaj.nalaz = deo[3].ToString();
                izvestaj.kontrola = deo[4].ToString();
                izvestaj.terapija = deo[5].ToString();
                izvestaj.datum = deo[6].ToString();
                izvestaj.jmbg = deo[7].ToString();

                if (t2.Text == izvestaj.jmbg)
                {
                    Izvopr.Add(izvestaj);
                }


            }


            this.DataContext = this;

            StreamReader sr = new StreamReader("izvestaji.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

            int currentRowIndex = Izvestaji.Items.IndexOf(Izvestaji.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("izvestaji.txt"))
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
                        var izvestaj = new MedIzvestaj();
                        string jmbg = termin[7].ToString();
                        string odeljenje = termin[1].ToString();
                        string vrsta = termin[0].ToString();

                        string sala = termin[2].ToString();
                        string nalaz = termin[3].ToString();
                        string kontrola = termin[4].ToString();
                        string terapija = termin[5].ToString();
                        string datum = termin[6].ToString();
                        DataGridRow row = (DataGridRow)Izvestaji.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = Izvestaji.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = Izvestaji.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = Izvestaji.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = Izvestaji.Columns[3].GetCellContent(row) as TextBlock;
                        TextBlock t5 = Izvestaji.Columns[4].GetCellContent(row) as TextBlock;
                        TextBlock t6 = Izvestaji.Columns[5].GetCellContent(row) as TextBlock;
                        if (vrsta == t1.Text && odeljenje == t3.Text)
                        {
                            sw.WriteLine(t1.Text + "/" + t3.Text + "/" + sala + "/" + t4.Text + "/" + t5.Text + "/" + t6.Text + "/" + datum + "/" + jmbg);
                        }
                        else
                        {

                            sw.WriteLine(line);
                        }
                    }
                    else
                    {
                        sw.WriteLine(line);
                        id++;
                    }
                }
            }
            File.Delete("izvestaji.txt");
            File.Move(tempFile, "izvestaji.txt");
        }
    }
}

