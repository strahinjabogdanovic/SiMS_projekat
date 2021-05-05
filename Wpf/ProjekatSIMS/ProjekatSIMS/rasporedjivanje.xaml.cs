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
    public partial class rasporedjivanje : Window
    {
        String ime = "";
        int currentRowIndex = 0;
        public rasporedjivanje()
        {
            InitializeComponent();


            using (var rsr = new StreamReader("redzarasp.txt"))
            {
                String sdfg = "";

                sdfg = rsr.ReadLine();
                currentRowIndex = int.Parse(sdfg);
            }
            using (var sr = new StreamReader("prostorije.txt"))
            {

                string line;
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (idp != currentRowIndex)
                    {
                        String[] termin = line.Split('/');

                        ime = termin[0];
                        ComboBoxItem newitem = new ComboBoxItem();
                        newitem.Content = ime;
                        cb1.Items.Add(newitem);

                    }
                    idp++;
                }
            }
        }

        private void potvrdi_click(object sender, RoutedEventArgs e)
        {
            String naziv = t2.Text;
            String kolicina = t1.Text;
            int intkol = int.Parse(kolicina);

            string tempFile = System.IO.Path.GetTempFileName();
            using (var sr = new StreamReader("prostorije.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                string line;
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    string s1 = termin[0];
                    string s2 = termin[1];
                    string s3 = termin[2];

                    if (idp == currentRowIndex)
                    {
                        string selektovan_red_stv = termin[3];
                        string[] sstv = selektovan_red_stv.Split(',');
                        int duzina_stvari = sstv.Length;

                        string kol_sel_red = termin[4];
                        string[] skool = kol_sel_red.Split(',');

                        string nesto = "";
                        string knesto = "";
                        int br = 0;
                        for (int i = 0; i < duzina_stvari; i++)
                        {
                            if (sstv[i].Equals(naziv))
                            {
                                if (i == 0)
                                {
                                    ++br;
                                }
                                int temp = int.Parse(skool[i]);
                                temp -= intkol;
                                if (temp < 0)
                                {
                                    MessageBox.Show("izabrali ste previse opreme za premestanje");
                                    intkol = int.Parse(skool[i]);

                                }

                                else if (temp != 0)
                                {

                                    if (i == 0)
                                    {
                                        nesto += sstv[i] + ",";
                                        knesto += temp.ToString() + ",";
                                    }
                                    else
                                    {
                                        nesto += "," + sstv[i];
                                        knesto += "," + temp.ToString();
                                    }
                                }
                            }
                            else
                            {
                                int brr = 0;
                                if (br > 0)
                                {
                                    ++brr;
                                }
                                if (i == brr)
                                {
                                    nesto += sstv[i];
                                    knesto += skool[i];
                                }
                                else
                                {
                                    nesto += "," + sstv[i];
                                    knesto += "," + skool[i];
                                }

                            }
                        }
                        
                        sw.WriteLine(s1 + "/" + s2 + "/" + s3 + "/" + nesto + "/" + knesto);
                    }
                    else if (cb1.SelectedValue.ToString().Contains(termin[0]))
                    {

                        string stvari = termin[3];
                        string[] stv = stvari.Split(',');
                        int duzina_stvari = stv.Length;

                        string koll = termin[4];
                        string[] kool = koll.Split(',');

                        int brojac = 0;
                        string nova_kol = "";
                        for (int i = 0; i < duzina_stvari; i++)
                        {
                            if (stv[i].Equals(naziv))
                            {
                                int nova = int.Parse(kool[i]);
                                nova += intkol;
                                if (i == 0)
                                {
                                    nova_kol = nova.ToString();
                                    for (int j = 1; j < duzina_stvari; j++)
                                    {
                                        nova_kol += "," + kool[j];
                                    }
                                }
                                else
                                {
                                    nova_kol = kool[0];
                                    for (int j = 1; j < i; j++)
                                    {
                                        nova_kol += "," + kool[j];
                                    }
                                    nova_kol += "," + nova.ToString();
                                    int crio = ++i;
                                    for (int j = crio; j < duzina_stvari; j++)
                                    {
                                        nova_kol += "," + kool[j];
                                    }
                                }
                                
                                sw.WriteLine(s1 + "/" + s2 + "/" + s3 + "/" + stvari + "/" + nova_kol);
                                //break;
                                brojac++;
                            }
                            else if (i == (duzina_stvari-1) && brojac == 0)
                            {
                                stvari += "," + naziv;
                                koll += "," + kolicina;
                                sw.WriteLine(s1 + "/" + s2 + "/" + s3 + "/" + stvari + "/" + koll);
                            }
                        }
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    idp++;
                }
            }
            File.Delete("prostorije.txt");
            File.Move(tempFile, "prostorije.txt");
            Close();
        }
    }
}