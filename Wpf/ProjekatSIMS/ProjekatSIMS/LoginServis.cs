using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjekatSIMS.Lekar;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS
{
    public class LoginServis : ILogin
    {
        private ILogin loginInterface;

        public LoginServis(ILogin l)
        {
            this.loginInterface = l;
        }

        List<string> users = new List<string>();
        List<string> pass = new List<string>();
        List<string> rola = new List<string>();
        string string1 = "pacijent";
        string string2 = "sekretar";
        string string3 = "upravnik";
        string string4 = "lekar";

        public void log(string korisnickoIme, string lozinka)
        {
            StreamReader sr = new StreamReader("LoginPodaci.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                users.Add(components[0]);
                pass.Add(components[1]);
                rola.Add(components[2]);
            }
            sr.Close();

            if (users.Contains(korisnickoIme) && pass.Contains(lozinka) && Array.IndexOf(users.ToArray(), korisnickoIme) ==
                Array.IndexOf(pass.ToArray(), lozinka))
            {
                if (rola.Contains(string4) && Array.IndexOf(users.ToArray(), korisnickoIme) ==
                Array.IndexOf(rola.ToArray(), string4))
                {
                    LekarOsnova ps4 = new LekarOsnova();
                    ps4.ShowDialog();
                }
                else if (rola.Contains(string3) && Array.IndexOf(users.ToArray(), korisnickoIme) ==
                Array.IndexOf(rola.ToArray(), string3))
                {
                    UpravnikPocetnaStranica ps3 = new UpravnikPocetnaStranica();
                    ps3.ShowDialog();
                }
                else if (rola.Contains(string2) && Array.IndexOf(users.ToArray(), korisnickoIme) ==
                Array.IndexOf(rola.ToArray(), string2))
                {
                    SekretarPocetnaStrana ps2 = new SekretarPocetnaStrana();
                    ps2.ShowDialog();
                }
                else
                {
                    PocetnaPacijent ps = new PocetnaPacijent();
                    ps.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Korisnicko ime ili lozinka je netacno");
            }
        }
    }
}
