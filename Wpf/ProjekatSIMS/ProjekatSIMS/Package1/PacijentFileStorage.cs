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
                sw.WriteLine(tb + "/" + tb1 + "/" + slj + "/" + doktor + "/" + id + "/" + "Ana Markovic");


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

            using (var sw = new StreamWriter("redoviPacijent.txt"))
            {
                sw.WriteLine(currentRowIndex);
            }

        }


        public void UpdateSekretar(DataGrid dataGridPacijenti)
        {
            int currentRowIndex = dataGridPacijenti.Items.IndexOf(dataGridPacijenti.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("termini.txt"))
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
                        //var pac = new TerminiPacijenata();


                        DataGridRow row = (DataGridRow)dataGridPacijenti.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = dataGridPacijenti.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = dataGridPacijenti.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = dataGridPacijenti.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = dataGridPacijenti.Columns[3].GetCellContent(row) as TextBlock;
                        TextBlock t5 = dataGridPacijenti.Columns[4].GetCellContent(row) as TextBlock;

                        id++;
                        sw.WriteLine(t2.Text + "/" + t3.Text + "/" + t4.Text + "/" + t5.Text + "/" + id + "/" + t1.Text);
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



        String[] terminin;
        public void KreirajSekretar(string lekar, string tb, string tb1, string tb2)
        {

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

            //String[] terminin;

            using (var srp = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string linep;
                int idd = 0;
                while ((linep = srp.ReadLine()) != null)
                {
                    terminin = linep.Split('/');
                    var pacijent = new TerminiPacijenata();

                    idd = int.Parse(terminin[4]);
                    idd++;

                    sw.WriteLine(linep);

                }
                string doktor = "";
                using (var sars = new StreamReader("doktori.txt"))
                {
                    string lines;
                    while ((lines = sars.ReadLine()) != null)
                    {
                        String[] termin = lines.Split('/');
                        lines = termin[0];
                        if (lines == slj)
                        {
                            doktor = termin[1];
                        }

                    }
                }
                sw.WriteLine(tb + "/" + tb1 + "/" + slj + "/" + doktor + "/" + idd + "/" + tb2);

                Console.WriteLine(tb2);

            }
            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");
        }


        public void OtkazivanjeSekretar(TerminiPacijenata k)
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
                    {
                        sw.WriteLine(line);
                    }else
                    {
                        sw.WriteLine(termin[0] + "/" + termin[1] + "/" + termin[2] + "/" + termin[3] + "/" + "0" + "/" + " ");
                    }
                        
                }
            }

            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");
        }


        public void ZakazivanjeSekretar(DataGrid dataGridPacijenti)
        {
            int currentRowIndex = dataGridPacijenti.Items.IndexOf(dataGridPacijenti.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(tempFile))
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
                   
                        String[] termin = line.Split('/');

                        datum = termin[0];
                        vreme = termin[1];
                        lekar = termin[2];
                        soba = termin[3];
                        idx = int.Parse(termin[4]);


                        DataGridRow row = (DataGridRow)dataGridPacijenti.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock pacijent = dataGridPacijenti.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock dat = dataGridPacijenti.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock vrem = dataGridPacijenti.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock dr = dataGridPacijenti.Columns[3].GetCellContent(row) as TextBlock;
                        TextBlock s = dataGridPacijenti.Columns[4].GetCellContent(row) as TextBlock;


                        if (datum.Equals(dat.Text) && vreme.Equals(vrem.Text) && lekar.Equals(dr.Text) && soba.Equals(s.Text))
                        {
                            sw.WriteLine(dat.Text + "/" + vrem.Text + "/" + dr.Text + "/" + s.Text + "/" + ++id + "/" + pacijent.Text);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    id = idx;
                }

            }
            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");

        }


    }
}