using ProjekatSIMS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Package1
{
   public class GuestFileStorage
   {
        public void Kreiraj(string guestNalog)
        {
            var text = File.ReadAllText(@"naloziGuest.txt");
            File.WriteAllText(@"naloziGuest.txt", text + guestNalog + Environment.NewLine);
        }

        public void Obrisi(int currentRowIndex)
        {
            try
            {
                int id = 0;
                GuestFileStorage g = new GuestFileStorage();
                List<string> sviNalozi = g.procitaniGuestNalozi();
                foreach (string sviN in sviNalozi)
                {
                    if (id == currentRowIndex)
                    {
                        sviNalozi.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"naloziGuest.txt", sviNalozi);
                    }
                    id++;
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
                    guestNalozi.Add(line);
                }
            }
            return guestNalozi;
        }
    }
}