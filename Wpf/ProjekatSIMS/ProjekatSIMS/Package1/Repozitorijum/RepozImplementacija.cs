using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    class RepozImplementacija<T> : IRepozitorijum<T>
    {

        public List<AnketaBolnica> getAll(string path)
        {
            List<AnketaBolnica> items = new List<AnketaBolnica>();
            using (var sars = new StreamReader(path))
            {
                string lines;
                while ((lines = sars.ReadLine()) != null)
                {
                    var anketa = new AnketaBolnica();
                    String[] deo = lines.Split('|');
                    anketa.usluga = deo[0];
                    anketa.zaposleni = deo[1];
                    anketa.prostorija = deo[2];
                    anketa.komentar = deo[3];
                    anketa.datum = deo[4];
                    items.Add(anketa);
                }
            }
            return items;
        }

        public void saveAll(List<AnketaBolnica> items, string path)
        {

            using (var sw = new StreamWriter(path))
            {
                foreach (AnketaBolnica a in items)
                {
                    sw.WriteLine(a.usluga + "|" + a.zaposleni + "|" + a.prostorija + "|" + a.komentar + "|" + a.datum);
                }
            }

        }

    }
}
