using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SekretarPocetnaStrana.xaml
    /// </summary>
    public partial class SekretarPocetnaStrana : Window
    {
        Korisnik krs;
        private readonly string filePath;

        public ObservableCollection<Korisnik> Korisnici
        {
            get;
            set;
        }






        public SekretarPocetnaStrana()
        {
            filePath = @"C:\Users\Strahx\Documents\GitHub\SiMS_projekat\Wpf\ProjekatSIMS\ProjekatSIMS\bin\Debug\podaci.txt";
            Korisnici = new ObservableCollection<Korisnik>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split(' ');
                var korisnik = new Korisnik();
                korisnik.ime = termin[0].ToString();
                korisnik.prezime = termin[1].ToString();
                korisnik.jmbg = long.Parse(termin[2].ToString());
                if (termin[3].ToString() != null)
                {

                    if (termin[3].ToString() == "Muski")
                    {
                        korisnik.pol = Pol.Muski;

                    }
                    else if (termin[3].ToString() == "Zenski")
                    {
                        korisnik.pol = Pol.Zenski;
                    }
                }
                korisnik.datumRodjenja = termin[4].ToString();
                korisnik.email = termin[5].ToString();
                korisnik.brojTelefona = termin[6].ToString();
                korisnik.adresa = termin[7].ToString();
                Korisnici.Add(korisnik);


            }


            InitializeComponent();
            this.DataContext = this;

            StreamReader sr = new StreamReader("podaci.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();


            //dataGridNalozi.ItemsSource = Korisnici;

            /*Korisnici = new ObservableCollection<Korisnik>();
            Korisnici.Add(new Korisnik { ime = "Petar", prezime = "Petrovic" , jmbg = 0038467348372 , pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 1});
            Korisnici.Add(new Korisnik { ime = "Ana", prezime = "Petrov", jmbg = 56345356375, pol = Pol.Zenski, datumRodjenja = "02.01.1987.", email = "ana@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 2 });
            Korisnici.Add(new Korisnik { ime = "Mitar", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 3 });
            Korisnici.Add(new Korisnik { ime = "Marko", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 4 });
            Korisnici.Add(new Korisnik { ime = "Jefinima", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 5 });
            Korisnici.Add(new Korisnik { ime = "Dostr", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 6 });
            Korisnici.Add(new Korisnik { ime = "Boris", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 7 });
            Korisnici.Add(new Korisnik { ime = "Treoja", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 8 });
            Korisnici.Add(new Korisnik { ime = "Prsuta", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 9 });
               */
        }

        private void KreirajNalog_Click(object sender, RoutedEventArgs e)
        {
            KreirajNalog kn = new KreirajNalog();
            kn.ShowDialog();
            //dataGridNalozi.Items.Refresh();
        }

        private void ObrisiNalog_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);
            Korisnik k = Korisnici.ElementAt(currentRowIndex);
            if (Korisnici.Count > 0)
            {
                Korisnici.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("podaci.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Korisnici = new ObservableCollection<Korisnik>();

                    var priv = new Korisnik();

                    String[] termin = line.Split(' ');
                    //var priv = new Korisnik();
                    //korisnik.ime = termin[0].ToString();
                    //korisnik.prezime = termin[1].ToString();
                    priv.jmbg = long.Parse(termin[2].ToString());


                    /*if (termin[3].ToString() != null)
                    {

                        if (termin[3].ToString() == "Muski")
                        {
                            korisnik.pol = Pol.Muski;

                        }
                        else if (termin[3].ToString() == "Zenski")
                        {
                            korisnik.pol = Pol.Zenski;
                        }
                    }
                    korisnik.datumRodjenja = termin[4].ToString();
                    korisnik.email = termin[5].ToString();
                    korisnik.brojTelefona = termin[6].ToString();
                    korisnik.adresa = termin[7].ToString();
                    Korisnici.Add(korisnik);*/

                    //Console.WriteLine(priv.jmbg);
                    if (priv.jmbg != k.jmbg)
                        sw.WriteLine(line);
                }
            }

            File.Delete("podaci.txt");
            File.Move(tempFile, "podaci.txt");



        }

        private void IzmeniNalog_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("podaci.txt"))
            using (var sw = new StreamWriter(tempFile))
            {

                String pol="";
                String mail = "";
                String adresa = "";
                int idx = 0;

                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //id++;
                    if (id == currentRowIndex)
                    {
                        //var lastLine = File.ReadLines("podaci.txt").Last();
                        String[] termin = line.Split(' ');
                        var korisnik = new Korisnik();
                         pol = termin[3];
                         mail = termin[5];
                         adresa = termin[7];
                         idx = int.Parse(termin[8]);

                        

                        DataGridRow row = (DataGridRow)dataGridNalozi.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = dataGridNalozi.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = dataGridNalozi.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = dataGridNalozi.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = dataGridNalozi.Columns[3].GetCellContent(row) as TextBlock;
                        TextBlock t5 = dataGridNalozi.Columns[4].GetCellContent(row) as TextBlock;

                        sw.WriteLine(t1.Text + " " + t2.Text + " " + long.Parse(t3.Text) + " " + pol + " " + t4.Text + " " + mail + " " + t5.Text + " " + adresa + " " + idx);
                    }
                    else
                    {
                       sw.WriteLine(line);
                    }
                    id++;
                }
             }
            File.Delete("podaci.txt");
            File.Move(tempFile, "podaci.txt");  

        }

        private void PrikaziSveInfo_Click(object sender, RoutedEventArgs e)
        {
            

            




        }
    }
}
