using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIBooks.Models;

namespace WebAPIControllers
{
    public class KnjigasController : ApiController
    {
        Knjiga[] knjigas = new Knjiga[]
        {
            new Knjiga { Id = 1, Name = "Travel Guide", Genre = "Guides" },
            new Knjiga { Id = 2, Name = "Maldives", Genre = "History" },
            new Knjiga { Id = 3, Name = "Paris", Genre = "History" },
            new Knjiga { Id = 4, Name = "Kuba", Genre = "Guides" }
        };

        public IEnumerable<Knjiga> GetAllKnjigas()
        {
            /*
            new BooksSearch();
            var x = BooksSearch.Search("Tourism");
            knjigas = new Knjiga[x.Item2.Count()];
            for(int i=0; i<x.Item2.Count(); i++)
            {
                Knjiga k = new Knjiga();
                k.Id = i;
                k.Name = x.Item2[i].Naziv;
                k.Genre = x.Item2[i].ImeAutora;
                knjigas[i] = k;
            }*/
            return knjigas;
        }

        public IHttpActionResult GetKnjiga(int id)
        {
            var product = knjigas.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
