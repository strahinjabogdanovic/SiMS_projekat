using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    class LekarAnketaViewModel : ValidationBase
    {
        public String Lekar { get; set; }
        public String Ljubaznost { get; set; }
        public String Strucnost { get; set; }
        public String Komentar { get; set; }
        public RelayCommand PotvrdiAnketu { get; set; }
        public RelayCommand OdustaniOdAnkete { get; set; }
        LekarAnketa ba;

        public LekarAnketaViewModel(LekarAnketa ba)
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
                AnketaStorage anketaBolnica = new AnketaStorage();

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
            if (String.IsNullOrWhiteSpace(Lekar))
            {
                this.ValidationErrors["Lekar"] = "Izaberite lekara kog ocenjujete";
            }
            if (String.IsNullOrWhiteSpace(Ljubaznost))
            {
                this.ValidationErrors["Ljubaznost"] = "Ocenite ljubaznost lekara";
            }
            if (String.IsNullOrWhiteSpace(Strucnost))
            {
                this.ValidationErrors["Strucnost"] = "Ocenite strucnost lekara";
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

            string lekar = Lekar;

            string ljubaznost = Ljubaznost;

            string strucnost = Strucnost;

            string komentar = Komentar;


            using (var sr = new StreamReader("anketaLekar.txt"))
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

                sw.WriteLine(lekar + "|" + ljubaznost + "|" + strucnost + "|" + komentar + "|" + datum_radjenja_ankete);

            }
            File.Delete("anketaLekar.txt");
            File.Move(tempFile, "anketaLekar.txt");

        }
    }
}

