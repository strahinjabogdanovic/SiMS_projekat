using ProjekatSIMS.Package1.Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class SveInfoUpravnikVM : BindableBase
    {
        private SveInfoPage page;
        private string s1;
        private string s2;
        private string s3;
        private string s4;
        private string s5;
        public SveInfoUpravnikVM(SveInfoPage page, int currentRowIndex)
        {
            this.page = page;
            int idp = 0;
            string prostorija = "";

            ProstorijeKontroler pk = new ProstorijeKontroler();

            List<string> sveProstorije = pk.procitaneProstorije();
            foreach (string sveP in sveProstorije)
            {
                if (idp == currentRowIndex)
                {
                    prostorija = sveP;
                }
                idp++;
            }
            string[] infoProstorija = prostorija.Split('/');
            S1 = infoProstorija[0];
            S2 = infoProstorija[1];
            S3 = infoProstorija[2];
            S4 = infoProstorija[3];
            S5 = infoProstorija[5];
        }
        public string S1
        {
            get { return s1; }
            set
            {
                if (s1 != value)
                {
                    s1 = value;
                    OnPropertyChanged("S1");
                }
            }
        }
        public string S2
        {
            get { return s2; }
            set
            {
                if (s2 != value)
                {
                    s2 = value;
                    OnPropertyChanged("S2");
                }
            }
        }
        public string S3
        {
            get { return s3; }
            set
            {
                if (s3 != value)
                {
                    s3 = value;
                    OnPropertyChanged("S3");
                }
            }
        }
        public string S4
        {
            get { return s4; }
            set
            {
                if (s4 != value)
                {
                    s4 = value;
                    OnPropertyChanged("S4");
                }
            }
        }
        public string S5
        {
            get { return s5; }
            set
            {
                if (s5 != value)
                {
                    s5 = value;
                    OnPropertyChanged("S5");
                }
            }
        }

    }
}
