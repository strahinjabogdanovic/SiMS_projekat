using ProjekatSIMS;
using ProjekatSIMS.Package1;
using System;
using System.Collections.Generic;
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

        public void Kreiraj(string vt, string l, string tb, string tb1, string tb2,string jmbg)
      {
            ZakazTermina = new ObservableCollection<TerminiPacijenata>();


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

                sw.WriteLine(vt + "/" + tb + "/" + tb1 + "/" + tb2 + "/" + l + "/" + id + "/" + jmbg);


            }
            File.Delete("lekar.txt");
            File.Move(tempFile, "lekar.txt");

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

        string imePacijenta;
        string imeLekara;
        public void PomeranjeTerminaSekretar(TerminiPacijenata termin)
        {
            string privremeniFajl = System.IO.Path.GetTempFileName();

            string datum1 = "";
            String[] datumi;
            int mesec = 0;
            int mesec1 = 0;
            int god = 0;
            int dan = 0;
            string noviDatum = "";

            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(privremeniFajl))
            {
                string line;
                Boolean pronasao = false;
                int brojac = 0;

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
                        imePacijenta = podaci[5];
                        imeLekara = podaci[2];
                        pronasao = true;
                        brojac++;
                        sw.WriteLine(podaci[0] + "/" + podaci[1] + "/" + podaci[2] + "/" + podaci[3] + "/" + podaci[4] + "/" + " ");                  
                    }

                    if (pronasao == true && brojac==1)
                    {
                        datumi = podaci[0].Split('.');
                        dan = int.Parse(datumi[0]);

                        mesec = int.Parse(datumi[1]);
                        mesec1 = int.Parse(datumi[1]);
                        god = int.Parse(datumi[2]);

                        if (mesec == 1 || mesec == 3 || mesec == 5 || mesec == 7 || mesec == 8 || mesec == 10 || mesec == 12)
                        {
                            if (dan == 30)
                            {
                                datum1 = 31.ToString();
                                if (mesec == 12)
                                {
                                    datumi[1] = 1.ToString();
                                    ++god;
                                }

                            }
                            else if (dan == 31)
                            {
                                datum1 = 1.ToString();
                                if (mesec == 12) { datumi[1] = 1.ToString(); ++god; }
                                else
                                {
                                    ++mesec1;
                                }

                            }
                            else
                            {
                                datum1 = (++dan).ToString();
                            }
                        }
                        else if (mesec == 2)
                        {
                            if (dan == 27)
                            {
                                datum1 = 28.ToString();

                            }
                            else if (dan == 28)
                            {
                                datum1 = 1.ToString();

                                ++mesec1;
                            }
                            else
                            {
                                datum1 = (++dan).ToString();
                            }
                        }
                        else if (mesec == 4 || mesec == 6 || mesec == 9 || mesec == 11)
                        {

                            if (dan == 29)
                            {
                                datum1 = 30.ToString();

                            }
                            else if (dan == 30)
                            {
                                datum1 = 1.ToString();

                                ++mesec1;
                            }
                            else
                            {
                                datum1 = (++dan).ToString();
                            }
                        }

                        brojac++;
                        string mes = "";
                        if (int.Parse(datum1) < 10)
                        {
                            datum1 = "0" + datum1;
                        }
                        if (mesec1 < 10)
                        {
                            mes = "0" + mesec1.ToString();
                        }
                        noviDatum = datum1 + "." + mes + "." + god + ".";
                        //Console.WriteLine(noviDatum);
                       
                    }
                    /*
                    if (noviDatum.Equals(podaci[0]) && podaci[5]=="")
                    {
                        sw.WriteLine(noviDatum + "/" + podaci[1] + "/" + podaci[2] + "/" + podaci[3] + "/" + podaci[4] + "/" + imePacijenta);
                    }  */                
                }                                

            }

            File.Delete("termini.txt");
            File.Move(privremeniFajl, "termini.txt");

            using (var srr = new StreamReader("termini.txt"))
            using (var sww = new StreamWriter(privremeniFajl))
            {
                
                string lin;
                int br = 0;
                while ((lin = srr.ReadLine()) != null)
                {
                    String[] podacii = lin.Split('/');
                    //Console.WriteLine(noviDatum);

                    if (noviDatum.Equals(podacii[0]) && imeLekara.Equals(podacii[2]) && string.IsNullOrWhiteSpace(podacii[5]) && br ==0)
                    {
                        br++;
                        sww.WriteLine(podacii[0] + "/" + podacii[1] + "/" + podacii[2] + "/" + podacii[3] + "/" + podacii[4] + "/" + imePacijenta);
                    }
                    else
                    {
                        sww.WriteLine(lin);
                    }

                }
            }
            File.Delete("termini.txt");
            File.Move(privremeniFajl, "termini.txt");


        }

        public List<string> DobaviTerminePoLekaru(string imeiPr)
        {
            List<string> dobavljenTermin=new List<string>();
            string doktor;
                int br = 0;
                using (var sr = new System.IO.StreamReader("termini.txt"))
                {
                    doktor = imeiPr;
                    string line;
                    DateTime ter = DateTime.Now;

                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] termin = line.Split('/');

                        if (termin[2].Equals(imeiPr))
                        {
                            br++;

                            String[] dat = termin[0].Split('.');
                            String datum = dat[2] + "/" + dat[1] + "/" + dat[0];
                            String vreme = termin[1] + ":00";
                            String d = datum + " " + vreme;
                            DateTime t2 = DateTime.Now;
                            Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                            DateTime parsedDate = DateTime.Parse(d);


                            using (var sr2 = new System.IO.StreamReader("termini.txt"))
                            {

                                String datum2 = "";
                                String vreme2 = "";

                                DateTime parsedDate33 = DateTime.Parse("2100/2/1 00:00:00");
                                TimeSpan span = parsedDate33.Subtract(parsedDate);

                                int i = 0;
                                while ((line = sr2.ReadLine()) != null)
                                {

                                    String[] termin2 = line.Split('/');

                                    String[] dat2 = termin2[0].Split('.');
                                    datum2 = dat2[2] + "/" + dat2[1] + "/" + dat2[0];
                                    vreme2 = termin2[1] + ":00";
                                    String d2 = datum2 + " " + vreme2;


                                    Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                                    DateTime parsedDate2 = DateTime.Parse(d2);

                                    if (termin[0].Equals(termin2[0]) && termin[2].Equals(termin2[2]))
                                    {

                                        if (DateTime.Compare(parsedDate, parsedDate2) < 0)
                                        {
                                            if (DateTime.Compare(parsedDate.AddMinutes(30), parsedDate2) != 0)
                                            {
                                                dobavljenTermin.Add(parsedDate.AddMinutes(30).ToString());
                                            }
                                            i++;
                                        }
                                        else if (DateTime.Compare(parsedDate, parsedDate2) > 0)
                                        {
                                            if (DateTime.Compare(parsedDate2.AddMinutes(30), parsedDate) != 0)
                                            {
                                                dobavljenTermin.Add(parsedDate2.AddMinutes(30).ToString());
                                            }
                                            i++;
                                        }


                                    }

                                    if (i == 0)
                                    {
                                        String[] t = termin[0].Split('.');
                                        DateTime parsedDate332 = DateTime.Parse(t[2] + "/" + t[1] + "/" + t[0] + " " + "08:00:00");
                                        if (DateTime.Compare(parsedDate, parsedDate332) != 0)
                                        {
                                            dobavljenTermin.Add(parsedDate332.ToString());
                                            i++;
                                        }
                                        else
                                        {
                                            dobavljenTermin.Add(parsedDate332.AddMinutes(30).ToString());
                                            i++;
                                        }

                                    }
                                    else if (i < 3)
                                    {
                                    dobavljenTermin.Add(parsedDate.AddMinutes(i * 30).ToString());


                                    dobavljenTermin.Add(parsedDate.AddMinutes(i * 30 + 30).ToString());

                                        i += 2;
                                    }

                                }



                            }


                        }

                    }
                    if (br == 0)
                    {

                        String[] t = DateTime.Now.AddDays(1).ToString().Split(' ');
                        DateTime parsedDate332 = DateTime.Parse(t[0] + " " + "08:00:00");
                        dobavljenTermin.Add(parsedDate332.ToString());
                        dobavljenTermin.Add(parsedDate332.AddMinutes(30).ToString());
                        dobavljenTermin.Add(parsedDate332.AddMinutes(60).ToString());

                    }

                }
            return dobavljenTermin;
            }
    }
}