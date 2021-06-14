using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    public class TerminContext
    {

        private NalazenjeTermina nalazenjeTermina;

        public void setStrategy(NalazenjeTermina nalazenjeTermina)
        {
            this.nalazenjeTermina = nalazenjeTermina;
        }

        public List<String> NadjiTermin(string filter)
        {

            return nalazenjeTermina.NadjiTermin(filter);

        }
    }
}
