using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEATuristickaAgencijaOOAD.Models
{
    [Table("Putovanje")]
    public class Putovanje
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string putnici { get; set; }
        public DateTime polazak { get; set; }
        public DateTime povratak{ get; set; }
        public int kapacitet { get; set; }
        public double cijena { get; set; }
        public int opisPutovanjaID { get; set; }



    }
}