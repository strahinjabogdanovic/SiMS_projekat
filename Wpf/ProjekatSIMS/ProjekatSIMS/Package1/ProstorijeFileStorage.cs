using ProjekatSIMS;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Package1
{
   public class ProstorijeFileStorage
   {
        public ObservableCollection<Prostorije> Prostorije
        {
            get;
            set;
        }

        public void Kreiraj(string tb, string tb1, string tb2, string tb3)
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
                sw.WriteLine(tb + "/" + tb1 + "/" + tb2 + "/" + tb3);


            }
            File.Delete("prostorije.txt");
            File.Move(tempFile, "prostorije.txt");



            //Close();
            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }
      
      public void Obrisi(Prostorije k)
      {
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
      
      public void Prikazi(DataGrid dataGridProstorije)
      {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);

            using (var sw = new StreamWriter("redovi1.txt"))
            {
                sw.WriteLine(currentRowIndex);
            }
            SveInfoUpravnik svu = new SveInfoUpravnik();
            svu.ShowDialog();

        }
      
      public void Update(DataGrid dataGridProstorije)
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
   
   }
}