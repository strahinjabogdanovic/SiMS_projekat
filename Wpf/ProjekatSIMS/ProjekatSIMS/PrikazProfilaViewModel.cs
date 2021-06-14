using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    public class PrikazProfilaViewModel : ValidationBase
    {
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Jmbg { get; set; }
        public String DatumRodjenja { get; set; }
        public String Pol { get; set; }
        public String Adresa { get; set; }
        public String Email { get; set; }
        public String Telefon { get; set; }

        public PrikazProfilaViewModel()
        {
            NaloziPacijenataFileStorage n = new NaloziPacijenataFileStorage();
            Korisnik k = n.GetPacijent();
            Ime = k.ime;
            Prezime = k.prezime;
            Jmbg = k.jmbg.ToString();
            DatumRodjenja = k.datumRodjenja;
            Pol = "Zenski";
            Adresa = k.adresa;
            Email = k.email;
            Telefon = k.brojTelefona;
        }

        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
