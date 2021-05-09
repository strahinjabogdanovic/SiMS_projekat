using ProjekatSIMS;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Package1
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
            Lekovi = new ObservableCollection<Lek>();

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekovi.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    String[] termin = line.Split('/');
                    var prostorije = new Prostorije();

                    sw.WriteLine(line);

                }
                sw.WriteLine(s1 + "/" + s2 + "/" + s3 + "/" + s4 + "/");


            }
            File.Delete("lekovi.txt");
            File.Move(tempFile, "lekovi.txt");

            Lekovi_U s = new Lekovi_U();
            s.ShowDialog();
        }

        public void Obrisi(Lek l)
        {
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekovi.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Lekovi = new ObservableCollection<Lek>();

                    var priv = new Lek();

                    String[] termin = line.Split('/');
                    priv.sifraleka = termin[0].ToString();

                    if (priv.sifraleka != l.sifraleka)
                        sw.WriteLine(line);
                }
            }

            File.Delete("lekovi.txt");
            File.Move(tempFile, "lekovi.txt");
        }

        public void Izmeni(DataGrid datagridLekovi)
        {
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
                        String[] termin = line.Split('/');
                        var prostorija = new Lek();

                        DataGridRow row = (DataGridRow)datagridLekovi.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = datagridLekovi.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = datagridLekovi.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = datagridLekovi.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = datagridLekovi.Columns[3].GetCellContent(row) as TextBlock;

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/");
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
    }
}