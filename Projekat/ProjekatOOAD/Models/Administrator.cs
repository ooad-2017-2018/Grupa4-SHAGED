using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models
{
    public class Administrator: Osoba
    {
        public static int ID=0;
        private int adminID;
        private string korisnickoIme;
        private string lozinka;

        public int AdminID { get => adminID; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }

        public Administrator() { }

        public Administrator(string imeIprezime, DateTime datumRodjenja, string email, long jmbg,  string korisnickoIme, string lozinka):
            base(imeIprezime, datumRodjenja, email, jmbg)
        {
            adminID= ID++;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
        }

        public Administrator(DataBaseAdministrator a)
        {
            base.ImeIprezime = a.imeIprezime;
            base.DatumRodjenja = a.datumRodjenja;
            base.Jmbg = a.jmbg;
            base.Email = a.email;
            Int32.TryParse( a.id, out adminID);
            KorisnickoIme = a.korisnickoIme;
            Lozinka = a.lozinka;
        }
    }
}
