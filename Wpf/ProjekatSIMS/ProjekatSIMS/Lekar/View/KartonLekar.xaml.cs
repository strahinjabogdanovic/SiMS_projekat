using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for KartonLekar.xaml
    /// </summary>
    public partial class KartonLekar : Window
    {

        public String ime = "";
        public String prezime = "";
        String jmbg = "";
        String pol = "";
        String datumr = "";
        String mail = "";
        String broj = "";
        String adresa = "";
        String idd = "";
        public KartonLekar() {  }
        public KartonLekar(DataGrid dataGridLekar)
        {
            InitializeComponent();

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

        public KartonLekar(string jmbg)
        {
            InitializeComponent();
            using (var sars = new StreamReader("podaci.txt"))

            {

                string line;
                int idps = 0;
                while ((line = sars.ReadLine()) != null)
                {
                    //if (idps == currentRowIndex)
                    //{


                    String[] deo = line.Split('/');
                    String idK = deo[2];

                    Console.WriteLine(idK);
                    Console.WriteLine(idd);
                    string im = deo[0];
                    string prezim = deo[1];
                    string po = deo[3];
                    string datu = deo[4];
                    string mai = deo[5];
                    string br = deo[6];
                    string adre = deo[7];
                    if (idK == jmbg)
                    {

                        t.Text = im;
                        t1.Text = prezim;
                        t2.Text = jmbg;
                        t3.Text = po;
                        t4.Text = datu;
                        t5.Text = mai;
                        t6.Text = br;
                        t7.Text = adre;
                        ime = im;
                        prezime = prezim;
                        jmbg = jmbg;
                    }
                    idps++;

                }

            }

            }


        private void Recepti_Click(object sender, RoutedEventArgs e)
        {
            SpisakRecepata sr = new SpisakRecepata(t2);
            this.Close();
            sr.ShowDialog();
        }

        private void Napisi_izvestaj(object sender, RoutedEventArgs e)
        {
            Izvestaj iz = new Izvestaj(t, t1, t2);
            this.Close();
            iz.ShowDialog();
        }


        private void Izvest_Click(object sender, RoutedEventArgs e)
        {
            Izvestaji_o_pregledu_stanja izv = new Izvestaji_o_pregledu_stanja(t2);
            this.Close();
            izv.ShowDialog();
        }

        private void UputLekaruSpecijalisti_Click(object sender, RoutedEventArgs e)
        {
            UputSpecijalisti uput = new UputSpecijalisti(t2.Text,t.Text,t1.Text);
            this.Close();
            uput.ShowDialog();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            LekarPocetnaStranica lekarPocetnaStranica = new LekarPocetnaStranica();
            this.Close();
            lekarPocetnaStranica.ShowDialog();
        }
    }
}
