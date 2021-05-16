using ProjekatSIMS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Package1
{
   public class GuestFileStorage
   {
        public ObservableCollection<GuestNalog> Guest
        {
            get;
            set;
        }

        public void Kreiraj(string guestNalog)
        {
            var text = File.ReadAllText(@"naloziGuest.txt");
            File.WriteAllText(@"naloziGuest.txt", text + guestNalog + Environment.NewLine);

        }

        public void Obrisi(int currentRowIndex)
        {
            try
            {
                int idp = 0;
                GuestFileStorage p = new GuestFileStorage();
                List<string> sviNalozi = p.procitaniGuestNalozi();
                foreach (string sviN in sviNalozi)
                {
                    if (idp == currentRowIndex)
                    {
                        sviNalozi.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"naloziGuest.txt", sviNalozi);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }
        }


        public List<string> procitaniGuestNalozi()
        {
            List<string> guestNalozi = new List<string>();

            using (var sr = new StreamReader("naloziGuest.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] informacije = line.Split('/');
                    String ime = informacije[0];
                    String prezime = informacije[1];
                    String jmbg = informacije[2];

                    guestNalozi.Add(ime + "/" + prezime + "/" + jmbg);
                }
            }
            return guestNalozi;
        }
    }
}