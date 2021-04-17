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
    /// Interaction logic for SveInfoUpravnik.xaml
    /// </summary>
    public partial class SveInfoUpravnik : Window
    {
        public SveInfoUpravnik()
        {
            int currentRowIndex = 0;
            InitializeComponent();

            using (var sr = new StreamReader("redovi1.txt"))
            {

                String line = "";

                line = sr.ReadLine();
                currentRowIndex = int.Parse(line);
            }
            using (var sr = new StreamReader("prostorije.txt"))
            {

                string line;
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (idp == currentRowIndex)
                    {

                        String[] termin = line.Split('/');
                        String ime = termin[0];
                        String oznaka = termin[1];
                        String namena = termin[2];
                        String oprema = termin[3];
                        

                        t1.Text = ime;
                        t2.Text = oznaka;
                        t3.Text = namena;
                        t4.Text = oprema;
                        
                    }
                    idp++;

                }
            }
        }
    }
}
