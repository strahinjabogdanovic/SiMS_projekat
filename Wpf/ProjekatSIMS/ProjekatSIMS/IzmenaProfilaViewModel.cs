using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    public class IzmenaProfilaViewModel : ValidationBase
    {
        public String Adresa { get; set; }
        public String Email { get; set; }
        public String Telefon { get; set; }
        public RelayCommand OdustaniOdIzmena { get; set; }
        public RelayCommand PotvrdiIzmene { get; set; }
        private IzmenaProfila v;

        public IzmenaProfilaViewModel(IzmenaProfila v)
        {
            NaloziPacijenataFileStorage n = new NaloziPacijenataFileStorage();
            Korisnik k = n.GetPacijent();
            Adresa = k.adresa;
            Email = k.email;
            Telefon = k.brojTelefona;
            this.v = v;
            PotvrdiIzmene = new RelayCommand(Execute_Potvrdi, CanExecute_Command);
            OdustaniOdIzmena = new RelayCommand(Execute_Odustani, CanExecute_Command);
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(Adresa))
            {
                this.ValidationErrors["Adresa"] = "Morate uneti adresu.";
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                this.ValidationErrors["Email"] = "Morate uneti e-mail.";
            }
            if (string.IsNullOrWhiteSpace(Telefon))
            {
                this.ValidationErrors["Telefon"] = "Morate uneti broj telefona.";
            }

        }

        private void Execute_Odustani(object obj)
        {
            v.Close();
        }

        private void Execute_Potvrdi(object obj)
        {
            this.Validate();
            if (IsValid)
            {
                NaloziPacijenataFileStorage n = new NaloziPacijenataFileStorage();
                n.IzmenaProfilaPacijent(Adresa, Email, Telefon);
                MessageBox.Show("Uspesno ste izmenili profil.");
                v.Close();
            }
        }

        private bool CanExecute_Command(object obj)
        {
            return true;
        }
    }
}

