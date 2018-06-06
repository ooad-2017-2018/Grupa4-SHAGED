using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEATuristickaAgencijaOOAD.Models
{
    public class Rezervacija
    {
        [Key]
        public int Id { get; set; }
        public int IdPutnika { get; set; }
        public int IdPutovanja { get; set; }
    }
}