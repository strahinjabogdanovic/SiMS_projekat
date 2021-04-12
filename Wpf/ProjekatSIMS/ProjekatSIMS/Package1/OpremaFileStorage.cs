using ProjekatSIMS;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Package1
{
   public class OpremaFileStorage
   {
        public ObservableCollection<Oprema> Oprema
        {
            get;
            set;
        }
        public void Kreiraj(string tb, string tb1)
        {
            int currentRowIndex = 0;
            using (var rsr = new StreamReader("redopreme.txt"))
            {
                String sdfg = "";

                sdfg = rsr.ReadLine();
                currentRowIndex = int.Parse(sdfg);
            }

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("prostorije.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (id == currentRowIndex)
                    {
                        String[] termin = line.Split('/');
                        var prostorija = new Prostorije();
                        string s1 = termin[0];
                        string s2 = termin[1];
                        string s3 = termin[2];

                        string s4 = termin[3];
                        string[] oprema_split = s4.Split(',');
                        string nova_oprema = oprema_split[0];
                        int oi = oprema_split.Length;
                        for (int i = 1; i < oi;i++) {
                            nova_oprema += "," + oprema_split[i];
                        }
                        nova_oprema += "," + tb;

                        string s5 = termin[4];
                        string[] kolicina_split = s5.Split(',');
                        string nova_kolicina = kolicina_split[0];
                        int ki = kolicina_split.Length;
                        for (int i = 1; i < ki;i++)
                        {
                            nova_kolicina += "," + kolicina_split[i];
                        }
                        nova_kolicina += "," + tb1;

                        sw.WriteLine(s1 + "/" + s2 + "/" + s3 + "/" + nova_oprema + "/" + nova_kolicina);
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

            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            Stvari ss = new Stvari();
            s.ShowDialog();
            ss.ShowDialog();
        }

        public void Obrisi(Oprema k)
        {
            int currentRowIndex = 0;
            using (var rsr = new StreamReader("redopreme.txt"))
            {
                String sdfg = "";

                sdfg = rsr.ReadLine();
                currentRowIndex = int.Parse(sdfg);
            }

            int currentRowIndexo = 0;
            using (var rsr = new StreamReader("redopreme1.txt"))
            {
                String sdfg = "";

                sdfg = rsr.ReadLine();
                currentRowIndexo = int.Parse(sdfg);
            }
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("prostorije.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (id == currentRowIndex)
                    {
                        String[] termin = line.Split('/');
                        var prostorija = new Prostorije();
                        string s1 = termin[0];
                        string s2 = termin[1];
                        string s3 = termin[2];

                        string s4 = termin[3];
                        string[] oprema_split = s4.Split(',');
                        int oi = oprema_split.Length;
                        string nova_oprema = "";

                        string s5 = termin[4];
                        string[] kolicina_split = s5.Split(',');
                        int ki = kolicina_split.Length;
                        string nova_kolicina = "";

                        if (currentRowIndexo == 0)
                        {
                            for (int i = 1; i < oi; i++)
                            {
                                nova_oprema += "," + oprema_split[i];
                            }
                            for (int i = 1; i < ki; i++)
                            {
                                nova_kolicina += "," + kolicina_split[i];
                            }
                        }
                        else
                        {
                            nova_oprema = oprema_split[0];
                            for (int i = 1; i < currentRowIndexo; i++)
                            {
                                nova_oprema += "," + oprema_split[i];
                            }
                            int crio = ++currentRowIndexo;
                            for (int i = crio; i<oi; i++)
                            {
                                nova_oprema += "," + oprema_split[i];
                            }
                        
                            nova_kolicina = kolicina_split[0];
                            for (int i = 1; i < currentRowIndexo; i++)
                            {
                                nova_kolicina += "," + kolicina_split[i];
                            }
                            for (int i = crio; i < ki; i++)
                            {
                                nova_kolicina += "," + kolicina_split[i];
                            }

                        }

                        sw.WriteLine(s1 + "/" + s2 + "/" + s3 + "/" + nova_oprema + "/" + nova_kolicina);
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

            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }
      
      public void Prikazi()
      {
         // TODO: implement
      }
      
      public void Update(DataGrid dataGridOprema)
      {
            int currentRowIndex = 0;
            using (var rsr = new StreamReader("redopreme.txt"))
            {
                String sdfg = "";

                sdfg = rsr.ReadLine();
                currentRowIndex = int.Parse(sdfg);
            }

            int currentRowIndexo = dataGridOprema.Items.IndexOf(dataGridOprema.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("prostorije.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (id == currentRowIndex)
                    {
                        DataGridRow row = (DataGridRow)dataGridOprema.ItemContainerGenerator.ContainerFromIndex(currentRowIndexo);

                        TextBlock t1 = dataGridOprema.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = dataGridOprema.Columns[1].GetCellContent(row) as TextBlock;

                        String[] termin = line.Split('/');
                        var prostorija = new Prostorije();
                        string s1 = termin[0];
                        string s2 = termin[1];
                        string s3 = termin[2];

                        string s4 = termin[3];
                        string[] oprema_split = s4.Split(',');
                        int oi = oprema_split.Length;
                        string nova_oprema = "";

                        string s5 = termin[4];
                        string[] kolicina_split = s5.Split(',');
                        int ki = kolicina_split.Length;
                        string nova_kolicina = "";

                        if (currentRowIndexo == 0)
                        {
                            nova_oprema = t1.Text;
                            for (int i = 1; i < oi; i++)
                            {
                                nova_oprema += "," + oprema_split[i];
                            }
                            nova_kolicina = t2.Text;
                            for (int i = 1; i < ki; i++)
                            {
                                nova_kolicina += "," + kolicina_split[i];
                            }
                        }
                        else
                        {
                            nova_oprema = oprema_split[0];
                            for (int i = 1; i < currentRowIndexo; i++)
                            {
                                nova_oprema += "," + oprema_split[i];
                            }
                            nova_oprema += "," + t1.Text;
                            int crio = ++currentRowIndexo;
                            for (int i = crio; i < oi; i++)
                            {
                                nova_oprema += "," + oprema_split[i];
                            }

                            nova_kolicina = kolicina_split[0];
                            for (int i = 2; i < currentRowIndexo; i++)
                            {
                                Console.WriteLine("ovde");
                                nova_kolicina += "," + kolicina_split[i];
                            }
                            crio++;
                            nova_kolicina += "," + t2.Text;
                            for (int i = crio; i < ki; i++)
                            {
                                Console.WriteLine("ovde1");
                                nova_kolicina += "," + kolicina_split[i];
                            }
                        }

                        sw.WriteLine(s1 + "/" + s2 + "/" + s3 + "/" + nova_oprema + "/" + nova_kolicina);
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

            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }
   
   }
}