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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PrioritetLekar.xaml
    /// </summary>
    public partial class PrioritetLekar : Window
    {
        public PrioritetLekar()
        {
            InitializeComponent();

            /*using (var sr = new System.IO.StreamReader("doktori.txt"))
            {
                string line;
                String doktori = "";
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');

                    doktori = termin[0];

                    ComboBoxItem newitem2 = new ComboBoxItem();
                    newitem2.Content = doktori;
                    cb1.Items.Add(newitem2);

                }


            }

            using (var sr = new System.IO.StreamReader("termini.txt"))
            {
                string line;
                String datum = "";
                String vreme = "";
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');

                    if (cb1.SelectedValue.ToString().Contains(termin[2])) {

                        String[] dat = termin[0].Split('.');
                        datum = dat[2] + "/" + dat[1] + "/" + dat[0];
                        vreme = termin[1] + ":00";
                        String d = datum + " " + vreme;
                        DateTime t = DateTime.Now;

                        Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                        DateTime parsedDate = DateTime.Parse(d);

                        using (var sr2 = new System.IO.StreamReader("termini.txt")) {

                            String datum2 = "";
                            String vreme2 = "";
                            DateTime ter = t;
                            DateTime parsedDate33 = DateTime.Parse("2100/2/1 00:00:00");
                            TimeSpan span = parsedDate33.Subtract(parsedDate);

                            while ((line = sr.ReadLine()) != null) {

                                String[] termin2 = line.Split('/');

                                String[] dat2 = termin2[0].Split('.');
                                datum2 = dat2[2] + "/" + dat2[1] + "/" + dat2[0];
                                vreme2 = termin2[1] + ":00";
                                String d2 = datum2 + " " + vreme2;
                                DateTime t2 = DateTime.Now;

                                Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                                DateTime parsedDate2 = DateTime.Parse(d2);

                                if (cb1.SelectedValue.ToString().Contains(termin2[2])) {
                                    if (datum.Equals(datum2))
                                    {
                                        if (DateTime.Compare(parsedDate, parsedDate2) == 1)
                                        {
                                            TimeSpan sp = parsedDate.Subtract(parsedDate2);
                                            if (sp < span)
                                            {
                                                span = sp;
                                                ter = parsedDate2;
                                            }
                                        }
                                        else if (DateTime.Compare(parsedDate, parsedDate2) < 0) {
                                            TimeSpan sp = parsedDate2.Subtract(parsedDate);
                                            if (sp < span)
                                            {
                                                span = sp;
                                                ter = parsedDate;
                                            }

                                        }

                                        TimeSpan tf = TimeSpan.Parse("00:30:00");
                                        if (span < tf) {
                                            spans[i] = span.ToString();
                                            times[i] = ter.ToString();
                                        
                                        }
                                    } 
                                }

                                i++;

                            }



                        }

                    }



                }
            }

            */


        }
        private void LekarZakaz_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
