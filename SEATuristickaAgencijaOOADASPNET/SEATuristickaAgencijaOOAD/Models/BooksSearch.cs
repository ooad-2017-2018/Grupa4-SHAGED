using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SEATuristickaAgencijaOOAD.Models
{
    public class BooksSearch
    {
        
       private static BooksService _booksService;
        public BooksSearch()
        {
            _booksService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCWsmbRBqcj1ycgw2Ki96PT0yx4OBMKBro",
                ApplicationName = this.GetType().ToString()
            });
        }
        public static List<Knjiga>Search(string query)
        {
            var listquery = _booksService.Volumes.List(query);
            listquery.MaxResults = 10;
            var res = listquery.Execute();
            List<Knjiga> books = new List<Knjiga>();
            foreach( var b in res.Items)
            {
                books.Add(new Knjiga(b.VolumeInfo.Title, null));
            }
            //var books = res.Items.Select(b => new Knjiga(b.VolumeInfo.Title, b.VolumeInfo.Categories.ToString())).ToList();
            return books;
        }
        /*
         * BooksSearch a = new BooksSearch();
         *var x = BooksSearch.Search("tourism");
         * x.Item2*/
    }
}