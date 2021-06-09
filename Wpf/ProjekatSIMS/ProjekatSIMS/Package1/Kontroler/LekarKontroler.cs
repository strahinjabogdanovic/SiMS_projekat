using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS.Package1.Kontroler
{
    class LekarKontroler
    {
        public LekarKontroler() { }
        private LekarServis ls = new LekarServis();

        public void SacuvajUputZaBolnicu(string jmbg, string brk, string soba, string krevet, DateTime datumd, DateTime datumo, string dijag)
        {
            ls.SacuvajUputZaBolnicu(jmbg, brk, soba, krevet, datumd, datumo, dijag);
        }

        public ObservableCollection<Recepti> ReceptiOdTogPacijenta(string jmbg)
        {
            ObservableCollection<Recepti> ReceptiOdPacijenta = new ObservableCollection<Recepti>();
            LekarServis ls = new LekarServis();
            ReceptiOdPacijenta= ls.NadjiRecepte(jmbg);
            return ReceptiOdPacijenta;
        }

        public ObservableCollection<MedIzvestaj> NadjiIzvestaje(string jmbg)
        {
            ObservableCollection<MedIzvestaj> mi = new ObservableCollection<MedIzvestaj>();
            LekarServis ls = new LekarServis();
            mi = ls.NadjiIzvestaje(jmbg);
            return mi;

        }
        public ObservableCollection<TerminiPacijenata> NadjiTermine()
        {
            ObservableCollection<TerminiPacijenata> tp = new ObservableCollection<TerminiPacijenata>();
            tp = ls.NadjiTermine();
            return tp;
        }
    }
}