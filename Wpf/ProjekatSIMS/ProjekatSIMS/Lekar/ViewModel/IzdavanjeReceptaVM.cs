using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    public class IzdavanjeReceptaVM : BindableBase
    {

        public Lek lek = new Lek();
        public NaloziPacijenataFileStorage pac = new NaloziPacijenataFileStorage();
        private string textJmbg;
        private string upozorText;
        private TextBlock upozor;

        private string s1;
        private string s2;
        private string s3;
        private string s4;
        public MyICommand pronadji { get; set; }
        public MyICommand Izdaj { get; set; }
        public bool IsHide = false;
        public IzdavanjeReceptaVM(string jmbgPacijenta)
        {
            string jmbg = jmbgPacijenta;
            textJmbg = jmbg;
            MetodeNaKomande();
        }

        private void MetodeNaKomande()
        {
            Izdaj = new MyICommand(Izdaj_Click);
            pronadji = new MyICommand(t2_MouseDoubleClick);
        }

        public string S1
        {
            get { return s1; }
            set
            {
                if (s1 != value)
                {
                    s1 = value;
                    OnPropertyChanged("S1");
                }
            }
        }
        public string S2
        {
            get { return s2; }
            set
            {
                if (s2 != value)
                {
                    s2 = value;
                    OnPropertyChanged("S2");
                }
            }
        }
        public string S3
        {
            get { return s3; }
            set
            {
                if (s3 != value)
                {
                    s3 = value;
                    OnPropertyChanged("S3");
                }
            }
        }
        public string S4
        {
            get { return s4; }
            set
            {
                if (s4 != value)
                {
                    s4 = value;
                    OnPropertyChanged("S4");
                }
            }
        }
        public string TextJmbg
        {
            get { return textJmbg; }
            set
            {
                if (textJmbg != value)
                {
                    textJmbg = value;
                    OnPropertyChanged("TextJmbg");
                }
            }
        }
        public string UpozorText
        {
            get { return upozorText; }
            set
            {
                if (upozorText != value)
                {
                    upozorText = value;
                    OnPropertyChanged("UpozorText");
                }
            }
        }


        private void Izdaj_Click()
        {
            string sifra = S1;
            string naziv = S2;
            string nacin = S3;
            string naKolikoSati = S4;
            using (var sw = new StreamWriter("recepti.txt", true))
            {
                int id = 0;

                sw.WriteLine(sifra + "/" + naziv + "/" + nacin + "/" + naKolikoSati + "/" + textJmbg);
                sw.Close();


            }
        }


        private void t2_MouseDoubleClick()
        {
            Lek lekicPrazan = new Lek();
            lek = lekicPrazan.dobaviLekPoNazivu(S2);
            NaloziPacijenataFileStorage nalozi = new NaloziPacijenataFileStorage();
            int id = nalozi.dobaviIdPacijentaPoJmbgu(textJmbg);
            S1 = lek.SifraLeka;
            string alerg = nalozi.DobaviAlergije(id);
            proveriAlergije(lek.sastojci, alerg, lek.sifraleka);

        }
        private void proveriAlergije(string sast, string alergeni, string sifrica)
        {
            if (sast != null)
            {
                string[] sastojci = sast.Split(',');
                if (alergeni != null)
                {
                    string[] alergjedan = alergeni.Split(',');
                    foreach (string sastojak in sastojci)
                    {
                        foreach (string aljedan in alergjedan)
                            if (sastojak == "ibuprofen" && aljedan == "alergen1")
                            {
                                UpozorText = "Pacijent je alergican na ovaj lek!";
                                Console.WriteLine("Pacijent alergican");
                            }
                            else if (sastojak == "paracetamol" && aljedan == "alergen2")
                            {
                                UpozorText = "Pacijent je alergican na ovaj lek!";
                            }
                            else
                            {
                                s1 = sifrica;
                            }
                    }
                }
            }
        }

    }
}
