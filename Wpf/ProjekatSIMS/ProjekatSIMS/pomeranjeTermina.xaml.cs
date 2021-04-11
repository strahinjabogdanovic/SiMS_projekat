using System;
using System.Collections.Generic;
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
using ProjekatSIMS;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using ProjekatSIMS.Package1;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for pomeranjeTermina.xaml
    /// </summary>
    public partial class pomeranjeTermina : Window
    {
        string datum1 = "";
        string datum2 = "";
        String[] snj;
        int klj = 0;
        int klj1 = 0;
        int klj2 = 0;
        int god = 0;

        public pomeranjeTermina()
        {
            InitializeComponent();
            int currentRowIndex = 0;
           



            using (var sr = new StreamReader("redoviPacijent.txt"))
            {

                String line = "";

                line = sr.ReadLine();
                currentRowIndex = int.Parse(line);
            }

            int datum = 0;

          

            using (var sr = new StreamReader("termini.txt"))
            {

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {

                    if (id == currentRowIndex)
                    {

                        String[] termin = line.Split('/');

                        snj = termin[0].Split('.');
                        datum = int.Parse(snj[0]);

                        klj = int.Parse(snj[1]);
                        klj1 = int.Parse(snj[1]);
                        klj2 = int.Parse(snj[1]);
                        god = int.Parse(snj[2]);

                        if (klj == 1 || klj == 3 || klj == 5 || klj == 7 || klj == 8 || klj == 10 || klj == 12)
                        {
                            if (datum == 30)
                            {
                                datum1 = 31.ToString();
                                datum2 = 1.ToString();
                                if (klj == 12)
                                {
                                    snj[1] = 1.ToString();
                                    ++god;

                                }
                                else
                                {
                                    ++klj2;

                                }

                            }
                            else if (datum == 31)
                            {
                                datum1 = 1.ToString();
                                datum2 = 2.ToString();
                                if (klj == 12) { snj[1] = 1.ToString(); ++god; }
                                else
                                {
                                    ++klj1;
                                    ++klj2;

                                }

                            }
                            else
                            {
                                datum1 = (++datum).ToString();
                                datum2 = (++datum).ToString();
                            }
                        }
                        else if (klj == 2)
                        {
                            if (datum == 27)
                            {
                                datum1 = 28.ToString();
                                datum2 = 1.ToString();

                                ++klj2;

                            }
                            else if (datum == 28)
                            {
                                datum1 = 1.ToString();
                                datum2 = 2.ToString();

                                ++klj1;
                                ++klj2;


                            }
                            else
                            {
                                datum1 = (++datum).ToString();
                                datum2 = (++datum).ToString();
                            }
                        }
                        else if(klj == 4 || klj == 6 || klj == 9 || klj == 11) {

                            if (datum == 29)
                            {
                                datum1 = 30.ToString();
                                datum2 = 1.ToString();

                                ++klj2;

                            }
                            else if (datum == 30)
                            {
                                datum1 = 1.ToString();
                                datum2 = 2.ToString();

                                ++klj1;
                                ++klj2;


                            }
                            else
                            {
                                datum1 = (++datum).ToString();
                                datum2 = (++datum).ToString();
                            }
                        }


                        ComboBoxItem newitem = new ComboBoxItem();
                        newitem.Content = datum1 + "." + klj1 + "." + god + ".";
                        cb1.Items.Add(newitem);

                        ComboBoxItem newitem2 = new ComboBoxItem();
                        newitem2.Content = datum2 + "." + klj2 + "." + god + ".";
                        cb1.Items.Add(newitem2);
                    }

                    id++;
                }
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tempFile = System.IO.Path.GetTempFileName();

            int currentRowIndex = 0;

            using (var sre = new StreamReader("redoviPacijent.txt"))
            {

                String line = "";

                line = sre.ReadLine();
                currentRowIndex = int.Parse(line);
            }


            using (var sr = new StreamReader("termini.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                int idx = 0;
                string line;
                int id = 0;
              

              
                while ((line = sr.ReadLine()) != null)
                {
                    //id++;
                    if (id == currentRowIndex)
                    {
                        String[] termin = line.Split('/');
                        var pacijent = new TerminiPacijenata();
                        idx = int.Parse(termin[4]);

                        string slj = "";
                        string gdatum = cb1.SelectedValue.ToString();


                        if (gdatum != null)
                        {

                            if (gdatum.Contains(datum1))
                            {
                                
                                slj = datum1;
                                klj = klj1;

                            }
                            else if (gdatum.Contains(datum2))
                            {
                                
                                slj = datum2;
                                klj = klj2;
                            }
                        }

                        sw.WriteLine(slj + "." + klj + "." + god + "." +  "/" + termin[1] + "/" + termin[2] + "/" + termin[3] + "/" + termin[4]);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    id++;
                }
            }
            File.Delete("termini.txt");
            File.Move(tempFile, "termini.txt");

            Close();
            PacijentPocetnaStranica pp = new PacijentPocetnaStranica();
            pp.ShowDialog();
        }
    }

}
