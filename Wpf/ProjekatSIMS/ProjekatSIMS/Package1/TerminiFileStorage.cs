using ProjekatSIMS;
using ProjekatSIMS.Package1;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Package1
{
   public partial class TerminiFileStorage //: LekarPocetnaStranica
   {
        public ObservableCollection<TerminiPacijenata> ZakazTermina
        {
            get;
            set;
        }

        public void Kreiraj(string vt, string l, string tb, string tb1, string tb2)
      {
            ZakazTermina = new ObservableCollection<TerminiPacijenata>();
            string slj = "";
            string kfr = "";

            //string vrstaTermina = comboBox.SelectedValue.ToString();
            //string lekar = comboBox1.SelectedValue.ToString();

            if (l != null)
            {

                if (l.Contains("Jova Jovic"))
                {
                    slj = "Jova Jovic";

                }
                else if (l.Contains("Jovan Jovanovic"))
                {
                    slj = "Jovan Jovanovic";
                }
            }

            if (vt != null)
            {

                if (vt.Contains("Pregled"))
                {
                    kfr = "Pregled";

                }
                else if (vt.Contains("Operacija"))
                {
                    kfr = "Operacija";
                }
            }


            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekar.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    var lekari = new TerminiPacijenata();
                    id = int.Parse(termin[5]);
                    id++;

                    sw.WriteLine(line);

                }

                sw.WriteLine(kfr + "/" + tb + "/" + tb1 + "/" + tb2 + "/" + slj + "/" + id);


            }
            File.Delete("lekar.txt");
            File.Move(tempFile, "lekar.txt");



            //this.Close();
            LekarPocetnaStranica s = new LekarPocetnaStranica();
            s.ShowDialog();
        }
      
      public void Obrisi(TerminiPacijenata k)
      {
            
            //int currentRowIndex = dg.Items.IndexOf(dg.SelectedItem);
            //TerminiPacijenata k = ZakazTermina.ElementAt(currentRowIndex);
           // if (ZakazTermina.Count > 0)
           // {
           //     ZakazTermina.RemoveAt(currentRowIndex);
           // }
           // else
           // {
           ///     MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
           // }



            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekar.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    ZakazTermina = new ObservableCollection<TerminiPacijenata>();

                    var priv = new TerminiPacijenata();

                    String[] termin = line.Split('/');

                    priv.id = int.Parse(termin[5].ToString());


                    if (priv.id != k.id)
                        sw.WriteLine(line);
                }
            }

            File.Delete("lekar.txt");
            File.Move(tempFile, "lekar.txt");
            
        }
      
      public TerminiPacijenata Prikazi()
      {
         // TODO: implement
         return null;
      }
      
      public void Update(DataGrid dataGridLekar)
      {
            int currentRowIndex = dataGridLekar.Items.IndexOf(dataGridLekar.SelectedItem);

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

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/" + t5.Text + "/" + termin[5]);
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
        }
   
   }
}