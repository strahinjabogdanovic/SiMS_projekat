using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    public class LekoviFileStorage
    {
        public ObservableCollection<Lek> Lekovi
        {
            get;
            set;
        }
        public void Kreiraj(String s1, String s2, String s3, String s4)
        {
            var text = File.ReadAllText(@"lekovi.txt");
            File.WriteAllText(@"lekovi.txt", text + s1 + "/" + s2 + "/" + s3 + "/" + s4 + "/" + "-" + Environment.NewLine);

            //Lekovi_U s = new Lekovi_U();
            //s.ShowDialog();
        }

        public void Obrisi(int currentRowIndex)
        {
            int idp = 0;

            try
            {
                LekoviFileStorage l = new LekoviFileStorage();
                List<string> sveLekovi = l.procitaniLekovi();
                foreach (string sviL in sveLekovi)
                {
                    if (idp == currentRowIndex)
                    {
                        sveLekovi.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"lekovi.txt", sveLekovi);
                    }
                    idp++;
                }
            }
            catch (Exception e){ }
        }

        public void Izmeni(string update, int currentRowIndex)
        {
            int idp = 0;

            try
            {
                LekoviFileStorage p = new LekoviFileStorage();
                List<string> sveLekovi = p.procitaniLekovi();
                foreach (string sviL in sveLekovi)
                {
                    string lekovi = sviL;
                    string[] infoLekovi = lekovi.Split('/');
                    if (idp == currentRowIndex)
                    {
                        sveLekovi.RemoveAt(currentRowIndex);
                        sveLekovi.Insert(currentRowIndex, update + infoLekovi[4]);
                        File.WriteAllLines(@"lekovi.txt", sveLekovi);
                    }
                    idp++;
                }
            }
            catch (Exception e){ }
        }
        public Lek vratiUpravniku(DataGrid datagridLekovi)
        {
            Lek lekic = new Lek();

            int currentRowIndex = datagridLekovi.Items.IndexOf(datagridLekovi.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekovi.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (id == currentRowIndex)
                    {
                        String[] deo = line.Split('/');
                        lekic.sifraleka = deo[0];
                        lekic.nazivleka = deo[1];
                        lekic.sastojci = deo[2];
                        lekic.zamena = deo[3];
                        lekic.validiran = "podaciNETACNI";
                        DataGridRow row = (DataGridRow)datagridLekovi.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = datagridLekovi.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = datagridLekovi.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = datagridLekovi.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = datagridLekovi.Columns[3].GetCellContent(row) as TextBlock;

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/" + lekic.validiran) ;
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("lekovi.txt");
            File.Move(tempFile, "lekovi.txt");
            return lekic;

        }
        public bool proveriPogresneLekove()
        {
            bool ima = false;
            using (var sr = new StreamReader("lekovi.txt"))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] deo = line.Split('/');
                    string validiran = deo[4];
                    if (validiran == "podaciNETACNI")
                    {
                        ima = true;
                    }

                    id++;
                }

                return ima;

            }
        }
        public Lek nadjiPogresanLek()
        {
            Lek lekicpogresan = new Lek();
            using (var sr = new StreamReader("lekovi.txt"))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] deo = line.Split('/');
                    string sifra = deo[0];
                    string naziv = deo[1];
                    string sastojci = deo[2];
                    string zamena = deo[3];
                    string validiran = deo[4];
                    if (validiran == "podaciNETACNI")
                    {
                        lekicpogresan.sifraleka = sifra;
                        lekicpogresan.nazivleka = naziv;
                        lekicpogresan.sastojci = sastojci;
                        lekicpogresan.zamena = zamena;
                    }

                    id++;
                }

                return lekicpogresan;

            }
        }
        public List<string> procitaniLekovi()
        {
            List<string> lekovi = new List<string>();

            using (var sr = new StreamReader("lekovi.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] termin = line.Split('/');
                    string sifra = termin[0];
                    string naziv = termin[1];
                    string sastojci = termin[2];
                    string zamena = termin[3];
                    string dodatno = termin[4];
                    lekovi.Add(sifra + "/" + naziv + "/" + sastojci + "/" + zamena + "/" + dodatno);
                }
            }
            return lekovi;
        }
        public ObservableCollection<Lek> CitajSveLekove()
        {
            ObservableCollection<Lek> lekovi = new ObservableCollection<Lek>();
            List<string> lines = procitaniLekovi();
            foreach (string linee in lines)
            {
                string[] termin = linee.Split('/');
                var lekicLek = new Lek();
                lekicLek.sifraleka = termin[0];
                lekicLek.nazivleka = termin[1];
                lekicLek.sastojci = termin[2];
                lekicLek.zamena = termin[3];
                lekicLek.validiran = termin[4];
                lekovi.Add(lekicLek);
            }
            return lekovi;
        }

        public void Validiraj(Lek lekic)
        {
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekovi.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] jedanLek = line.Split('/');
                    if (jedanLek[0].Equals(lekic.sifraleka))
                    {
                        lekic.sastojci = jedanLek[2];
                        lekic.zamena = jedanLek[3];
                        sw.WriteLine(lekic.sifraleka + "/" + lekic.nazivleka + "/" + lekic.sastojci + "/" + lekic.zamena + "/" + lekic.validiran);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("lekovi.txt");
            File.Move(tempFile, "lekovi.txt");
        }
    }
}