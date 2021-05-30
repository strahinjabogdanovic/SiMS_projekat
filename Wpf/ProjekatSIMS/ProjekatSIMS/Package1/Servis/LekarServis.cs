using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    class LekarServis
    {
        public LekarServis() { }

        public void SacuvajUputZaBolnicu(string JmbgP, string brk, string soba, string krevet, DateTime datumd, DateTime datumo, string dijag)
        {
            UputiFileStorage u = new UputiFileStorage();
            u.SacuvajUputZaBolnicu(JmbgP, brk, soba, krevet, datumd, datumo, dijag);
        }
    }
}
