using ProjekatSIMS.Package1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    class ReceptiFileStorage
    {
        private string filePath;

        public ObservableCollection<Recepti> ReceptiSpisak { get; private set; }

        public ReceptiFileStorage()
        {

        }
        public string CitanjeSpiska(string jmbg)
        {
            filePath = "recepti.txt";
            ReceptiSpisak = new ObservableCollection<Recepti>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();
            string tJmbg = jmbg;

            foreach (string linee in lines)
            {
                String[] deo = linee.Split('/');
                var recept = new Recepti();

                recept.sifraLeka = deo[0].ToString();
                recept.nazivLeka = deo[1].ToString();
                recept.nacinUzimanja = deo[2].ToString();
                recept.naKolikoSati = int.Parse(deo[3].ToString());
                recept.jmbg = deo[4];

                if (tJmbg == recept.jmbg)
                {
                    ReceptiSpisak.Add(recept);
                }
            }


            StreamReader sr = new StreamReader("recepti.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            sr.Close();
            return tJmbg;
        }
        public List<string> Citanje()
        {
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("recepti.txt").ToList();
            return lines;
        }
        public void Kreiraj(string s1, string s2, string s3, string s4, string s5)
        {
            var text = File.ReadAllText(@"recepti.txt");
            File.WriteAllText(@"recepti.txt", text + s1 + "/" + s2 + "/" + s3 + "/" + s4 + "/" + s5 + "/" + Environment.NewLine);

        }
    }
}
