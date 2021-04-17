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

    public partial class Stvari : Window
    {
        private readonly string filePath;

        public ObservableCollection<Oprema> Oprema
        {
            get;
            set;
        }
        public Stvari()
        {
            {
                InitializeComponent();
                filePath = "prostorije.txt";
                Oprema = new ObservableCollection<Oprema>();
                List<String> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();

                int currentRowIndex = 0;

                using (var rsr = new StreamReader("redopreme.txt"))
                {

                    String sdfg = "";

                    sdfg = rsr.ReadLine();
                    currentRowIndex = int.Parse(sdfg);
                }


                int idp = 0;
                foreach (string linee in lines)
                {

                    if (idp == currentRowIndex)
                    {

                        String[] termin = linee.Split('/');

                        String sala = termin[0];
                        t1.Text = sala;

                        String opreman = termin[3];
                        String[] priv = opreman.Split(',');

                        int s = priv.Length;

                        String kolic = termin[4];
                        String[] kolii = kolic.Split(',');

                        for (int i = 0; i < s; i++)
                        {
                            var oprema = new Oprema();
                            oprema.opreme = priv[i];
                            oprema.kolicina = kolii[i];
                            Oprema.Add(oprema);
                        }
                    }
                    idp++;
                }

                

                this.DataContext = this;

                /* StreamReader sr = new StreamReader("oprema.txt");
                 string line = "";

                 while ((line = sr.ReadLine()) != null)
                 {
                     string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                 }
                 sr.Close();*/
            }
        }

        private void dodaj_opremu_click(object sender, RoutedEventArgs e)
        {
            DodajOpremu d = new DodajOpremu();
            d.ShowDialog();
        }

        private void obrisi_opremu_click(object sender, RoutedEventArgs e)
        {
            OpremaFileStorage p = new OpremaFileStorage();
            int currentRowIndex = dataGridOprema.Items.IndexOf(dataGridOprema.SelectedItem);

            using (var sw = new StreamWriter("redopreme1.txt"))
            {
                sw.WriteLine(currentRowIndex);
            }
            
            Oprema k = Oprema.ElementAt(currentRowIndex);
            if (Oprema.Count > 0)
            {
                Oprema.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            p.Obrisi(k);


        }

        private void izmeni_opremu_click(object sender, RoutedEventArgs e)
        {
            OpremaFileStorage o = new OpremaFileStorage();
            o.Update(dataGridOprema);
        }
    }
}
