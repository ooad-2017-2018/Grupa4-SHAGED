using ProjekatOOAD.Models.Baza_podataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models
{
    public class Putovanje
    {
        public static int ID = 0;
        private int putovanjeID;
        private List<int> putnici;
        private DateTime polazak;
        private DateTime povratak;
        private int kapacitet;
        private double cijena;
        private int opisPutovanjaID;

        public int PutovanjeID { get => putovanjeID;  }
        public List<int> Putnici { get => putnici; set => putnici = value; }
        public DateTime Polazak { get => polazak; set => polazak = value; }
        public DateTime Povratak { get => povratak; set => povratak = value; }
        public int Kapacitet { get => kapacitet; set => kapacitet = value; }
        public double Cijena { get => cijena; set => cijena = value; }
        public int OpisPutovanjaID { get => opisPutovanjaID; set => opisPutovanjaID = value; }

        public Putovanje() { }

        public Putovanje(List<int> putnici, DateTime polazak, DateTime povratak, int kapacitet, double cijena, int opisPutovanjaID)
        {
            putovanjeID = ID++;
            this.Putnici = putnici;
            this.Polazak = polazak;
            this.Povratak = povratak;
            this.Kapacitet = kapacitet;
            this.Cijena = cijena;
            this.OpisPutovanjaID = opisPutovanjaID;
        }

        public Putovanje(DataBasePutovanje p)
        {
            Int32.TryParse(p.id , out putovanjeID);
            String[] a = p.putnici.Split(' ');
            foreach(String b in a)
            {
                int l;
                Int32.TryParse(b, out l);
                Putnici.Add(l);
            }
            this.Polazak = p.polazak;
            this.Povratak = p.povratak;
            this.Kapacitet = p.kapacitet;
            this.Cijena = p.cijena;
            this.OpisPutovanjaID = p.opisPutovanjaID;
        }
    }
}
