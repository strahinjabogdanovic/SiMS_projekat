using Package1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    public partial class SveInfoUpravnik : Window
    {
        public SveInfoUpravnik(int currentRowIndex)
        {
            int idp = 0;
            string prostorija = "";

            InitializeComponent();

            ProstorijeFileStorage p = new ProstorijeFileStorage();

            List<string> sveProstorije = p.procitaneProstorije();
            foreach (string sveP in sveProstorije)
            {
                if (idp == currentRowIndex)
                {
                    prostorija = sveP;
                }
                idp++;
            }
            string[] infoProstorija = prostorija.Split('/');
            t0.Text = infoProstorija[0];
            t1.Text = infoProstorija[1];
            t2.Text = infoProstorija[2];
            t3.Text = infoProstorija[3];
            t4.Text = infoProstorija[5];
        }
    }
}
