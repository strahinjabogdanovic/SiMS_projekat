using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS.Package1.Kontroler
{
    class LekarKontroler
    {
        public LekarKontroler() { }
        private LekarServis ls = new LekarServis();

        public void SacuvajUputZaBolnicu(string jmbg, string brk, string soba, string krevet, DateTime datumd, DateTime datumo, string dijag)
        {
            ls.SacuvajUputZaBolnicu(jmbg, brk, soba, krevet, datumd, datumo, dijag);
        }
    }
}