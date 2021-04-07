using ProjekatSIMS;
using System;
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

        public void Kreiraj(string tb,string tb1,string tb2)
      {
            Guest = new ObservableCollection<GuestNalog>();


            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("naloziGuest.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                //int id = 0;
                while ((line = sr.ReadLine()) != null)
                {

                    String[] termin = line.Split('/');
                    var guest = new GuestNalog();
                    //id = int.Parse(termin[8]);
                    //id++;

                    sw.WriteLine(line);

                }
                sw.WriteLine(tb + "/" + tb1 + "/" + tb2);


            }
            File.Delete("naloziGuest.txt");
            File.Move(tempFile, "naloziGuest.txt");



            //Close();
            //GuestNalozi s = new GuestNalozi();
            //s.ShowDialog();
            //PageGuestNalozi p = new PageGuestNalozi();
        }
      
      public void Obrisi(GuestNalog k)
      {
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("naloziGuest.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Guest = new ObservableCollection<GuestNalog>();

                    var priv = new GuestNalog();

                    String[] termin = line.Split('/');
                    priv.jmbg = long.Parse(termin[2].ToString());

                    if (priv.jmbg != k.jmbg)
                        sw.WriteLine(line);
                }
            }

            File.Delete("naloziGuest.txt");
            File.Move(tempFile, "naloziGuest.txt");
        }
      
   
   }
}