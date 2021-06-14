using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS
{
    public class BolnicaAnketaViewModel : ValidationBase
    {
        public String Usluga { get; set; }
        public String Zaposleni { get; set; }
        public String Prostorija { get; set; }
        public String Komentar { get; set; }
        public RelayCommand PotvrdiAnketu { get; set; }
        public RelayCommand OdustaniOdAnkete { get; set; }
        BolnicaAnketa ba;

        public BolnicaAnketaViewModel(BolnicaAnketa ba)
        {
            this.ba = ba;
            PotvrdiAnketu = new RelayCommand(Execute_PotvrdiAnketu, CanExecute_Command);
            OdustaniOdAnkete = new RelayCommand(Execute_OdustaniOdAnkete, CanExecute_Command);
        }

        private void Execute_PotvrdiAnketu(object obj)
        {
            this.Validate();
            if (IsValid)
            {
                AnketaServis anketaBolnica = new AnketaServis();

                if (anketaBolnica.pravo_na_anketu_bolnica())
                {
                    PopuniAnketu();
                    MessageBox.Show("Uspesno ste poslali anketu.");
                }
                else
                {
                    MessageBox.Show("Anketa je vec popunjena.");
                }
                ba.Close();
            }
        }

        private void Execute_OdustaniOdAnkete(object obj)
        {
            ba.Close();
        }

        private bool CanExecute_Command(object obj)
        {
            return true;
        }

        protected override void ValidateSelf()
        {
            if (String.IsNullOrWhiteSpace(Usluga))
            {
                this.ValidationErrors["Usluga"] = "Ocenite usluge bolnice";
            }
            if (String.IsNullOrWhiteSpace(Zaposleni))
            {
                this.ValidationErrors["Zaposleni"] = "Ocenite zaposlene u bolnici";
            }
            if (String.IsNullOrWhiteSpace(Prostorija))
            {
                this.ValidationErrors["Prostorija"] = "Ocenite prostorije bolnice";
            }
            if (String.IsNullOrWhiteSpace(Komentar))
            {
                this.ValidationErrors["Komentar"] = "Unesite vas komenar";
            }
        }

        private void PopuniAnketu()
        {
            string tempFile = System.IO.Path.GetTempFileName();
            AnketaStorage anketaLekar = new AnketaStorage();


            string[] u = Usluga.Split(' ');
            string usluga = u[1];

            string[] z = Zaposleni.Split(' ');
            string zaposleni = z[1];

            string[] p = Prostorija.Split(' ');
            string prostorije = p[1];

            string komentar = Komentar;

            AnketaBolnicaStorage abs = new AnketaBolnicaStorage();

            string datum = DateTime.Now.ToString();
            string[] d = datum.Split(' ');
            string[] dat = d[0].Split('/');
            string datum_radjenja_ankete = dat[1] + "." + dat[0] + "." + dat[2] + ".";


            AnketaBolnica anketa = new AnketaBolnica();
            anketa.usluga = usluga;
            anketa.zaposleni = zaposleni;
            anketa.prostorija = prostorije;
            anketa.komentar = komentar;
            anketa.datum = datum_radjenja_ankete;

            abs.Save(anketa);
            /* using (var sr = new StreamReader("anketaBolnica.txt"))
             using (var sw = new StreamWriter(tempFile))
             {
                 string line;
                 int id = 0;
                 while ((line = sr.ReadLine()) != null)
                 {
                     sw.WriteLine(line);
                 }

                 string datum = DateTime.Now.ToString();
                 string[] d = datum.Split(' ');
                 string[] dat = d[0].Split('/');
                 string datum_radjenja_ankete = dat[1] + "." + dat[0] + "." + dat[2] + ".";

                 sw.WriteLine(usluga + "|" + zaposleni + "|" + prostorije + "|" + komentar + "|" + datum_radjenja_ankete);

             }
             File.Delete("anketaBolnica.txt");
             File.Move(tempFile, "anketaBolnica.txt"); */

        }
    }
}
