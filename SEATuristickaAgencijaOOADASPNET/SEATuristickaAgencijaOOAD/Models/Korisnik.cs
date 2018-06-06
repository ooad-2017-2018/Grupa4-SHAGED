using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEATuristickaAgencijaOOAD.Models
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string brojPasosa { get; set; }
        public bool spol { get; set; }
        public string brojTelefona { get; set; }
        public bool obavijesti { get; set; }
        public bool osiguranje { get; set; }
        public string putovanja { get; set; }
        public DateTime zadnjePutovanje { get; set; }

        public string imeIprezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string email { get; set; }
        public long jmbg { get; set; }

    }
}