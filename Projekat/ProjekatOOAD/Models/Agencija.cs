﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjekatOOAD.Models
{
    class Agencija
    {
        private List<Administrator> administratori;
        private static string opis="";//naci opis neke agencije
        private static string lokacija = "Sarajevo, Zmaja od Bosne 6";
        private static string telefon="033/222-333";
        private static BitmapImage slika;
        private List<Putovanje> putovanja;
        private List<OpisPutovanja> ponude;
        private List<Korisnik> putnici;
        private List<Vodic> vodici;
        private static int singleton = 0;

        internal List<Administrator> Administratori { get => administratori; set => administratori = value; }
        public string Opis { get => opis; set => opis = value; }
        public string Lokacija { get => lokacija; set => lokacija = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public BitmapImage Slika { get => slika; set => slika = value; }
        internal List<Putovanje> Putovanja { get => putovanja; set => putovanja = value; }
        internal List<OpisPutovanja> Ponude { get => ponude; set => ponude = value; }
        internal List<Korisnik> Putnici { get => putnici; set => putnici = value; }
        internal List<Vodic> Vodici { get => vodici; set => vodici = value; }

        public Agencija() {
            singleton++;
            if (singleton > 1)
            {
                throw new Exception("Samo jedna instanca ove klase moze biti napravljena");
            }
            administratori = new List<Administrator>();
            //administratori.Add(new Administrator("esma", DateTime.Now, "", 0, "esma", "esma"));
            putnici = new List<Korisnik>();
            putovanja = new List<Putovanje>();
            ponude = new List<OpisPutovanja>();
        }

        public Agencija(List<Administrator> administratori, BitmapImage slika, List<Putovanje> putovanja, List<OpisPutovanja> ponude, List<Korisnik> putnici, List<Vodic> vodici)
        {
            this.Administratori = administratori;
            this.Slika = slika;
            this.Putovanja = putovanja;
            this.Ponude = ponude;
            this.Putnici = putnici;
            this.Vodici = vodici;
        }

        public Agencija(Agencija a)
        {
            this.Administratori = a.Administratori;
            this.Opis = a.Opis;
            this.Lokacija = a.Lokacija;
            this.Telefon = a.Telefon;
            this.Slika = a.Slika;
            this.Putovanja = a.Putovanja;
            this.Ponude = a.Ponude;
            this.Putnici = a.Putnici;
            this.Vodici = a.Vodici;
        }
    }
}
