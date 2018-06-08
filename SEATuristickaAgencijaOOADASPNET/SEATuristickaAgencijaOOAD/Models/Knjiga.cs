﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEATuristickaAgencijaOOAD.Models
{
    public class Knjiga
    {
        private string naziv;
        private string imeAutora;

        public Knjiga(string naziv, string imeAutora)
        {
            this.naziv = naziv;
            this.imeAutora = imeAutora;
        }

        public string ImeAutora { get => imeAutora; set => imeAutora = value; }
        public string Naziv { get => naziv; set => naziv = value; }
    }
}