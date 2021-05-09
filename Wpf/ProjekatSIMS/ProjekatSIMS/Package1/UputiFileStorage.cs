using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1
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
    }
   
}
