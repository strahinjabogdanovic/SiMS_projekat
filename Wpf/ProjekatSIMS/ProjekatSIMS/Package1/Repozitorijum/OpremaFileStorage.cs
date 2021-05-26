using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using Package1;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Upravnik;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    public class OpremaFileStorage
    {
        int temp = 0;
        public ObservableCollection<Oprema> Oprema
        {
            get;
            set;
        }
        public void Kreiraj(string tb, string tb1, int redStvari)
        {
            ProstorijeFileStorage p = new ProstorijeFileStorage();

            int idp = 0;
            string prostorija = "";
            try
            {
                List<string> sveProstorije = p.procitaneProstorije();
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');

                    string oprema = infoProstorija[3];
                    oprema += "," + tb;

                    string kolicina = infoProstorija[4];
                    kolicina += "," + tb1;

                    if (idp == redStvari)
                    {
                        sveProstorije.RemoveAt(redStvari);
                        sveProstorije.Insert(redStvari, infoProstorija[0] + "/" + infoProstorija[1] + "/" + infoProstorija[2] + "/" + oprema + "/" + kolicina + "/" + infoProstorija[5]);
                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (Exception e) { }
            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }

        public void Obrisi(int currentRowIndex, int currentRowIndexo)
        {
            temp = currentRowIndex;
            int idp = 0;
            int ido = 0;
            string prostorija = "";

            ProstorijeFileStorage p = new ProstorijeFileStorage();
            List<string> sveProstorije = p.procitaneProstorije();
            List<string> sveOprema = svaOprema(temp);
            List<string> sveKolicina = svaKolicina(temp);
            try
            {
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');

                    if (idp == currentRowIndex)
                    {
                        foreach (string svaO in sveOprema)
                        {
                            if (ido == currentRowIndexo)
                            {
                                sveOprema.RemoveAt(currentRowIndexo);
                                sveKolicina.RemoveAt(currentRowIndexo);
                                sveProstorije.RemoveAt(currentRowIndex);

                                var resultO = string.Join(",", sveOprema.ToArray());
                                var resultK = string.Join(",", sveKolicina.ToArray());

                                sveProstorije.Insert(currentRowIndex, infoProstorija[0] + "/" + infoProstorija[1] + "/" + infoProstorija[2] + "/" + resultO + "/" + resultK + "/" + infoProstorija[5]);
                                File.WriteAllLines(@"prostorije.txt", sveProstorije);
                            }
                            ido++;
                        }
                    }
                    idp++;
                }
            }
            catch (Exception e) { }

            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }
      
      public void Prikazi(){}
      
      public void Update(int redProstorije, int currentRowIndex, string t1, string t2)
      {
            int idp = 0;
            string prostorija = "";

            ProstorijeFileStorage p = new ProstorijeFileStorage();
            List<string> sveProstorije = p.procitaneProstorije();
            List<string> sveOprema = svaOprema(redProstorije);
            List<string> sveKolicina = svaKolicina(redProstorije);
            try
            {
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    if (idp == redProstorije)
                    { 
                        sveOprema.RemoveAt(currentRowIndex);
                        sveOprema.Insert(currentRowIndex, t1);

                        sveKolicina.RemoveAt(currentRowIndex);
                        sveKolicina.Insert(currentRowIndex, t2);

                        sveProstorije.RemoveAt(redProstorije);

                        var resultO = string.Join(",", sveOprema.ToArray());
                        var resultK = string.Join(",", sveKolicina.ToArray());

                        sveProstorije.Insert(redProstorije, infoProstorija[0] + "/" + infoProstorija[1] + "/" + infoProstorija[2] + "/" + resultO + "/" + resultK + "/" + infoProstorija[5]);
                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (Exception e){ }

            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }

        public List<string> svaOprema(int temp)
        {
            int idp = 0;
            List<string> opremaL = new List<string>();

            using (var sr = new StreamReader("prostorije.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (idp == temp) {
                        String[] termin = line.Split('/');

                        String oprema = termin[3];

                        String[] pojedinacnaOprena = oprema.Split(',');
                        int s = pojedinacnaOprena.Length;

                        for (int i = 0; i < s; i++)
                        {
                            string pOprema = pojedinacnaOprena[i];
                            opremaL.Add(pOprema);
                        }
                    }
                    idp++;
                }
            }
            return opremaL;
        }

        public List<string> svaKolicina(int temp)
        {
            int idp = 0;
            List<string> kolicinaL = new List<string>();

            using (var sr = new StreamReader("prostorije.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (idp == temp)
                    {
                        String[] termin = line.Split('/');

                        String kolicina = termin[4];

                        String[] pojedinacnaKolicina = kolicina.Split(',');
                        int s = pojedinacnaKolicina.Length;

                        for (int i = 0; i < s; i++)
                        {
                            string pKolicina = pojedinacnaKolicina[i];
                            kolicinaL.Add(pKolicina);
                        }
                    }
                    idp++;
                }
            }
            return kolicinaL;
        }

        public int viseNegoDostupno(string oprema, int kolicina, int izabraniRed)
        {
            List<string> kolicinaL = svaKolicina(izabraniRed);
            List<string> opremaL = svaOprema(izabraniRed);

            int indexOpreme = opremaL.IndexOf(oprema);
            int kol = int.Parse(kolicinaL.ElementAt(indexOpreme));

            if ((kol - kolicina) < 0)
            {
                MessageBox.Show("izabrali ste previse opreme za premestanje");
                return 0;
            }
            else return kol - kolicina;
        }

    }
}