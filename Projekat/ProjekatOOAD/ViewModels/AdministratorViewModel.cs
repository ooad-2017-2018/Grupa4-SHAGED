using ProjekatOOAD.Models;
using ProjekatOOAD.Helper;
using ProjekatOOAD.Models.Baza_podataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Globalization;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace ProjekatOOAD.ViewModels
{
    public class AdministratorViewModel
    {
       
       
        public ICommand LoginAdmin { get; set; }
        public ICommand LogoutAdmin { get; set; }
        public ICommand dodajPonudu { get; set; }
        public ICommand izmijeniPonudu { get; set; }
        public ICommand obrisiPonudu { get; set; }
        public ICommand dodajPutovanje { get; set; }
        public ICommand osvjeziPutovanja { get; set; } // brise putovanja koja su prosla
        public ICommand obrisiNeaktivneKorisnike { get; set; } //brise korisnike koji u zadnje 2 godine nisu otisli na putovanje
        private Agencija agencija;
        public String AdminIme { get; set; }
        public String AdminSifra { get; set; }
        public Models.Administrator logovaniAdministrator { get; set; }
        public Putovanje putovanje { get; set; }
        #region Atributi za putovanje
        public DateTime polazak { get; set; }
        public DateTime povratak { get; set;}
        public List<int> putnici { get; set; }
        public int kapacitet { get; set; }
        public double cijena { get; set; }
        public string strKapacitet { get; set; }
        public string strCijena { get; set; }
        public OpisPutovanja opis { get; set; }
        #endregion
        public OpisPutovanja ponuda { get; set; }
        #region Atributi za Ponudu
        public int brojDana { get; set; }
        public string naziv { get; set; }
        public string planPutovanja { get; set; }
        public string hotel { get; set; }
        public string liveCamera { get; set; }
        public string vremenskaPrognoza { get; set; }
        public string znamenitosti { get; set; }
        public int putaOdrzano { get; set; }
        #endregion
        public OpisPutovanja ponudaZaBrisanje { get; set; }
        public OpisPutovanja ponudaZaMijenjanje { get; set; }
        #region Atributi za mijenjanje ponude
        public int brojDana1 { get; set; }
        public string naziv1 { get; set; }
        public string planPutovanja1 { get; set; }
        public string hotel1 { get; set; }
        public string liveCamera1 { get; set; }
        public string vremenskaPrognoza1 { get; set; }
        public string znamenitosti1 { get; set; }
        public int putaOdrzano1 { get; set; }
        #endregion
        public static bool prviPut = true;
        public static DateTime minZadnjePut { get; set; }

        internal Agencija Agencija { get => agencija; set => agencija = value; }

        IMobileServiceTable<DataBasePutovanje> putovanjeTabela = App.MobileService.GetTable<DataBasePutovanje>();
        IMobileServiceTable<DataBaseAdministrator> administratorTabela = App.MobileService.GetTable<DataBaseAdministrator>();
        IMobileServiceTable<DataBasePonuda> opisPutovanjaTabela = App.MobileService.GetTable<DataBasePonuda>();
        IMobileServiceTable<DataBaseKorisnik> korisniciTabela = App.MobileService.GetTable<DataBaseKorisnik>();
        //IMobileServiceTable<tabela> tabela = App.MobileService.GetTable<tabela>();


        public AdministratorViewModel()
        {
            agencija = new Agencija();
            minZadnjePut = DateTime.Now.AddYears(-2);
            if (prviPut)
            {
                prviPut = false;
                ucitajIzBaze();
            }
            LoginAdmin = new RelayCommand<Object>(LoginAdministratora);
            LogoutAdmin = new RelayCommand<Object>(LogoutAdministratora);
            dodajPonudu = new RelayCommand<Object>(DodavanjePonude);
            obrisiPonudu = new RelayCommand<Object>(BrisanjePonude);
            izmijeniPonudu = new RelayCommand<Object>(AzuriranjePonude);
            dodajPutovanje = new RelayCommand<Object>(DodavanjePutovanja);
            osvjeziPutovanja = new RelayCommand<Object>(OsvjeziPutovanja);
            obrisiNeaktivneKorisnike = new RelayCommand<Object>(ObrisiNeaktivneKorisnike);
            
        }

        async void ucitajIzBaze()
        {
            var ponudeX = await (from p in opisPutovanjaTabela select p).ToListAsync();
            foreach (DataBasePonuda x in ponudeX)
            {
                agencija.Ponude.Add(new OpisPutovanja(x));
                
            }
            int i = ponudeX.Count();
            if (i > 0) Int32.TryParse(ponudeX[i - 1].id, out OpisPutovanja.ID);
            OpisPutovanja.ID++;
            
            var putovanjaX = await (from p in putovanjeTabela select p).ToListAsync();
            foreach(DataBasePutovanje x in putovanjaX)
            {
                agencija.Putovanja.Add(new Putovanje(x));
            }
            i = putovanjaX.Count();
            if(i>0) Int32.TryParse(putovanjaX[i - 1].id, out Putovanje.ID);
            Putovanje.ID++;
            var adminiX = await (from p in administratorTabela select p).ToListAsync();
            foreach (DataBaseAdministrator x in adminiX)
            {
                agencija.Administratori.Add(new Models.Administrator(x));
            }
            i = adminiX.Count();
            if (i > 0) Int32.TryParse(adminiX[i - 1].id, out Models.Administrator.ID);
            Models.Administrator.ID++;
            var korisniciX = await (from p in korisniciTabela select p).ToListAsync();
            foreach (DataBaseKorisnik x in korisniciX)
            {
                agencija.Putnici.Add(new Models.Korisnik(x));
            }

            i = korisniciX.Count();
            if (i > 0) Int32.TryParse(korisniciX[i - 1].id, out Korisnik.ID);
            Korisnik.ID++;
        }

        #region Login i Logout administratora

        #region Validacija username i lozinka
        public bool mozeLiLogin()
        {
            int ad = agencija.Administratori.Count(x => x.ImeIprezime == AdminIme);
            if (ad == 0 || String.IsNullOrWhiteSpace(AdminIme))
            {
                PrikaziPoruku("Korisnicko ime nije ispravno!");
                return false;
            }
            Models.Administrator admini = agencija.Administratori.FirstOrDefault(x => x.ImeIprezime == AdminIme);
            if (admini.Lozinka != AdminSifra)
            {
                PrikaziPoruku("Pogresna lozinka!");
                return false;
            }

            return true;
        }


        #endregion

        public void LoginAdministratora(Object o)
        {
            if (mozeLiLogin())
            {
                foreach(Models.Administrator a in agencija.Administratori)
                {
                    if(a.KorisnickoIme == AdminIme && a.Lozinka== AdminSifra)
                    {
                        logovaniAdministrator = a;
                        var frame = (Frame)Window.Current.Content;
                        frame.Navigate(typeof(Administrator), this);
                    }
                }
            }
        }

        public void LogoutAdministratora(Object o)
        {
            On_BackRequested();
        }

        private bool On_BackRequested()
        {
            var frame = (Frame)Window.Current.Content;
            if (frame.CanGoBack)
            {
                frame.GoBack();
                return true;
            }
            return false;
        }

        #endregion
        
        #region Dodavanje/Brisanje/Mijenjanje ponuda

        async public void DodavanjePonude(Object o)
        {
            if (validirajDodavanje())
            {
                ponuda = new OpisPutovanja(naziv, null, brojDana, planPutovanja, hotel, liveCamera, vremenskaPrognoza,znamenitosti, putaOdrzano);
                
                DataBasePonuda dbPonuda = new DataBasePonuda(ponuda);
                
                try
                {
                    await opisPutovanjaTabela.InsertAsync(dbPonuda);
                    
                }
                catch (Exception e) {
                    //PrikaziPoruku("Veza sa bazom podataka nije uspjesno uspostavljena! Pokusajte ponovo");
                    //PrikaziPoruku(e.Message.ToString());
                   // OpisPutovanja.ID++;
                }
                agencija.Ponude.Add(ponuda);
                Administrator.o.Add(ponuda);
                await (new MessageDialog("Ponuda je uspjesno dodana")).ShowAsync();
                obrisiDodavanje();

            }
        }

        public bool validirajDodavanje()
        {
            if (brojDana <= 0 || String.IsNullOrWhiteSpace(naziv) || String.IsNullOrWhiteSpace(hotel) || String.IsNullOrWhiteSpace(planPutovanja) || String.IsNullOrWhiteSpace(vremenskaPrognoza))
            {
                PrikaziPoruku("Unesite ispravne podatke!");
                return false;
            }
            return true;
        }

        async void BrisanjePonude(Object o)
        {
            
            if (ponudaZaBrisanje != null)
            {
                
                var ponudeX = await (from p in opisPutovanjaTabela where p.id == ponudaZaBrisanje.OpisPutovanjaID.ToString() select p).ToListAsync();
                if (ponudeX.Count == 1)
                {
                    await opisPutovanjaTabela.DeleteAsync(ponudeX[0]);
                    

                }
                PrikaziPoruku("Ponuda " + ponudaZaBrisanje.Naziv + " je obrisana!");
                agencija.Ponude.Remove(ponudaZaBrisanje);
                Administrator.o.Remove(ponudaZaBrisanje);
            }
            else
            {
                PrikaziPoruku("Prvo odaberite ponudu!");
            }
        }

        void AzuriranjePonude(Object o)
        {
            if (ponudaZaMijenjanje != null)
            {
                if (!String.IsNullOrWhiteSpace(liveCamera1))
                {
                    ponudaZaMijenjanje.LiveCamera = liveCamera1;
                }
                if (!String.IsNullOrWhiteSpace(vremenskaPrognoza1))
                {
                    ponudaZaMijenjanje.VremenskaPrognoza = vremenskaPrognoza1;
                }
                if (!String.IsNullOrWhiteSpace(znamenitosti1))
                {
                    ponudaZaMijenjanje.Znamenitosti = znamenitosti1;
                }
                if (brojDana1>0 )
                {
                    ponudaZaMijenjanje.BrojDana = brojDana1;
                }
                if (!String.IsNullOrWhiteSpace(naziv1))
                {
                    ponudaZaMijenjanje.Naziv = naziv1;
                }
                if (!String.IsNullOrWhiteSpace(planPutovanja1))
                {
                    ponudaZaMijenjanje.PlanPutovanja = planPutovanja1;
                }
                if (!String.IsNullOrWhiteSpace(hotel1))
                {
                    ponudaZaMijenjanje.Hotel = hotel1;
                }
                ponudaZaBrisanje = ponudaZaMijenjanje;
                BrisanjePonude(o);
                ponuda = ponudaZaMijenjanje;
                DodavanjePonude(o);
                ponuda = ponudaZaBrisanje = ponudaZaMijenjanje = null;
            }
            else
            {
                PrikaziPoruku("Prvo odaberite ponudu!");
            }
        }
         void obrisiDodavanje()
        {
            naziv = "";
            brojDana = new Int32();
            planPutovanja = "";
            hotel = liveCamera = vremenskaPrognoza = znamenitosti = "";
        }

        #endregion

        #region Dodavanje/Brisanje putovanja
        async public void DodavanjePutovanja(Object o)
        {
            if (validirajPutovanje())
            {
                putovanje = new Putovanje(new List<int>(), polazak, povratak, kapacitet, cijena, opis.OpisPutovanjaID);
                agencija.Putovanja.Add(putovanje);
                DataBasePutovanje put = new DataBasePutovanje(putovanje);
                try
                {
                    await putovanjeTabela.InsertAsync(put);
                    await(new MessageDialog("Putovanje je uspjesno dodano")).ShowAsync();
                }
                catch (Exception e)
                {
                    PrikaziPoruku("Veza sa bazom podataka nije uspjesno uspostavljena! Pokusajte ponovo!");
                }
            }
        }

        public bool validirajPutovanje()
        {
            if (opis == null)
            {
                PrikaziPoruku("Odaberite jednu od ponuda!");
                return false;
            }
            if (polazak < DateTime.Now || polazak >= povratak)
            {
                PrikaziPoruku("Odaberite ispravne datume polaska i povratka!");
                return false;
            }
            if(String.IsNullOrWhiteSpace(strKapacitet) || String.IsNullOrWhiteSpace(strCijena))
            {
                PrikaziPoruku("Upisite ispravan kapacitet i cijenu!");
                return false;
            }
            else
            {
                int kap;
                double cij;
                Int32.TryParse(strKapacitet, out kap);
                Double.TryParse(strCijena, out cij);
                kapacitet = kap;
                cijena = cij;
                if(kapacitet <=0 || cijena <= 0)
                {
                    PrikaziPoruku("Upisite ispravan kapacitet i cijenu!");
                    return false;
                }
            }
            return true;
        }

        void OsvjeziPutovanja(Object o)
        {
            foreach(Putovanje p in agencija.Putovanja)
            {
                if (p.Polazak < DateTime.Now)
                {
                    ObrisiPutovanje(p);
                    ponudaZaMijenjanje = agencija.Ponude.FirstOrDefault(x => x.OpisPutovanjaID == p.OpisPutovanjaID);
                    putaOdrzano++;
                    AzuriranjePonude(o);
                }
            }

        }

        async void ObrisiPutovanje(Putovanje p)
        {
            agencija.Putovanja.Remove(p);
            var putovanjaX = await (from x in putovanjeTabela where p.PutovanjeID.ToString() == x.id select x).ToListAsync();
            if (putovanjaX.Count == 1)
            {
                await putovanjeTabela.DeleteAsync(putovanjaX[0]);
            }
        }
        #endregion

        public void ObrisiNeaktivneKorisnike(Object o)
        {
            
            foreach(Korisnik k in agencija.Putnici)
            {
                if(k.ZadnjePutovanje < minZadnjePut)
                {
                    ObrisiPutnika(k);
                }
            }
        }

        async public void ObrisiPutnika(Korisnik k)
        {
            agencija.Putnici.Remove(k);
            var putniciX = await (from x in korisniciTabela where k.KorisnikID.ToString() == x.id select x).ToListAsync();
            if (putniciX.Count == 1)
            {
                await korisniciTabela.DeleteAsync(putniciX[0]);
            }
        }

        async void PrikaziPoruku(string error)
        {
            await new MessageDialog(error).ShowAsync();
        }
    }

}
