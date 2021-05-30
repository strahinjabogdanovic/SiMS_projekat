using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;


namespace ProjekatSIMS.Lekar.ViewModel
{
    class KreirajTerminLekarVM : BindableBase
    {
        private string vrsta;
        private string lekar;
        private DateTime datum;
        private string tIme;
        private string tPrezime;
        private string tVreme;
        private string tSoba;
        private string tJmbg;

        public MyICommand Potvrdi { get; set; }
        public MyICommand Odustani { get; set; }
        public KreirajTerminLekarVM()
        {
            KartonLekar karton = new KartonLekar();
            Potvrdi = new MyICommand(Potvrdi_Click);
            Odustani = new MyICommand(Odustani_Click);

        }
        public KreirajTerminLekarVM(string jmbg)
        {
            KartonLekar karton = new KartonLekar(jmbg);
            tJmbg = jmbg;
            tIme = karton.t.Text;
            tPrezime = karton.t1.Text;
            Potvrdi = new MyICommand(Potvrdi_Click);
            Odustani = new MyICommand(Odustani_Click);


        }


        public ObservableCollection<TerminiPacijenata> ZakazTermina
        {
            get;
            set;
        }
        public string TIme
        {
            get { return tIme; }
            set
            {
                if (tIme != value)
                {
                    tIme = value;
                    OnPropertyChanged("TIme");
                }
            }
        }

        public string TPrezime
        {
            get { return tPrezime; }
            set
            {
                if (tPrezime != value)
                {
                    tPrezime = value;
                    OnPropertyChanged("TPrezime");
                }
            }
        }

        public string Vrsta
        {
            get { return vrsta; }
            set
            {
                if (vrsta != value)
                {
                    vrsta = value;
                    OnPropertyChanged("Vrsta");
                }
            }
        }
        public string TVreme
        {
            get { return tVreme; }
            set
            {
                if (tVreme != value)
                {
                    tVreme = value;
                    OnPropertyChanged("TVreme");
                }
            }
        }
        public string Lekar
        {
            get { return lekar; }
            set
            {
                if (lekar != value)
                {
                    lekar = value;
                    OnPropertyChanged("Lekar");
                }
            }
        }
        public DateTime Datum
        {
            get { return datum; }
            set
            {
                if (datum != value)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
        public string TSoba
        {
            get { return tSoba; }
            set
            {
                if (tSoba != value)
                {
                    tSoba = value;
                    OnPropertyChanged("TSoba");
                }
            }
        }
        public string TJmbg
        {
            get { return tJmbg; }
            set
            {
                if (tJmbg != value)
                {
                    tJmbg = value;
                    OnPropertyChanged("TJmbg");
                }
            }
        }
        private void Odustani_Click()
        {
        }

        private void Potvrdi_Click()
        {
            TerminiFileStorage tfs = new TerminiFileStorage();
            string vrstaTermina = vrsta;
            string lekaro = lekar;
            DateTime date = datum;
            string tb = date.ToString("dd.mm.yyyy");
            string tb2 = tVreme;
            string tb3 = tJmbg;
            string tb4 = tSoba;
            tfs.Kreiraj(vrstaTermina, lekar, tb, tb2, tb4, tb3);

            //ZakazTermina = new ObservableCollection<TerminiPacijenata>();
            //string slj = "";
            //string kfr = "";

            // string vrstaTermina = comboBox.SelectedValue.ToString();
            //string lekar = comboBox1.SelectedValue.ToString();

            //if (lekar != null)
            //{

            //    if (lekar.Contains("Jova Jovic"))
            //   {
            //       slj = "Jova Jovic";

            //    }
            //    else if (lekar.Contains("Jovan Jovanovic"))
            //    {
            //        slj = "Jovan Jovanovic";
            //    }
            // }

            // if (vrstaTermina != null)
            // {

            //    if (vrstaTermina.Contains("Pregled"))
            //     {
            //         kfr = "Pregled";

            //     }
            //     else if (vrstaTermina.Contains("Operacija"))
            //    {
            //        kfr = "Operacija";
            //     }
            // }


            // string tempFile = System.IO.Path.GetTempFileName();

            //  using (var sr = new StreamReader("lekar.txt"))
            // using (var sw = new StreamWriter(tempFile))
            // {
            //     string line;
            //     int id = 0;
            //     while ((line = sr.ReadLine()) != null)
            //    {
            //          String[] termin = line.Split('/');
            //         var lekari = new TerminiPacijenata();
            // //         id = int.Parse(termin[5]);
            //         id++;

            //         sw.WriteLine(line);

            //     }

            // sw.WriteLine(kfr + "/" + textBox.Text + "/" + textBox1.Text + "/" + textBox2.Text + "/" + slj + "/" + id);


            //  }
            //  File.Delete("lekar.txt");
            //  File.Move(tempFile, "lekar.txt");



            //  Close();
            //   LekarPocetnaStranica s = new LekarPocetnaStranica();
            //   s.ShowDialog();

        }
    }
}
