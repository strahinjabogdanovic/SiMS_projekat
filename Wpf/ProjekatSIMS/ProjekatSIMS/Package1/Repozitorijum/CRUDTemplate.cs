using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    public abstract class CRUDTemplate
    {
        public String s1;
        public String s2;
        public String s3;
        public String s4;
        public int c;
        public String update;
        //template method
        public void Start()
        {
            Kreiraj(s1, s2, s3, s4);
            Obrisi(c);
            Izmeni(update, c);
            Read();
        }
        public abstract void Kreiraj(String s1, String s2, String s3, String s4);

        public abstract void Obrisi(int currentRowIndex);

        public abstract void Izmeni(string update, int c);

        public abstract List<string> Read();




    }
}