using ProjekatSIMS.Lekar.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class KartonLekarVM : BindableBase
    {
        public string tIme;
        public string tPrezime;
        public string tJmbg;
        public string tPol;
        public string tDatum;
        public string tAdresa;
        public string tBroj;
        public string tEmail;
        private ComboBoxItem lekari;

        public String ime = "";
        public String prezime = "";
        String jmbg = "";
        String pol = "";
        String datumr = "";
        String mail = "";
        String broj = "";
        String adresa = "";
        String idd = "";

        public MyICommand Nazad { get; set; }
        public MyICommand NapisiIzvestaj { get; set; }
        public MyICommand Recepti { get; set; }
        public MyICommand Izvestaji { get; set; }
        public MyICommand Uput { get; set; }
        public MyICommand UputiZaBolnicu { get; set; }

        public KartonLekarVM()
        {

            PovezivanjeKomandiSaMetodom();

        }
        public KartonLekarVM(DataGrid dg)
        {
            LekarFileStorage lfs = new LekarFileStorage();
            string[] podaci = new string[8];
            int currentRowIndex = dg.Items.IndexOf(dg.SelectedItem);
            podaci = lfs.IzdvajanjeZeljenogKartona(currentRowIndex);
            tIme = podaci[0];
            tPrezime = podaci[1];
            tJmbg = podaci[2];
            tPol = podaci[3];
            tBroj = podaci[6];
            tDatum = podaci[4];
            tEmail = podaci[5];
            tAdresa = podaci[7];

            PovezivanjeKomandiSaMetodom();
        }



        private void PovezivanjeKomandiSaMetodom()
        {
            NapisiIzvestaj = new MyICommand(Napisi_izvestaj);
            Nazad = new MyICommand(Nazad_Click);
            Recepti = new MyICommand(Recepti_Click);
            Izvestaji = new MyICommand(Izvest_Click);
            Uput = new MyICommand(UputLekaruSpecijalisti_Click);
            UputiZaBolnicu = new MyICommand(UputZaBolnicu_Click);
        }


        public KartonLekarVM(string jmbg)
        {
            LekarFileStorage lfs = new LekarFileStorage();
            String[] podaci = new string[8];
            podaci = lfs.KartonPoJmbgu(jmbg);

            tIme = podaci[0];
            tPrezime = podaci[1];
            tJmbg = podaci[2];
            tPol = podaci[3];
            tBroj = podaci[6];
            tDatum = podaci[4];
            tEmail = podaci[5];
            tAdresa = podaci[7];


            PovezivanjeKomandiSaMetodom();

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
        public ComboBoxItem Lekari
        {
            get { return lekari; }
            set
            {
                if (lekari != value)
                {
                    lekari = value;
                    OnPropertyChanged("Lekari");
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
        public string TPol
        {
            get { return tPol; }
            set
            {
                if (tPol != value)
                {
                    tPol = value;
                    OnPropertyChanged("TPol");
                }
            }
        }
        public string TDatum
        {
            get { return tDatum; }
            set
            {
                if (tDatum != value)
                {
                    tDatum = value;
                    OnPropertyChanged("TDatum");
                }
            }
        }
        public string TAdresa
        {
            get { return tAdresa; }
            set
            {
                if (tAdresa != value)
                {
                    tAdresa = value;
                    OnPropertyChanged("TAdresa");
                }
            }
        }
        public string TBroj
        {
            get { return tBroj; }
            set
            {
                if (tBroj != value)
                {
                    tBroj = value;
                    OnPropertyChanged("TBroj");
                }
            }
        }
        public string TEmail
        {
            get { return tEmail; }
            set
            {
                if (tEmail != value)
                {
                    tEmail = value;
                    OnPropertyChanged("TEmail");
                }
            }
        }
        private void Recepti_Click()
        {
            SpisakRecepata sr = new SpisakRecepata(tJmbg);
            sr.ShowDialog();
        }

        private void Napisi_izvestaj()
        {
            Izvestaj iz = new Izvestaj(tIme, tPrezime, tJmbg);
            iz.ShowDialog();
        }


        private void Izvest_Click()
        {
            Izvestaji_o_pregledu_stanja izv = new Izvestaji_o_pregledu_stanja(tJmbg);
            izv.ShowDialog();
        }

        private void UputLekaruSpecijalisti_Click()
        {
            UputSpecijalisti uput = new UputSpecijalisti(tJmbg, tIme, tPrezime);
            uput.ShowDialog();
        }

        private void UputZaBolnicu_Click()
        {
            UputZaBolnicu upu = new UputZaBolnicu(tIme, tPrezime, tJmbg);
            Console.WriteLine(tIme);
            upu.ShowDialog();
        }

        private void Nazad_Click()
        {
            LekarPocetnaStranica lekarPocetnaStranica = new LekarPocetnaStranica();
            lekarPocetnaStranica.ShowDialog();
        }
    }
}
