using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    public class TerminiViewModel : ValidationBase
    {
        private TerminiPacijenata selectedAppointment;
        private readonly string filePath;
        public RelayCommand Zakazivanje { get; set; }
        public RelayCommand Otkazivanje { get; set; }
        public RelayCommand Pomeranje { get; set; }
        public RelayCommand Izvestaj { get; set; }
        public RelayCommand showAppointments { get; set; }

        private ObservableCollection<TerminiPacijenata> terminiP;
        public ObservableCollection<TerminiPacijenata> TerminiP
        {
            get { return terminiP; }
            set
            {
                terminiP = value;
                OnPropertyChanged();
            }
        }
        public TerminiPacijenata SelectedAppointment
        {
            get { return selectedAppointment; }
            set
            {
                selectedAppointment = value;
                OnPropertyChanged();
            }
        }

        private DateTime date { get; set; }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        public TerminiViewModel()
        {
            Date = DateTime.Now;
            Zakazivanje = new RelayCommand(Execute_Zakazivanje, CanExecute_Command);
            Otkazivanje = new RelayCommand(Execute_Otkazivanje, CanExecute_Command);
            Pomeranje = new RelayCommand(Execute_Pomeranje, CanExecute_Command);
            Izvestaj = new RelayCommand(Execute_Izvestaj, CanExecute_Command);
            showAppointments = new RelayCommand(Execute_ShowAppointments, CanExecute_Command);
            filePath = "termini.txt";
            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();

            string s = Date.ToShortDateString();
            string[] datum = s.Split('/');
            List<TerminiPacijenata> todaysAppointments = new List<TerminiPacijenata>();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                if (termin[5].Equals("Ana Markovic"))
                {
                    Console.WriteLine("213312332");
                    var pacijent = new TerminiPacijenata();
                    pacijent.datum = termin[0].ToString();
                    pacijent.vreme = termin[1].ToString();
                    pacijent.lekar = termin[2].ToString();
                    pacijent.soba = termin[3].ToString();
                    pacijent.id = int.Parse(termin[4].ToString());
                    todaysAppointments.Add(pacijent);
                }

            }
            todaysAppointments.ForEach(this.TerminiP.Add);

            StreamReader sr = new StreamReader("termini.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();


        }

        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }

        private void Execute_Zakazivanje(object obj)
        {
            antiTrol anti = new antiTrol();
            if (anti.maksimalan_broj_termina())
            {
                BiranjePrioritetaZakazivanja bp = new BiranjePrioritetaZakazivanja();
                bp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Prekoracili ste broj termina koje mozete da zakazete.");
            }
        }

        private void Execute_Otkazivanje(object obj)
        {
            PacijentFileStorage p = new PacijentFileStorage();

            if (SelectedAppointment != null)
            {
                p.Obrisi(SelectedAppointment);

                TerminiP = null;

                TerminiP = new ObservableCollection<TerminiPacijenata>();
                List<String> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();

                string s = Date.ToShortDateString();
                string[] datum = s.Split('/');

                foreach (string linee in lines)
                {
                    String[] termin = linee.Split('/');
                    if (termin[5].Equals("Ana Markovic"))
                    {
                        var pacijent = new TerminiPacijenata();
                        pacijent.datum = termin[0].ToString();
                        pacijent.vreme = termin[1].ToString();
                        pacijent.lekar = termin[2].ToString();
                        pacijent.soba = termin[3].ToString();
                        pacijent.id = int.Parse(termin[4].ToString());
                        TerminiP.Add(pacijent);
                    }

                }

                StreamReader sr = new StreamReader("termini.txt");
                string line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                }
                sr.Close();
                MessageBox.Show("Uspesno ste obrisali termin.");
            }
            else MessageBox.Show("Niste izabrali termin koji zelite da obrisete!");

        }

        private void Execute_Pomeranje(object obj)
        {
            if (SelectedAppointment == null)
            {
                MessageBox.Show("Niste izabrali termin koji zelite da pomerite!");

            }
            pomeranjeTermina ps = new pomeranjeTermina();
            ps.ShowDialog();

        }
        private void Execute_Izvestaj(object obj)
        {

            IzvestajView iv = new IzvestajView();
            iv.ShowDialog();
        }

        private bool CanExecute_Command(object obj)
        {
            return true;
        }

        private void Execute_ShowAppointments(object obj)
        {
            DateTime selectedDate = Date;

            TerminiP = null;

            TerminiP = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();

            string s = selectedDate.ToShortDateString();
            string[] datum = s.Split('/');

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                if (termin[5].Equals("Ana Markovic"))
                {
                    var pacijent = new TerminiPacijenata();
                    pacijent.datum = termin[0].ToString();
                    pacijent.vreme = termin[1].ToString();
                    pacijent.lekar = termin[2].ToString();
                    pacijent.soba = termin[3].ToString();
                    pacijent.id = int.Parse(termin[4].ToString());
                    TerminiP.Add(pacijent);
                }

            }

            StreamReader sr = new StreamReader("termini.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }
    }
}
