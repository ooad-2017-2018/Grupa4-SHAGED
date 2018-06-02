using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models.Baza_podataka
{
    public class DataBasePutovanje
    {
        public string id;
        public string putnici;
        public DateTime polazak;
        public DateTime povratak;
        public int kapacitet;
        public double cijena;
        public int opisPutovanjaID;

        public DataBasePutovanje() { }

        public DataBasePutovanje(int putovanjeID, string putnici, DateTime polazak, DateTime povratak, int kapacitet, double cijena, int opisPutovanjaID)
        {
            this.id = putovanjeID.ToString();
            this.putnici = putnici;
            this.polazak = polazak;
            this.povratak = povratak;
            this.kapacitet = kapacitet;
            this.cijena = cijena;
            this.opisPutovanjaID = opisPutovanjaID;
        }

        public DataBasePutovanje(Putovanje p)
        {
            this.id = p.PutovanjeID.ToString();
            this.putnici = "";
            foreach (int i in p.Putnici)
            {
                putnici += i.ToString() + " " ;
            }
            
            this.polazak = p.Polazak;
            this.povratak = p.Povratak;
            this.kapacitet = p.Kapacitet;
            this.cijena = p.Cijena;
            this.opisPutovanjaID = p.OpisPutovanjaID;
        }

        
    }
}
