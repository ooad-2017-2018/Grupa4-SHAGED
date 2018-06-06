using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SEATuristickaAgencijaOOAD.Models
{
    public class SEAContext:DbContext
    {


            public SEAContext() : base("AzureConnection") //AzureConnection je naziv connection stringa u Web.config-u
            {
            }

            //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka
            public DbSet<Administrator> Administrator { get; set; }
            public DbSet<Korisnik> Korisnik { get; set; }
            public DbSet<Putovanje> Putovanje { get; set; }
            public DbSet<Rezervacija> Rezervacijas { get; set; }
            public DbSet<OpisPutovanja> OpisPutovanja { get; set; }
            
            //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Rezervacija>()
            .HasKey(e => e.Id);

          

            modelBuilder.Entity<Administrator>()
            .Property(e => e.imeIprezime)
            .IsUnicode(false);
            

            modelBuilder.Entity<Administrator>()
                .Property(e => e.korisnickoIme)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.lozinka)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.putovanja)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.imeIprezime)
                .IsUnicode(false);
            modelBuilder.Entity<Putovanje>()
                .Property(e => e.putnici)
                .IsUnicode(false);

            modelBuilder.Entity<OpisPutovanja>()
                .Property(e => e.hotel)
                .IsUnicode(false);

            modelBuilder.Entity<OpisPutovanja>()
                .Property(e => e.liveCamera)
                .IsUnicode(false);

            modelBuilder.Entity<OpisPutovanja>()
                .Property(e => e.slika)
                .IsUnicode(false);
            

            modelBuilder.Entity<Korisnik>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Administrator>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Putovanje>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<OpisPutovanja>()
                .HasKey(o => o.Id);
        }
        }
    }

