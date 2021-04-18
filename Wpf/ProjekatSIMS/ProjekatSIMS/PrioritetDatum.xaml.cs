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
    /// Interaction logic for PrioritetDatum.xaml
    /// </summary>
    public partial class PrioritetDatum : Window
    {
        public PrioritetDatum()
        {
            InitializeComponent();

            /*string datt = tb1.Text;

            using (var sr = new System.IO.StreamReader("termini.txt"))
            {
                string line;
                DateTime ter = DateTime.Now;

                Console.WriteLine(datt);

                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');

                    if (termin[0].Equals(datt)) {

                        String[] dat = termin[0].Split('.');
                        String datum = dat[2] + "/" + dat[1] + "/" + dat[0];
                        String vreme = termin[1] + ":00";
                        String d = datum + " " + vreme;
                        DateTime t2 = DateTime.Now;
                        Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                        DateTime parsedDate = DateTime.Parse(d);

                        using (var sr2 = new System.IO.StreamReader("termini.txt"))
                        {

                            String datum2 = "";
                            String vreme2 = "";
                
                            DateTime parsedDate33 = DateTime.Parse("2100/2/1 00:00:00");
                            TimeSpan span = parsedDate33.Subtract(parsedDate);

                            while ((line = sr.ReadLine()) != null)
                            {

                                String[] termin2 = line.Split('/');

                                String[] dat2 = termin2[0].Split('.');
                                datum2 = dat2[2] + "/" + dat2[1] + "/" + dat2[0];
                                vreme2 = termin2[1] + ":00";
                                String d2 = datum2 + " " + vreme2;
                       
                                Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                                DateTime parsedDate2 = DateTime.Parse(d2);

                                if (termin[0].Equals(termin2[0]))
                                {

                                    if (DateTime.Compare(parsedDate.AddMinutes(30), parsedDate2) != 0) {
                                        ComboBoxItem newitem2 = new ComboBoxItem();
                                        newitem2.Content = parsedDate.AddMinutes(30).ToString();
                                        cb1.Items.Add(newitem2);
                                    }

                                }

                            }



                        }


                    }
                }*/
        }


        private void DatumZakaz_Click(object sender, RoutedEventArgs e)
        {
            DatumZakaz dz = new DatumZakaz(tb1.Text);
            dz.ShowDialog();
        }

    }
}

