using ProjekatSIMS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Package1
{
   public class ProstorijeFileStorage
   {
        string oprema_glavna = "";
        string kolicina_glavna = "";
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
                sw.WriteLine(tb + "/" + tb1 + "/" + tb2 + "/" + tb3 + "/" + ",");


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

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/" + termin[4]);
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

        public void stvari(DataGrid dataGridProstorije)
        {
            int currentRowIndex = dataGridProstorije.Items.IndexOf(dataGridProstorije.SelectedItem);

            using (var sw = new StreamWriter("redopreme.txt"))
            {
                sw.WriteLine(currentRowIndex);
            }
            Stvari w1 = new Stvari();
            w1.ShowDialog();

        }

        public int red_prostorije(string s)
        {
            int red = 0;
            using (var sr = new StreamReader(s))
            {
                string ucitano = "";

                ucitano = sr.ReadLine();
                red = int.Parse(ucitano);
            }
            return red;
        }

        public List<string> prostorije_u_cb(int izabrani_red)
        {
            using (var sr = new StreamReader("prostorije.txt"))
            {
                List<string> prostorije = new List<string>();
                string ime = "";
                string line = "";
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (idp != izabrani_red)
                    {
                        string[] informacije = line.Split('/');
                        ime = informacije[0];
                        prostorije.Add(ime);
                    }
                    idp++;
                }
                return prostorije;
            }
        }

        public List<string> prostorija_iz(string oprema_u, string kolicina_u, string naziv, int intkol)
        {
            List<string> prostorije = new List<string>();
            string selektovan_red_stv = oprema_u;
            string[] sstv = selektovan_red_stv.Split(',');
            int duzina_stvari = sstv.Length;

            string selektovan_red_oprema = kolicina_u;
            string[] skol = selektovan_red_oprema.Split(',');

                string oprema = "";
                string kolicina = "";
                int br = 0;
                for (int i = 0; i < duzina_stvari; i++)
                {
                    if (sstv[i].Equals(naziv))
                    {
                        if (i == 0)
                        {
                            ++br;
                        }
                        int temp = int.Parse(skol[i]);
                        temp -= intkol;
                        if (temp < 0)
                        {
                            MessageBox.Show("izabrali ste previse opreme za premestanje");
                            intkol = int.Parse(skol[i]);
                        }
                        else if (temp != 0)
                        {
                            if (i == 0)
                            {
                                oprema += sstv[i] + ",";
                                kolicina += temp.ToString() + ",";
                            }
                            else
                            {
                                oprema += "," + sstv[i];
                                kolicina += "," + temp.ToString();
                            }
                        }
                    }
                    else
                    {
                        int broj = 0;
                        if (br > 0)
                        {
                            ++broj;
                        }
                        if (i == broj)
                        {
                            oprema += sstv[i];
                            kolicina += skol[i];
                        }
                        else
                        {
                            oprema += "," + sstv[i];
                            kolicina += "," + skol[i];
                        }
                    }
                prostorije.Add(oprema + "/" + kolicina);
            }
            return prostorije;
        }

        public List<string> prostorija_u(string oprema_u, string kolicina_u, string naziv, int intkol)
        {
            List<string> prostorije = new List<string>();
            string selektovan_red_stv = oprema_u;
            string[] sstv = selektovan_red_stv.Split(',');
            int duzina_stvari = sstv.Length;

            string selektovan_red_oprema = kolicina_u;
            string[] skol = selektovan_red_oprema.Split(',');

            int brojac = 0;
            string kolicina = "";
            for (int i = 0; i < duzina_stvari; i++)
            {
                if (sstv[i].Equals(naziv))
                {
                    int nova_kolicina = int.Parse(skol[i]);
                    nova_kolicina += intkol;
                    if (i == 0)
                    {
                        kolicina = nova_kolicina.ToString();
                        for (int j = 1; j < duzina_stvari; j++)
                        {
                            kolicina += "," + skol[j];
                        }
                    }
                    else
                    {
                        kolicina = skol[0];
                        for (int j = 1; j < i; j++)
                        {
                            kolicina += "," + skol[j];
                        }
                        kolicina += "," + nova_kolicina.ToString();
                        int broj = ++i;
                        for (int j = broj; j < duzina_stvari; j++)
                        {
                            kolicina += "," + skol[j];
                        }
                    }
                    brojac++;
                    prostorije.Add(selektovan_red_stv + "/" + kolicina);
                }
                else if (i == (duzina_stvari - 1) && brojac == 0)
                {
                    selektovan_red_stv += "," + naziv;
                    selektovan_red_oprema += "," + intkol.ToString();
                    prostorije.Add(selektovan_red_stv + "/" + selektovan_red_oprema);
                }
            }
            return prostorije;
        }

        public void renoviranje(DataGrid dataGridProstorije)
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
                        TextBlock t5 = dataGridProstorije.Columns[6].GetCellContent(row) as TextBlock;

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/" + termin[4] + "/"+ t5.Text);
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