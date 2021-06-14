using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Package1.Repozitorijum
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

        public void Kreiraj(string lekar, string tb, string tb1,string jmbgP)
        {
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            string slj = "";

            string imeiPrPacijenta = pronadjiPacijenta(jmbgP);
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
                sw.WriteLine(tb + "/" + tb1 + "/" + slj + "/" + doktor + "/" + id + "/" + imeiPrPacijenta);


            }
            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");

        }
        public void Kreiraj(string lekar, string tb, string tb1, string jmbgP, string vrsta)
        {
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            string slj = "";

            string imeiPrPacijenta = pronadjiPacijenta(jmbgP);
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
                sw.WriteLine(tb + "/" + tb1 + "/" + slj + "/" + doktor + "/" + id + "/" + imeiPrPacijenta + "/" + " /" + vrsta);


            }
            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");

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
        public string pronadjiPacijenta(string jmbg)
        {
            string imeIprz="";

            using (var sars = new StreamReader("podaci.txt"))
            {
                string lines;
                while ((lines = sars.ReadLine()) != null)
                {
                    String[] deo = lines.Split('/');
                    string ime = deo[0];
                    string prz = deo[1];
                    if (jmbg == deo[2])
                    {
                        imeIprz = ime+" "+prz;
                    }

                }
            }
            return imeIprz;

        }
        public List<TerminiPacijenata> GetAll()
        {
            List<TerminiPacijenata> termini = new List<TerminiPacijenata>();

            using (var sars = new StreamReader("termini.txt"))
            {
                string lines;
                while ((lines = sars.ReadLine()) != null)
                {
                    var termin = new TerminiPacijenata();
                    String[] deo = lines.Split('/');
                    termin.datum = deo[0];
                    termin.vreme = deo[1];
                    termin.lekar = deo[2];
                    termin.soba = deo[3];
                    termin.id = int.Parse(deo[4]);
                    termin.pacijenti = deo[5];
                    termini.Add(termin);
                }
            }
            return termini;
        }

        public void saveAll(List<TerminiPacijenata> items)
        {

            using (var sw = new StreamWriter("termini"))
            {
                foreach (TerminiPacijenata a in items)
                {
                    sw.WriteLine(a.datum + "/" + a.vreme + "/" + a.lekar + "/" + a.soba + "/" + a.id + "/" + a.pacijenti + "/ ");
                }
            }

        }
    }
}