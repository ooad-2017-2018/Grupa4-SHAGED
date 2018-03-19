# **OPIS TEME**  
Potrebno je kreirati aplikaciju za prikaz ponuda i rezervaciju putovanja turisticke agencije. Svrha sistema je omoguciti laksi
nacin pregleda i odabira putovanja. Obzirom na nedostatak vremena, aplikacija omogucava korisnicima, da bez obilazenja turisticke 
agencije budu upoznati i informisani o trenutnim ponudama, te im se nudi mogucnost rezervacije. Korisnici takodjer mogu glasati za
jednu od mogucih buducih ponuda, putem online ankete. 

# **PROCESI**
## **Pregled ponuda**
Korisnik otvaranjem aplikacije ima mogucnost pregleda trenutnih ponuda u okviru turisticke agencije.

## **Rezervacija ponude**
Klikom na odabranu destinaciju korisnik unosi trazene podatkem (ime, prezime, datum rodjenja, email), sistem provjerava te podatke
te ako korisnik potvrdi rezervaciju unosi ih u sistem, a u suprotnom sistem obavjestava korisnika o greski i zahtijeva ponovni unos
podataka. Sistem takodjer provjerava koliko je ostalo slobodnih mijesta za tu ponudu, te ukoliko nema slobodnog mjesta, takodjer, 
obavjestava korisnika o greski.

## **Ucesce u anketi** 
Svaki korisnik ima mogucnost ucestvovanja u anketi, na nacin da predlozi ili odabere jednu od ponudjenih destinacija za pravljenje 
buducih ponuda. 

## **Pregled gradova u ponudi na mapi**
Korisnik ima opciju da na mapi pregleda lokacije gradova u trenutnoj ponudi.

## **Registracija administratora**
Administrator ima poseban account, pomocu kojeg moze pristupiti podacima o putnicima, pregledati popunjenost ponuda, unositi nove 
ponude, azurirati trenutne i brisati stare. Prijavljuje se tako sto unosi svoje korisnicko ime i lozinku, pri cemu sistem provjerava 
tacnost podataka i u slucaju greske izvjestava i zahtijeva ponovni unos.

# **FUNKCIONALNOSTI**
- mogucnost pregleda ponuda
- mogucnost rezervacije ponude
- mogucnost sugerisanja destinacije za novu ponudu
- mogucnost pregleda plana putovanja odabrane destinacije
- mogucnost dodavanja, mijenjanja, brisanja ponuda
- mogucnost pregleda hotela u odabranoj ponudi
- mogucnost pregleda "live" kamere zeljene destinacije
- mogucnost pregleda mape trenutno mogucih odredista
- mogucnost pregleda ponuda uz odredjena filtriranja
- mogucnost pregleda generalnih i kontakt informacija o turistickoj agenciji
- mogucnost informisanja o 3, do datog trenutka, najtrazenije ponude

# **AKTERI** 
## **Korisnik**
Korisnik je osoba koja ima mogucnost pregleda i rezervacije ponudenih turistickih destinacija, popunjavanja ankete, pregleda 
informacija o turistickoj agenciji, pronalazak destinacija na mapi, te pogled na destinaciju preko "live" kamere.

## **Administrator**
Administrator je osoba koja je zaduzena za odrzavanje sistema i baze podataka, te pregleda rezultate ankete.

## **Sistem**
Sistem cuva informacije o ponudama, rezervacijama, putnicima, lokacijama, dostupnosti ponuda, rezultatima ankete i daje informacije 
o greskama ukoliko se one dese.

