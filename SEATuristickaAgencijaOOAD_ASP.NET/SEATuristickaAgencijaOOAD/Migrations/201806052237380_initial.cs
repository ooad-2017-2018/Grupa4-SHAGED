namespace SEATuristickaAgencijaOOAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrator",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        korisnickoIme = c.String(unicode: false),
                        lozinka = c.String(unicode: false),
                        imeIprezime = c.String(unicode: false),
                        datumRodjenja = c.DateTime(nullable: false),
                        email = c.String(),
                        jmbg = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Korisnik",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        brojPasosa = c.String(),
                        spol = c.Boolean(nullable: false),
                        brojTelefona = c.String(),
                        obavijesti = c.Boolean(nullable: false),
                        osiguranje = c.Boolean(nullable: false),
                        putovanja = c.String(unicode: false),
                        zadnjePutovanje = c.DateTime(nullable: false),
                        imeIprezime = c.String(unicode: false),
                        datumRodjenja = c.DateTime(nullable: false),
                        email = c.String(),
                        jmbg = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpisPutovanja",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        naziv = c.String(),
                        slika = c.String(unicode: false),
                        brojDana = c.Int(nullable: false),
                        planPutovanja = c.String(),
                        hotel = c.String(unicode: false),
                        liveCamera = c.String(unicode: false),
                        putaOdrzano = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Putovanje",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        putnici = c.String(unicode: false),
                        polazak = c.DateTime(nullable: false),
                        povratak = c.DateTime(nullable: false),
                        kapacitet = c.Int(nullable: false),
                        cijena = c.Double(nullable: false),
                        opisPutovanjaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Putovanje");
            DropTable("dbo.OpisPutovanja");
            DropTable("dbo.Korisnik");
            DropTable("dbo.Administrator");
        }
    }
}
