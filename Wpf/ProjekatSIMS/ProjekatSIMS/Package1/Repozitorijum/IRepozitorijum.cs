using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    interface IRepozitorijum<T>
    {
        List<AnketaBolnica> getAll(String path);
        void saveAll(List<AnketaBolnica> items, String path);
    }
}
