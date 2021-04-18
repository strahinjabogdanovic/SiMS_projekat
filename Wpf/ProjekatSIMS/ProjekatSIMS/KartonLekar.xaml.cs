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
    /// Interaction logic for KartonLekar.xaml
    /// </summary>
    public partial class KartonLekar : Window
    {
        public KartonLekar(DataGrid dataGridLekar)
        {
            InitializeComponent();


            String ime = "";
            String prezime = "";
            String jmbg = "";
            String pol = "";
            String datumr = "";
            String mail = "";
            String broj = "";
            String adresa = "";
            String idd = "";


            int currentRowIndex = dataGridLekar.Items.IndexOf(dataGridLekar.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekar.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                string line;
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //id++;
                    if (idp == currentRowIndex)
                    {


                        String[] termin = line.Split('/');
                        jmbg = termin[6];
                        t2.Text = jmbg;
                        using (var sars = new StreamReader("podaci.txt"))

                        {

                            string liness;
                            int idps = 0;
                            while ((liness = sars.ReadLine()) != null)
                            {
                                //if (idps == currentRowIndex)
                                //{


                                String[] termini = liness.Split('/');
                                String idK = termini[2];

                                Console.WriteLine(idK);
                                Console.WriteLine(idd);
                                ime = termini[0];
                                prezime = termini[1];
                                pol = termini[3];
                                datumr = termini[4];
                                mail = termini[5];
                                broj = termini[6];
                                adresa = termini[7];
                                if (idK == jmbg)
                                {

                                    t.Text = ime;
                                    t1.Text = prezime;
                                    t2.Text = jmbg;
                                    t3.Text = pol;
                                    t4.Text = datumr;
                                    t5.Text = mail;
                                    t6.Text = broj;
                                    t7.Text = adresa;
                                }
                                idps++;

                            }

                        }

                    }
                    idp++;
                }


            }
        }





        private void Recepti_Click(object sender, RoutedEventArgs e)
        {
            SpisakRecepata sr = new SpisakRecepata(t2);
            sr.ShowDialog();
        }

        private void Napisi_izvestaj(object sender, RoutedEventArgs e)
        {
            Izvestaj iz = new Izvestaj(t, t1, t2);
            iz.ShowDialog();
        }


        private void Izvest_Click(object sender, RoutedEventArgs e)
        {
            Izvestaji_o_pregledu_stanja izv = new Izvestaji_o_pregledu_stanja(t2);
            izv.ShowDialog();
        }
    }
}
