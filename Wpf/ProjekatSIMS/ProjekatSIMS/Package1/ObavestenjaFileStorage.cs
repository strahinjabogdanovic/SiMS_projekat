using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Package1
{
   public class ObavestenjaFileStorage
   {
        public ObservableCollection<Obavestenja> Obavesti
        {
            get;
            set;
        }

        public void Kreiraj(string tb, string tb1, string tb2, string tb3)
      {
            Obavesti = new ObservableCollection<Obavestenja>();

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("obavestenja.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                //int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    var obavestenja = new Obavestenja();
                    //id = int.Parse(termin[8]);
                    //id++;

                    sw.WriteLine(line);

                }
                sw.WriteLine(tb + "/" + tb1 + "/" + tb2 + "/" + tb3);


            }
            File.Delete("obavestenja.txt");
            File.Move(tempFile, "obavestenja.txt");
        }
      
      public void Obrisi(Obavestenja k)
      {
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("obavestenja.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Obavesti = new ObservableCollection<Obavestenja>();

                    var priv = new Obavestenja();

                    String[] termin = line.Split('/');
                    
                    priv.sadrzaj = termin[1].ToString();


                    if (priv.sadrzaj != k.sadrzaj)
                        sw.WriteLine(line);
                    
                }
            }

            File.Delete("obavestenja.txt");
            File.Move(tempFile, "obavestenja.txt");
        }
      
      public void Prikazi()
      {
         // TODO: implement
      }
      
      public void Update(DataGrid dataGridObavestenja)
      {
            int currentRowIndex = dataGridObavestenja.Items.IndexOf(dataGridObavestenja.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("obavestenja.txt"))
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
                        var obavestenja = new Obavestenja();




                        DataGridRow row = (DataGridRow)dataGridObavestenja.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = dataGridObavestenja.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = dataGridObavestenja.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = dataGridObavestenja.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = dataGridObavestenja.Columns[3].GetCellContent(row) as TextBlock;

                        sw.WriteLine(t2.Text + "/" + t3.Text + "/" + t4.Text + "/" + t1.Text);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("obavestenja.txt");
            File.Move(tempFile, "obavestenja.txt");
        }
   
   }
}