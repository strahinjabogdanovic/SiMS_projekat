using ProjekatSIMS;
using ProjekatSIMS.Package1;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Package1
{
   public class PacijentFileStorage
   {
        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get;
            set;
        }

        public void Kreiraj(string lekar, string tb, string tb1)
      {
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            string slj = "";


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
                sw.WriteLine(tb + "/" + tb1 + "/" + slj + "/" + doktor + "/" + id);


            }
            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");



            //Close();
            PacijentPocetnaStranica s = new PacijentPocetnaStranica();
            s.ShowDialog();
        }
      
      public void Obrisi(TerminiPacijenata k)
      {
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
      
      public Pacijent Prikazi()
      {
         // TODO: implement
         return null;
      }
      
      public void Update(DataGrid dataGridPacijenti)
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