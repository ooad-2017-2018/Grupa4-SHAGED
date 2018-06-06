using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEATuristickaAgencijaOOAD.Models
{
    [Table("Administrator")]
    public class Administrator
    {


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string korisnickoIme { get; set; }
        public string lozinka { get; set; }
        public string imeIprezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string email { get; set; }
        public long jmbg { get; set; }


    }
}