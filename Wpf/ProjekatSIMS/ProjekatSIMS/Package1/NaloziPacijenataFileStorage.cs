using ProjekatSIMS;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Package1
{
   public class NaloziPacijenataFileStorage
   {
        
        public ObservableCollection<Pacijent> Korisnici
        {
            get;
            set;
        }

        Pol p;
        public void Kreiraj(string gender, string tb, string tb1, string tb2, string tb3, string tb5, string tb6, string tb7)
      {
            Korisnici = new ObservableCollection<Pacijent>();
            string slj = "";

            //string gender = comboBox.SelectedValue.ToString();

            if (gender != null)
            {

                if (gender.Contains("Muski"))
                {
                    p = Pol.Muski;
                    slj = "Muski";

                }
                else if (gender.Contains("Zenski"))
                {
                    p = Pol.Zenski;
                    slj = "Zenski";
                }
            }


            string tempFile = System.IO.Path.GetTempFileName();
            string tempFile1 = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("podaci.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {

                    //var lastLine = File.ReadLines("podaci.txt").Last();
                    String[] termin = line.Split('/');
                    var korisnik = new Pacijent();
                    id = int.Parse(termin[8]);
                    id++;

                    sw.WriteLine(line);

                }
                sw.WriteLine(tb + "/" + tb1 + "/" + tb2 + "/" + slj + "/" + tb3 + "/" + tb5 + "/" + tb6 + "/" + tb7 + "/" + id);


                using (var srev = new StreamReader("medKarton.txt"))
                using (var swev = new StreamWriter(tempFile1))
                {
                    string liness;
                    while ((liness = srev.ReadLine()) != null)
                    {

                        String[] termin = liness.Split('/');
                        var zdravKarton = new ZdravstveniKarton();


                        swev.WriteLine(liness);

                    }
                    swev.WriteLine(id + "/");


                }
                File.Delete("medKarton.txt");
                File.Move(tempFile1, "medKarton.txt");

            }
            File.Delete("podaci.txt");
            File.Move(tempFile, "podaci.txt");

            //Close();
            //SekretarPocetnaStrana s = new SekretarPocetnaStrana();
            //s.ShowDialog();
            //this.NavigationService.Navigate(new PageSekretar());
        }
      
      public void Obrisi(Pacijent k)
      {
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("podaci.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Korisnici = new ObservableCollection<Pacijent>();

                    var priv = new Pacijent();

                    String[] termin = line.Split('/');
                    priv.jmbg = long.Parse(termin[2].ToString());

                    if (priv.jmbg != k.jmbg)
                    {
                        sw.WriteLine(line);

                    }
                    else
                    {
                        k.idKorisnika = int.Parse(termin[8].ToString());

                        string tempFile1 = System.IO.Path.GetTempFileName();
                        using (var srpp = new StreamReader("medKarton.txt"))
                        using (var swpp = new StreamWriter(tempFile1))
                        {
                            string linessi;

                            while ((linessi = srpp.ReadLine()) != null)
                            {

                                String[] term = linessi.Split('/');

                                int p = int.Parse(term[0].ToString());
                                //Console.WriteLine(p);

                                if (p != k.idKorisnika)
                                {
                                    swpp.WriteLine(linessi);
                                }

                            }


                        }
                        File.Delete("medKarton.txt");
                        File.Move(tempFile1, "medKarton.txt");
                    }

                }

            }

            File.Delete("podaci.txt");
            File.Move(tempFile, "podaci.txt");

            /*
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("podaci.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Korisnici = new ObservableCollection<Pacijent>();

                    var priv = new Pacijent();

                    String[] termin = line.Split('/');
                    priv.jmbg = long.Parse(termin[2].ToString());


                    if (priv.jmbg != k.jmbg)
                        sw.WriteLine(line);
                }
            }

            File.Delete("podaci.txt");
            File.Move(tempFile, "podaci.txt");
            */
        }
      
      public void Prikazi(DataGrid dataGridNalozi)
      {
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);

            using (var sw = new StreamWriter("redovi.txt"))
            {
                sw.WriteLine(currentRowIndex);
            }
            //this.NavigationService.Navigate(new PageSPrikazInfo());
            //Window2 w2 = new Window2();
            //w2.ShowDialog();
        }
      
      public void Update(DataGrid dataGridNalozi)
      {
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("podaci.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                String pol = "";
                String mail = "";
                String adresa = "";
                int idx = 0;

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //id++;
                    if (id == currentRowIndex)
                    {
                        //var lastLine = File.ReadLines("podaci.txt").Last();
                        String[] termin = line.Split('/');
                        var korisnik = new Pacijent();
                        pol = termin[3];
                        mail = termin[5];
                        adresa = termin[7];
                        idx = int.Parse(termin[8]);



                        DataGridRow row = (DataGridRow)dataGridNalozi.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = dataGridNalozi.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = dataGridNalozi.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = dataGridNalozi.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = dataGridNalozi.Columns[3].GetCellContent(row) as TextBlock;
                        TextBlock t5 = dataGridNalozi.Columns[4].GetCellContent(row) as TextBlock;

                        sw.WriteLine(t1.Text + "/" + t2.Text + "/" + long.Parse(t3.Text) + "/" + pol + "/" + t4.Text + "/" + mail + "/" + t5.Text + "/" + adresa + "/" + idx);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("podaci.txt");
            File.Move(tempFile, "podaci.txt");
        }

        public int dobaviIdPacijentaPoJmbgu(string jmbg)
        {
            int idp=0;
            using (var sars = new StreamReader("podaci.txt"))

            {
                string line;
                int idps = 0;
                while ((line = sars.ReadLine()) != null)
                {
                    String[] deo = line.Split('/');
                    String idK = deo[2];

                    string sifra = deo[8];
                    if (idK == jmbg)
                    {
                        idp = int.Parse(sifra);
                    }
                    idps++;

                }
            }
            return idp;
        }
        public string DobaviAlergije(int idP)
        {
            string alergije = "";
            using (var sars = new StreamReader("medKarton.txt"))

            {
                string line;
                int idps = 0;
                while ((line = sars.ReadLine()) != null)
                {
                    String[] deo = line.Split('/');
                    String idK = deo[0];

                    String alergijica = deo[1];
                    if (int.Parse(idK) == idP)
                    {
                        alergije = alergijica;
                    }
                    idps++;

                }
            }
            return alergije;

        }
   
   }
}