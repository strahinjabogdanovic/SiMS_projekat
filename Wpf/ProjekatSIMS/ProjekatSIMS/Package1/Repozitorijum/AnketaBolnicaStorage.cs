using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    class AnketaBolnicaStorage : RepozImplementacija<AnketaBolnica>
    {
        public List<AnketaBolnica> anketeBolnica { get; set; }

        public AnketaBolnicaStorage()
        {
            anketeBolnica = new List<AnketaBolnica>();
            anketeBolnica = getAll("anketaBolnica.txt");
        }

        public List<AnketaBolnica> GetAll()
        {
            return getAll("anketaBolnica.txt");
        }

        public void Save(AnketaBolnica newSurvey)
        {
            anketeBolnica.Add(newSurvey);
            saveAll(anketeBolnica, "anketaBolnica.txt");
        }
    }

}
