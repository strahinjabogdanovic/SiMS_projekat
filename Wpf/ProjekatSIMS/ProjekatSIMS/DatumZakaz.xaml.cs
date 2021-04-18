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
using Package1;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for DatumZakaz.xaml
    /// </summary>
    public partial class DatumZakaz : Window
    {

        string doktor = "";

        public DatumZakaz(String datt)
        {
            InitializeComponent();
            int br = 0;
            using (var sr = new System.IO.StreamReader("termini.txt"))
            {
                string line;
                DateTime ter = DateTime.Now;

                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');

                    if (termin[0].Equals(datt))
                    {
                        br++;

                        String[] dat = termin[0].Split('.');
                        String datum = dat[2] + "/" + dat[1] + "/" + dat[0];
                        String vreme = termin[1] + ":00";
                        String d = datum + " " + vreme;
                        DateTime t2 = DateTime.Now;
                        Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                        DateTime parsedDate = DateTime.Parse(d);
                        doktor = termin[2];

                        using (var sr2 = new System.IO.StreamReader("termini.txt"))
                        {

                            String datum2 = "";
                            String vreme2 = "";

                            DateTime parsedDate33 = DateTime.Parse("2100/2/1 00:00:00");
                            TimeSpan span = parsedDate33.Subtract(parsedDate);

                            int i = 0;
                            while ((line = sr2.ReadLine()) != null)
                            {

                                String[] termin2 = line.Split('/');

                                String[] dat2 = termin2[0].Split('.');
                                datum2 = dat2[2] + "/" + dat2[1] + "/" + dat2[0];
                                vreme2 = termin2[1] + ":00";
                                String d2 = datum2 + " " + vreme2;
                            

                                Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                                DateTime parsedDate2 = DateTime.Parse(d2);

                                if (termin[0].Equals(termin2[0]) && termin[2].Equals(termin2[2]))
                                {

                                    if (DateTime.Compare(parsedDate, parsedDate2) < 0)
                                    {
                                        if (DateTime.Compare(parsedDate.AddMinutes(30), parsedDate2) != 0)
                                        {
                                            ComboBoxItem newitem2 = new ComboBoxItem();
                                            newitem2.Content = parsedDate.AddMinutes(30).ToString();
                                            cb1.Items.Add(newitem2);
                                        }
                                        i++;
                                    }
                                    else if (DateTime.Compare(parsedDate, parsedDate2) > 0)
                                    {
                                        if (DateTime.Compare(parsedDate2.AddMinutes(30), parsedDate) != 0)
                                        {
                                            ComboBoxItem newitem2 = new ComboBoxItem();
                                            newitem2.Content = parsedDate2.AddMinutes(30).ToString();
                                            cb1.Items.Add(newitem2);
                                        }
                                        i++;
                                    }


                                }
                         
                                if (i == 0)
                                {
                                    String[] t = datt.Split('.');
                                    DateTime parsedDate332 = DateTime.Parse(t[2] + "/" + t[1] + "/" + t[0] + " " + "08:00:00");
                                    if (DateTime.Compare(parsedDate, parsedDate332) != 0)
                                    {
                                        ComboBoxItem newitem2 = new ComboBoxItem();
                                        newitem2.Content = parsedDate332.ToString();
                                        cb1.Items.Add(newitem2);
                                        i++;
                                    }
                                    else
                                    {
                                        ComboBoxItem newitem2 = new ComboBoxItem();
                                        newitem2.Content = parsedDate332.AddMinutes(30).ToString();
                                        cb1.Items.Add(newitem2);
                                        i++;
                                    }

                                }
                                else if (i < 3)
                                {
                                    ComboBoxItem newitem2 = new ComboBoxItem();
                                    newitem2.Content = parsedDate.AddMinutes(i * 30).ToString();
                                    cb1.Items.Add(newitem2);


                                    ComboBoxItem newitem3 = new ComboBoxItem();
                                    newitem3.Content = parsedDate.AddMinutes(i * 30 + 30).ToString();
                                    cb1.Items.Add(newitem3);

                                    i += 2;
                                }

                            }



                        }


                    }

                }
                if (br == 0)
                {

                    String[] t = datt.Split('.');
                    DateTime parsedDate332 = DateTime.Parse(t[2] + "/" + t[1] + "/" + t[0] + " " + "08:00:00");
                    ComboBoxItem newitem1 = new ComboBoxItem();
                    newitem1.Content = parsedDate332.ToString();
                    cb1.Items.Add(newitem1);
                    ComboBoxItem newitem2 = new ComboBoxItem();
                    newitem2.Content = parsedDate332.AddMinutes(30).ToString();
                    cb1.Items.Add(newitem2);
                    ComboBoxItem newitem3 = new ComboBoxItem();
                    newitem3.Content = parsedDate332.AddMinutes(60).ToString();
                    cb1.Items.Add(newitem3);

                    using (var srr = new System.IO.StreamReader("doktori.txt"))
                    {
                        string lines = "";
                        while ((lines = srr.ReadLine()) != null)
                        {
                            String[] termink = lines.Split('/');
                            doktor = termink[0];

                        }
                    }
                }

            }
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string c = cb1.SelectedValue.ToString();
            Console.WriteLine(c);
            String[] cc = c.Split(' ');
            String d = cc[1];
            String[] dd = d.Split('/');
            String datum = dd[1] + "." + dd[0] + "." + dd[2] + ".";
            String vr = cc[2];
            String[] vrvr = vr.Split(':');
            String vreme = "";
            if (vrvr[2].Equals("PM"))
            {
                int t = int.Parse(vrvr[0]) + 12;
                vreme = t.ToString() + ":" + vrvr[1];
            }
            else
            {
                vreme = vrvr[0] + ":" + vrvr[1];
            }

            PacijentFileStorage pfs = new PacijentFileStorage();
            pfs.Kreiraj(doktor, datum, vreme);
        }
    }
}

