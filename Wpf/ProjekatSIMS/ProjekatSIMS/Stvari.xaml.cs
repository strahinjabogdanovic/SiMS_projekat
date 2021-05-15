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
        int redProstorije = 0;
        public ObservableCollection<Oprema> Oprema
        {
            get;
            set;
        }
        public Stvari(int currentRowIndex)
        {
            redProstorije = currentRowIndex;
            {
                InitializeComponent();

                Oprema = new ObservableCollection<Oprema>();

                List<string> prostorije = new List<string>();
                prostorije = File.ReadAllLines("prostorije.txt").ToList();

                int idp = 0;
                foreach (string red in prostorije)
                {
                    if (idp == currentRowIndex)
                    {
                        string[] termin = red.Split('/');

                        string sala = termin[0];
                        t1.Text = sala;

                        string opreman = termin[3];
                        string[] priv = opreman.Split(',');
                        int s = priv.Length;

                        string kolic = termin[4];
                        string[] kolii = kolic.Split(',');

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
            }
        }

        private void dodaj_opremu_click(object sender, RoutedEventArgs e)
        {
            DodajOpremu d = new DodajOpremu(redProstorije);
            d.ShowDialog();
        }

        private void obrisi_opremu_click(object sender, RoutedEventArgs e)
        {
            OpremaFileStorage p = new OpremaFileStorage();
            int currentRowIndexO = dataGridOprema.Items.IndexOf(dataGridOprema.SelectedItem);
            
            if (Oprema.Count > 0)
            {
                Oprema.RemoveAt(currentRowIndexO);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            p.Obrisi(redProstorije, currentRowIndexO);


        }

        private void izmeni_opremu_click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridOprema.Items.IndexOf(dataGridOprema.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridOprema.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock t1 = dataGridOprema.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock t2 = dataGridOprema.Columns[1].GetCellContent(row) as TextBlock;

            OpremaFileStorage o = new OpremaFileStorage();
            o.Update(redProstorije, currentRowIndex, t1.Text, t2.Text);
        }
    }
}
