using System;
using System.Collections.ObjectModel;
using System.IO;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    public class UputiFileStorage
    {
        string jmbgPacijenta;
        string kojojUstanovi;
        string brojZdravstvenogKartona;
        string specijalizacija;
        string opis;

        public UputiFileStorage() { }

        public ObservableCollection<UputiFileStorage> Uputi
        {
            get;
            set;
        }
        public UputiFileStorage(string jmbg,string ustanovi,string brKartona,string spec ,string op) {
            Uputi = new ObservableCollection<UputiFileStorage>();

            jmbgPacijenta = jmbg;
            kojojUstanovi = ustanovi;
            brojZdravstvenogKartona = brKartona;
            specijalizacija = spec;
            opis = op;

        }
        public void Kreiraj()
        {
            Uputi = new ObservableCollection<UputiFileStorage>();

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("uputi.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    String[] termin = line.Split('/');

                    sw.WriteLine(line);

                }
                sw.WriteLine(jmbgPacijenta + "/" + kojojUstanovi + "/" + brojZdravstvenogKartona + "/" + specijalizacija + "/"+ opis);


            }
            File.Delete("uputi.txt");
            File.Move(tempFile, "uputi.txt");

        }


        public void SacuvajUputZaBolnicu(string jmbg, string brk, string soba, string krevet, DateTime datumd, DateTime datumo, string dijag)
        {
            Uputi = new ObservableCollection<UputiFileStorage>();

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("uputiBolnica.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    String[] termin = line.Split('/');

                    sw.WriteLine(line);

                }
                sw.WriteLine(jmbg + "/" + brk + "/" + soba + "/" + krevet + "/" + datumd.ToString("D") + "/" + datumo.ToString("D") + "/" + dijag);


            }
            File.Delete("uputiBolnica.txt");
            File.Move(tempFile, "uputiBolnica.txt");

        }
    }
   
}
