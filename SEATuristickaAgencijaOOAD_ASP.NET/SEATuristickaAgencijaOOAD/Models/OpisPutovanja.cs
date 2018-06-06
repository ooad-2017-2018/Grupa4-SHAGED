using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEATuristickaAgencijaOOAD.Models
{
    [Table("OpisPutovanja")]
    public class OpisPutovanja
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int Id { get; set; }
        public string naziv { get; set; }
        public string slika { get; set; }
        public int brojDana { get; set; }
        public string planPutovanja { get; set; }
        public string hotel { get; set; }
        public string liveCamera { get; set; }
        //public string vremenskaPrognoza { get; set; }
        //public string znamenitosti { get; set; }
        public int putaOdrzano { get; set; }

    }
}