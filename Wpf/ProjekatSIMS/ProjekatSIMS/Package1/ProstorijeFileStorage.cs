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
        public ObservableCollection<Prostorije> Prostorije
        {
            get;
            set;
        }

        public void Kreiraj(string tb, string tb1, string tb2, string tb3, string tb4)
      {
            var text = File.ReadAllText(@"prostorije.txt");
            File.WriteAllText(@"prostorije.txt", text + tb + "/" + tb1 + "/" + tb2 + "/" + tb3 + "/" + tb4 + "/" + "-" + Environment.NewLine);

            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }
      
      public void Obrisi(int currentRowIndex)
      {
            int idp = 0;

            try
            {
                ProstorijeFileStorage p = new ProstorijeFileStorage();
                List<string> sveProstorije = p.procitaneProstorije();
                foreach (string sveP in sveProstorije)
                {
                    if (idp == currentRowIndex)
                    {
                        sveProstorije.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }
        }
      
      public void Prikazi(int currentRowIndex)
      {
            SveInfoUpravnik svu = new SveInfoUpravnik(currentRowIndex);
            svu.ShowDialog();
        }
      
      public void Update(string update, int currentRowIndex)
      {
            int idp = 0;
            string prostorija = "";

            try
            {
                ProstorijeFileStorage p = new ProstorijeFileStorage();
                List<string> sveProstorije = p.procitaneProstorije();
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    if (idp == currentRowIndex)
                    {
                        sveProstorije.RemoveAt(currentRowIndex);
                        sveProstorije.Insert(currentRowIndex, update + infoProstorija[4] + "/" + infoProstorija[5]);
                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }
        }

        public void stvari(int currentRowIndex)
        {
            Stvari w1 = new Stvari(currentRowIndex);
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
            int idp = 0;
            List<string> prostorije = procitaneProstorije();
            List<string> nazivi = new List<string>();

            foreach(string sveP in prostorije)
            {
                if (idp != izabrani_red)
                {
                    string prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    nazivi.Add(infoProstorija[0]);
                }
                idp++;
            }
            return nazivi;
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

        public void renoviranje(string update, int currentRowIndex, string ren)
        {
            int idp = 0;
            string prostorija = "";

            try
            {
                ProstorijeFileStorage p = new ProstorijeFileStorage();
                List<string> sveProstorije = p.procitaneProstorije();
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    if (idp == currentRowIndex)
                    {
                        sveProstorije.RemoveAt(currentRowIndex);
                        sveProstorije.Insert(currentRowIndex, update + infoProstorija[4] + "/" + ren);
                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }








            /*
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
            File.Move(tempFile, "prostorije.txt");*/


        }
        public List<string> procitaneProstorije()
        {
            List<string> prostorije = new List<string>();

            using (var sr = new StreamReader("prostorije.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    String ime = termin[0];
                    String oznaka = termin[1];
                    String namena = termin[2];
                    String oprema = termin[3];
                    String kolicina = termin[4];
                    String ren = termin[5];
                    prostorije.Add(ime + "/" + oznaka + "/" + namena + "/" + oprema + "/" + kolicina + "/" + ren);
                }
            }
            return prostorije;
        }

    }
}