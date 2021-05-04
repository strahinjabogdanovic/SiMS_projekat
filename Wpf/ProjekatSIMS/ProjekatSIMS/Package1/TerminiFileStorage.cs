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
   public partial class TerminiFileStorage 
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


        /*
        Boolean nasao = false;
        public void ZakazivanjeSekretar(DataGrid dataGridPacijenti)
        {
            int trenutniIndeksReda = dataGridPacijenti.Items.IndexOf(dataGridPacijenti.SelectedItem);
            string privremeniFajl = System.IO.Path.GetTempFileName();

            String ime = "";

            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(privremeniFajl))
            {
                String datum = "";
                String vreme = "";
                String lekar = "";
                String soba = "";
                int idx = 0;
                int id = 0;

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] podaci = line.Split('/');

                    datum = podaci[0];
                    vreme = podaci[1];
                    lekar = podaci[2];
                    soba = podaci[3];
                    idx = int.Parse(podaci[4]);

                    DataGridRow red = (DataGridRow)dataGridPacijenti.ItemContainerGenerator.ContainerFromIndex(trenutniIndeksReda);

                    TextBlock tbPacijent = dataGridPacijenti.Columns[0].GetCellContent(red) as TextBlock;
                    TextBlock tbDatum = dataGridPacijenti.Columns[1].GetCellContent(red) as TextBlock;
                    TextBlock tbVreme = dataGridPacijenti.Columns[2].GetCellContent(red) as TextBlock;
                    TextBlock tbLekar = dataGridPacijenti.Columns[3].GetCellContent(red) as TextBlock;
                    TextBlock tbSoba = dataGridPacijenti.Columns[4].GetCellContent(red) as TextBlock;
                                        
                    using (var srr = new StreamReader("podaci.txt"))
                    {
                        string liness;
                        while ((liness = srr.ReadLine()) != null)
                        {
                            String[] termin = liness.Split('/');
                            ime = termin[0] + " " + termin[1];

                            if (tbPacijent.Text.Equals(ime))
                            {
                                nasao = true;
                            }

                        }

                    }

                    if (nasao == true)
                    {
                        if (datum.Equals(tbDatum.Text) && vreme.Equals(tbVreme.Text) && lekar.Equals(tbLekar.Text) && soba.Equals(tbSoba.Text))
                        {
                            sw.WriteLine(tbDatum.Text + "/" + tbVreme.Text + "/" + tbLekar.Text + "/" + tbSoba.Text + "/" + ++id + "/" + tbPacijent.Text);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                        id = idx;
                    }
                    else
                    {
                        MessageBox.Show("Pacijent ne postoji u sistemu");
                        sw.WriteLine(line);
                        while ((line = sr.ReadLine()) != null)
                        {
                            sw.WriteLine(line);
                        }

                    }
 
                  }

              }
              File.Delete("termini.txt");
              File.Move(privremeniFajl, "termini.txt");
        }*/


        Boolean nasao = false;
        public void ZakazivanjeSekretar(DataGrid dataGrid)
        {
            int trenutniIndeksReda = dataGrid.Items.IndexOf(dataGrid.SelectedItem);

            ZakazivanjeTerminaSekretar(dataGrid, trenutniIndeksReda);
        }

        //
        public void ZakazivanjeTerminaSekretar(DataGrid dataGrid, int trenutniIndeksReda)
        {
            string privremeniFajl = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(privremeniFajl))
            {
                String datum = "";
                String vreme = "";
                String lekar = "";
                String soba = "";
                int idx = 0;
                int id = 0;

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] podaci = line.Split('/');

                    datum = podaci[0];
                    vreme = podaci[1];
                    lekar = podaci[2];
                    soba = podaci[3];
                    idx = int.Parse(podaci[4]);

                    DataGridRow red = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(trenutniIndeksReda);

                    TextBlock tbPacijent = dataGrid.Columns[0].GetCellContent(red) as TextBlock;
                    TextBlock tbDatum = dataGrid.Columns[1].GetCellContent(red) as TextBlock;
                    TextBlock tbVreme = dataGrid.Columns[2].GetCellContent(red) as TextBlock;
                    TextBlock tbLekar = dataGrid.Columns[3].GetCellContent(red) as TextBlock;
                    TextBlock tbSoba = dataGrid.Columns[4].GetCellContent(red) as TextBlock;

                    Boolean nasao = ProveraPacijentPostoji(tbPacijent);

                    if (nasao == true)
                    {
                        if (datum.Equals(tbDatum.Text) && vreme.Equals(tbVreme.Text) && lekar.Equals(tbLekar.Text) && soba.Equals(tbSoba.Text))
                        {
                            sw.WriteLine(tbDatum.Text + "/" + tbVreme.Text + "/" + tbLekar.Text + "/" + tbSoba.Text + "/" + ++id + "/" + tbPacijent.Text);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                        id = idx;
                    }
                    else
                    {
                        MessageBox.Show("Pacijent ne postoji u sistemu");
                        sw.WriteLine(line);
                        while ((line = sr.ReadLine()) != null)
                        {
                            sw.WriteLine(line);
                        }

                    }

                }

            }
            File.Delete("termini.txt");
            File.Move(privremeniFajl, "termini.txt");
        }

        //
        public Boolean ProveraPacijentPostoji(TextBlock tbPacijent)
        {
            String ime = "";
            using (var srr = new StreamReader("podaci.txt"))
            {
                string liness;
                while ((liness = srr.ReadLine()) != null)
                {
                    String[] termin = liness.Split('/');
                    ime = termin[0] + " " + termin[1];

                    if (tbPacijent.Text.Equals(ime))
                    {
                        nasao = true;
                    }
                }
            }
            return nasao;
        }


        public void OtkazivanjeSekretar(TerminiPacijenata termin)
        {
            string privremeniFajl = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(privremeniFajl))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var privremeni = new TerminiPacijenata();

                    String[] podaci = line.Split('/');
                    privremeni.id = int.Parse(podaci[4].ToString());

                    if (privremeni.id != termin.id)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        sw.WriteLine(podaci[0] + "/" + podaci[1] + "/" + podaci[2] + "/" + podaci[3] + "/" + podaci[4] + "/" + " ");
                    }

                }
            }

            File.Delete("termini.txt");
            File.Move(privremeniFajl, "termini.txt");
        }

        public void UpdateSekretar(DataGrid dataGrid)
        {
            int trenutniIndeksReda = dataGrid.Items.IndexOf(dataGrid.SelectedItem);

            string privremeniFajl = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(privremeniFajl))
            {

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (id == trenutniIndeksReda)
                    {
                        DataGridRow red = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(trenutniIndeksReda);

                        TextBlock pacijent = dataGrid.Columns[0].GetCellContent(red) as TextBlock;
                        TextBlock datum = dataGrid.Columns[1].GetCellContent(red) as TextBlock;
                        TextBlock vreme = dataGrid.Columns[2].GetCellContent(red) as TextBlock;
                        TextBlock lekar = dataGrid.Columns[3].GetCellContent(red) as TextBlock;
                        TextBlock soba = dataGrid.Columns[4].GetCellContent(red) as TextBlock;

                        id++;
                        sw.WriteLine(datum.Text + "/" + vreme.Text + "/" + lekar.Text + "/" + soba.Text + "/" + id + "/" + pacijent.Text);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("termini.txt");
            File.Move(privremeniFajl, "termini.txt");

        }

    }
}