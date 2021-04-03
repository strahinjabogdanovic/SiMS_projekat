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
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public Window2()
        {

            int currentRowIndex = 0;
            InitializeComponent();

            using (var sr = new StreamReader("redovi.txt"))
            {

                String line = "";

                line = sr.ReadLine();
                currentRowIndex = int.Parse(line);
            }
            using (var sr = new StreamReader("podaci.txt"))
            {

                string line;
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (idp == currentRowIndex)
                    {

                        String[] termin = line.Split('/');
                        String ime = termin[0];
                        String prezime = termin[1];
                        String jmbg = termin[2];
                        String pol = termin[3];
                        String datumr = termin[4];
                        String mail = termin[5];
                        String broj = termin[6];
                        String adresa = termin[7];
                        String idd = termin[8];

                        t1.Text = ime;
                        t2.Text = prezime;
                        t3.Text = jmbg;
                        t4.Text = pol;
                        t5.Text = datumr;
                        t6.Text = mail;
                        t7.Text = broj;
                        t8.Text = adresa;
                        t9.Text = idd;
                    }
                    idp++;

                }


            }
        }
    }
}
