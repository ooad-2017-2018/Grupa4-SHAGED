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
