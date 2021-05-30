using ProjekatSIMS.Lekar.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Lekar.ViewModel
{
    public class IzvestajVM : BindableBase
    {
        private string textIme;
        private string textPrezime;
        private string textJmbg;

        private string textOdeljenje;

        private string textSoba;
        private string textNalaz;

        private string textTerapija;
        private string textKontrola;
        private DateTime datum;

        public MyICommand Button { get; set; }
        public MyICommand Sacuvaj { get; set; }
        public MyICommand Nazad { get; set; }
        public MyICommand RadioButton { get; set; }

        public IzvestajVM()
        {

            Sacuvaj = new MyICommand(Sacuvaj_Click);
            Nazad = new MyICommand(Nazad_Click);
            Button = new MyICommand(Button_Click);

        }
        public IzvestajVM(string imePacijenta, string prezimePacijenta, string jmbgPacijenta)
        {
            string ime = imePacijenta;
            textIme = ime;
            string prezime = prezimePacijenta;
            textPrezime = prezime;
            string jmbg = jmbgPacijenta;
            textJmbg = jmbg;
            Sacuvaj = new MyICommand(Sacuvaj_Click);
            Nazad = new MyICommand(Nazad_Click);
            Button = new MyICommand(Button_Click);

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
        public string TextIme
        {
            get { return textIme; }
            set
            {
                if (textIme != value)
                {
                    textIme = value;
                    OnPropertyChanged("TextIme");
                }
            }
        }
        public string TextPrezime
        {
            get { return textPrezime; }
            set
            {
                if (textPrezime != value)
                {
                    textPrezime = value;
                    OnPropertyChanged("TextPrezime");
                }
            }
        }
        public string TextOdeljenje
        {
            get { return textOdeljenje; }
            set
            {
                if (textOdeljenje != value)
                {
                    textOdeljenje = value;
                    OnPropertyChanged("TextOdeljenje");
                }
            }
        }
        public string TextSoba
        {
            get { return textSoba; }
            set
            {
                if (textSoba != value)
                {
                    textSoba = value;
                    OnPropertyChanged("TextSoba");
                }
            }
        }
        public string TextNalaz
        {
            get { return textNalaz; }
            set
            {
                if (textNalaz != value)
                {
                    textNalaz = value;
                    OnPropertyChanged("TextNalaz");
                }
            }
        }
        public string TextKontrola
        {
            get { return textKontrola; }
            set
            {
                if (textKontrola != value)
                {
                    textKontrola = value;
                    OnPropertyChanged("TextKontrola");
                }
            }
        }
        public string TextTerapija
        {
            get { return textTerapija; }
            set
            {
                if (textTerapija != value)
                {
                    textTerapija = value;
                    OnPropertyChanged("TextTerapija");
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
        private bool _optionA;
        public bool Prvi
        {
            get { return _optionA; }
            set
            {
                _optionA = value;
                if (_optionA)
                {
                    this.Drugi = false;
                }
            }
        }

        private bool _optionB;
        public bool Drugi
        {
            get { return _optionB; }
            set
            {
                _optionB = value;
                if (_optionB)
                {
                    this.Prvi = false;
                }
            }
        }
        private void Sacuvaj_Click()
        {
            string odeljenje = textOdeljenje;
            string soba = textSoba;
            string nalaz = textNalaz;
            string kontrola = textKontrola;
            string terapija = textTerapija;

            using (var sw = new StreamWriter("izvestaji.txt", true))
            {
                string line;
                //int id = 0;


                if (this.Prvi == true)
                {
                    sw.WriteLine("Izvestaj o pregledu" + "/" + odeljenje + "/" + soba + "/" + nalaz + "/" + kontrola + "/" + terapija + "/" + this.datum.ToString("dddd, dd MMMM yyyy") + "/" + this.textJmbg);
                    sw.Close();
                }
                else
                {
                    sw.WriteLine("Izvestaj o hospitalizaciji" + "/" + odeljenje + "/" + soba + "/" + nalaz + "/" + kontrola + "/" + terapija + "/" + this.datum.ToString("dddd, dd MMMM yyyy") + "/" + this.textJmbg);
                    sw.Close();
                }

            }
        }

        private void Button_Click()
        {
            string JmbgProsledjen = textJmbg;
            KartonLekar karton = new KartonLekar(JmbgProsledjen);
            karton.ShowDialog();
        }

        private void Nazad_Click()
        {
            string JmbgProsledjen = textJmbg;
            KartonLekar karton = new KartonLekar(JmbgProsledjen);
            karton.ShowDialog();

        }
    }
}
